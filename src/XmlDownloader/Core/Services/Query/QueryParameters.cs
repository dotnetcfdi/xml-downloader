using XmlDownloader.Core.Common;
using XmlDownloader.Core.Helpers;

namespace XmlDownloader.Core.Services.Query
{
    public class QueryParameters
    {
        private string? emitterRfc;
        private string? receiverRfc;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DownloadType DownloadType { get; set; } // Emitted | Received
        public RequestType RequestType { get; set; } // Cfdi | Meta,

        public string? EmitterRfc
        {
            get => emitterRfc;
            set
            {
                emitterRfc = value;
                ReceiverRfc = null;
                DownloadType = DownloadType.Emitted;
            }
        }

        public string? ReceiverRfc
        {
            get => receiverRfc;
            set
            {
                receiverRfc = value;
                emitterRfc = null;
                DownloadType = DownloadType.Received;
            }
        }

    }
}