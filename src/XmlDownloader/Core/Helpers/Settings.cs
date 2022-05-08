namespace XmlDownloader.Core.Helpers
{
    public static class Settings
    {
        #region Props

        public static bool EnableRedundantPacketWriter { get; set; } = true;
        public static string PackageExtension { get; set; } = ".Zip";

        public static string PackagesDirectory { get; set; } =
            Path.Combine(Environment.CurrentDirectory, "PackagesDirectory");

        public static string WorkDirectory { get; set; } = Path.Combine(Environment.CurrentDirectory, "WorkDirectory");

        public static string LogsDirectory { get; set; } = Path.Combine(Environment.CurrentDirectory, "XmlLogs");


        public const string RootNameSpace33 = @"http://www.sat.gob.mx/cfd/3";
        public const string RootNameSpace40 = @"http://www.sat.gob.mx/cfd/4";

        #endregion
    }
}