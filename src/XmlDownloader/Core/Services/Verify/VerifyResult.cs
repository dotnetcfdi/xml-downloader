using XmlDownloader.Core.Common;

namespace XmlDownloader.Core.Services.Verify
{
    /// <summary>
    /// Define raw response for sat verify service (ws verifica solicitud)
    /// StatusCode=CodEstatus and Message=Mensaje properties inherited from Result and it
    /// represent the code and status message of the web service call.
    /// </summary>
    public class VerifyResult : Result, IHasSuccessResponse
    {
        // StatusCode = CodEstatus
        //Message = Mensaje

        //EstadoSolicitud
        public string? StatusRequest { get; set; }

        //CodigoEstadoSolicitud
        public string? CodeStatusRequest { get; set; }

        //NumeroCFDIs
        public string? CfdiQty { get; set; }

        //IdsPaquetes
        public List<string> PackagesIds { get; set; } = new();

        //Internal flag to indicate success or failure
        public bool IsSuccess { get; set; }
    }
}