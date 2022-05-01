using XmlDownloader.Core.Common;

namespace XmlDownloader.Core.Services.Query
{
    public class QueryResult : Result, IHasSuccessResponse
    {
        public string? RequestId { get; set; }
        public bool IsSuccess { get; set; }
    }
}