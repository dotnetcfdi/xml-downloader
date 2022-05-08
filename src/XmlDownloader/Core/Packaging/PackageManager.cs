using System.IO.Compression;
using System.Reflection;
using XmlDownloader.Core.Helpers;
using XmlDownloader.Core.Models;
using XmlDownloader.Core.Models.SatModels.Invoicing.Cfdi40;
using XmlDownloader.Core.Services.Download;

namespace XmlDownloader.Core.Packaging
{
    public static class PackageManager
    {
        public static async Task<List<MetadataItem>> GetMetadataAsync(DownloadResult result)
        {
            EnsureDirectories();

            var metadata = new List<MetadataItem>();

            var successfulWriting = await WriteZipAsync(result);

            if (!successfulWriting)
                return metadata;

            var file = Path.Combine(Settings.WorkDirectory, $@"{result.PackageId}{Settings.PackageExtension}");

            ZipFile.ExtractToDirectory(file, Settings.WorkDirectory);

            var files = GetFileList(Settings.WorkDirectory, ".txt");


            foreach (var fileModel in files)
                metadata.AddRange(await GetMetadataFromSingleFileAsync(fileModel));


            return metadata;
        }


        public static async Task<List<Comprobante>> GetCfdisAsync(DownloadResult result)
        {
            EnsureDirectories();

            var cfdis = new List<Comprobante>();

            var successfulWriting = await WriteZipAsync(result);

            if (!successfulWriting)
                return cfdis;

            var file = Path.Combine(Settings.WorkDirectory, $@"{result.PackageId}{Settings.PackageExtension}");

            ZipFile.ExtractToDirectory(file, Settings.WorkDirectory);

            var files = GetFileList(Settings.WorkDirectory, ".xml");


            foreach (var fileModel in files)
                cfdis.Add(GetCfdiFromSingleFile(fileModel));


            return cfdis;
        }


        #region Helpers

        private static async Task<IEnumerable<MetadataItem>> GetMetadataFromSingleFileAsync(FileModel fileModel)
        {
            var metadata = new List<MetadataItem>();

            if (fileModel.FullFileName is null)
                return metadata;

            var lines = await File.ReadAllLinesAsync(fileModel.FullFileName).ConfigureAwait(false);

            foreach (var line in lines.Skip(1).ToList())
            {
                var fields = line.Split("~");

                var metadataItem = new MetadataItem
                {
                    Uuid = fields[0],
                    EmitterRfc = fields[1],
                    EmitterLegalName = fields[2],
                    ReceiverRfc = fields[3],
                    ReceiverLegalName = fields[4],
                    PacRfc = fields[5],
                    invoiceDate = fields[6],
                    CertificationDate = fields[7],
                    invoiceAmount = fields[8],
                    invoiceType = fields[9],
                    Status = fields[10],
                    CancellationDate = fields.Length == 12 ? fields[11] : null,
                };

                metadata.Add(metadataItem);
            }

            return metadata;
        }


        private static Comprobante GetCfdiFromSingleFile(FileModel fileModel)
        {
            var comprobante = Helper.Deserialize(fileModel.FullFileName ?? "");

            return comprobante ?? new Comprobante();
        }


        private static async Task<bool> WriteZipAsync(DownloadResult result)
        {
            if (!result.IsSuccess) return false;

            try
            {
                string file;


                if (Settings.EnableRedundantWriting)
                {
                    file = Path.Combine(Settings.PackagesDirectory, $@"{result.PackageId}{Settings.PackageExtension}");

                    await File.WriteAllBytesAsync(file, Convert.FromBase64String(result.PackageBase64 ?? ""));
                }


                file = Path.Combine(Settings.WorkDirectory, $@"{result.PackageId}{Settings.PackageExtension}");

                await File.WriteAllBytesAsync(file, Convert.FromBase64String(result.PackageBase64 ?? ""));

                return true;
            }
            catch (Exception ex)
            {
                var strTitle = $"Error On {MethodBase.GetCurrentMethod()?.Name}";
                Helper.SaveLog(strTitle, ex);

                return false;
            }
        }

        private static void ClearDirectory(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            foreach (var file in directoryInfo.GetFiles())
            {
                file.Delete();
            }

            foreach (var dir in directoryInfo.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        private static void EnsureDirectories()
        {
            //Settings.PackagesDirectory=packDir;

            if (!Directory.Exists(Settings.PackagesDirectory))
                Directory.CreateDirectory(Settings.PackagesDirectory);


            if (!Directory.Exists(Settings.WorkDirectory))
                Directory.CreateDirectory(Settings.WorkDirectory);


            if (!Directory.Exists(Settings.LogsDirectory))
                Directory.CreateDirectory(Settings.LogsDirectory);

            ClearDirectory(Settings.WorkDirectory);
        }

        private static List<FileModel> GetFileList(string directoryPath, string extensionFilter)
        {
            extensionFilter = $"*{extensionFilter}";

            var directory = new DirectoryInfo(directoryPath); // your Folder

            var files = directory.GetFiles(extensionFilter); //Getting Text files

            return files.Select(file => new FileModel {FileName = file.Name, FullFileName = file.FullName}).ToList();
        }

        #endregion
    }
}