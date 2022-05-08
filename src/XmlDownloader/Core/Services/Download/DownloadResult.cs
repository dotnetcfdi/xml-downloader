using XmlDownloader.Core.Common;

namespace XmlDownloader.Core.Services.Download
{
    public class DownloadResult : Result, IHasSuccessResponse
    {
        public bool IsSuccess { get; set; }

        public string? PackageId { get; set; }
        public string? PackageBase64 { get; set; }
    }
}