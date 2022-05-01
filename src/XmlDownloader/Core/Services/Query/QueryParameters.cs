using XmlDownloader.Core.Common;
using XmlDownloader.Core.Helpers;

namespace XmlDownloader.Core.Services.Query
{
    public class QueryParameters
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DownloadType DownloadType { get; set; } // Emitted | Received
        public RequestType RequestType { get; set; } // Cfdi | Meta,

        public string? EmitterRfc { get; set; }

        public string? ReceiverRfc { get; set; }
    }
}