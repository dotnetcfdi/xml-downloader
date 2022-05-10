using XmlDownloader.Core.Services.Common;
using XmlDownloader.Core.SoapClient;

namespace XmlDownloader.Core.Services.Query
{
    public class QueryResult : Result, IHasSuccessResponse, IHasInternalRequestResponse
    {
        public string? RequestUuid { get; set; }
        public bool IsSuccess { get; set; }
        public InternalRequest? InternalRequest { get; set; }
        public InternalResponse? InternalResponse { get; set; }
    }
}