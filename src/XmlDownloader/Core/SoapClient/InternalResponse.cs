using System.Net;
using System.Xml;
using XmlDownloader.Core.Common;

namespace XmlDownloader.Core.SoapClient
{
    public class InternalResponse
    {

        public bool IsSuccessStatusCode { get; set; }
        public string? ReasonPhrase { get; set; }
        public string? ResponseAsString { get; set; }
        public HttpRequestMessage? HttpRequestMessage { get; set; }
        public HttpResponseMessage? HttpResponseMessage { get; set; }
        public XmlDocument? ResponseAsXml { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public EndPointName EndPointName { get; set; }
    }
}