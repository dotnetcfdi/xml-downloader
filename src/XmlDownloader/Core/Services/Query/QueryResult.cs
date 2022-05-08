using XmlDownloader.Core.Services.Common;

namespace XmlDownloader.Core.Services.Query
{
    public class QueryResult : Result, IHasSuccessResponse
    {
        public string? RequestUuid { get; set; }
        public bool IsSuccess { get; set; }
    }
}