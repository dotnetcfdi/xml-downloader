using System.Net;
using XmlDownloader.Core.Services.Common;

namespace XmlDownloader.Core.SoapClient
{
    public class InternalResponse
    {
        public bool IsSuccessStatusCode { get; set; }
        public string? ReasonPhrase { get; set; }
        public string? RawResponse { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public EndPointName EndPointName { get; set; }
        public InternalRequest? InternalRequest { get; set; }
    }
}