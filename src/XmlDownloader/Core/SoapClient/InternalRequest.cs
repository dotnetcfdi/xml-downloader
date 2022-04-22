using System.Security.AccessControl;
using System.Text;
using XmlDownloader.Core.Common;

namespace XmlDownloader.Core.SoapClient
{
    public class InternalRequest
    {
        public string Url { get; set; }
        public string SoapAction { get; set; }
        public string SoapEnvelope { get; set; }
        public EndPointName EndPointName { get; set; }
        public HttpMethod HttpMethod { get; set; } = HttpMethod.Post;
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        public string MediaType { get; set; } = "text/xml";
        public HttpRequestMessage? HttpRequestMessage { get; set; }

        public List<KeyValuePair<string, string>> Headers { get; set; } = new();


        public void AddHeader(string key, string value)
        {
            Headers.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}