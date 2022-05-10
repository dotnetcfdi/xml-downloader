using XmlDownloader.Core.SoapClient;

namespace XmlDownloader.Core.Services.Common;

public interface IHasInternalRequestResponse
{
    public InternalRequest? InternalRequest { get; set; }
    public InternalResponse? InternalResponse { get; set; }
}