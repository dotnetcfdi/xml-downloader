using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDownloader.WebClient
{
    internal class InternalRequest
    {
        internal InternalRequest(string url, string soapAction, string soapEnvelopeXml, HttpMethod httpMethod)
        {
            Url = url;
            SoapEnvelopeXml = soapEnvelopeXml;
            HttpMethod = httpMethod;
            SoapAction = soapAction;
        }

        internal string Url { get; set; }
        internal string SoapAction { get; set; }
        internal string SoapEnvelopeXml { get; set; }
        internal HttpMethod HttpMethod { get; set; }
        internal Encoding Encoding { get; set; } = Encoding.UTF8;
        public string MediaType { get; set; } = "text/xml";
        internal List<KeyValuePair<string, string>> Headers { get; set; } = new();
    }
}