namespace XmlDownloader.Core.Models
{
    public class MetadataItem
    {
        /// <summary>
        /// uuid
        /// </summary>
        public string? Uuid { get; set; }

        /// <summary>
        /// rfcEmisor
        /// </summary>
        public string? EmitterRfc { get; set; }

        /// <summary>
        /// Razon social del emisor
        /// </summary>
        public string? EmitterLegalName { get; set; }

        /// <summary>
        /// rfcReceptor
        /// </summary>
        public string? ReceiverRfc { get; set; }

        /// <summary>
        /// Razon social de receptor
        /// </summary>
        public string? ReceiverLegalName { get; set; }

        /// <summary>
        /// rfc del PAC
        /// </summary>
        public string? PacRfc { get; set; }

        /// <summary>
        /// fechaEmision
        /// </summary>
        public string? invoiceDate { get; set; }

        /// <summary>
        /// fechaCertificacionSat
        /// </summary>
        public string? CertificationDate { get; set; }

        /// <summary>
        /// monto
        /// </summary>
        public string? invoiceAmount { get; set; }

        /// <summary>
        /// efectoComprobante
        /// </summary>
        public string? invoiceType { get; set; }

        /// <summary>
        /// 1 vigente | 0 cancelado
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// fechaCancelacion
        /// </summary>
        public string? CancellationDate { get; set; }
    }
}