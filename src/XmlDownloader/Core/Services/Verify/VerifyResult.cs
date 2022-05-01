using XmlDownloader.Core.Common;

namespace XmlDownloader.Core.Services.Verify
{
    public class VerifyResult : Result, IHasSuccessResponse
    {
        public bool IsSuccess { get; set; }
    }
}