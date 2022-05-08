using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago20
{
    [Serializable, XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos20")]
    public  class PagosPagoDoctoRelacionadoImpuestosDR {
    
        private PagosPagoDoctoRelacionadoImpuestosDRRetencionDR[] retencionesDRField;
    
        private PagosPagoDoctoRelacionadoImpuestosDRTrasladoDR[] trasladosDRField;
    
    
        [XmlArrayItem("RetencionDR", IsNullable=false)]
        public PagosPagoDoctoRelacionadoImpuestosDRRetencionDR[] RetencionesDR {
            get {
                return retencionesDRField;
            }
            set {
                retencionesDRField = value;
            }
        }
    
    
        [XmlArrayItem("TrasladoDR", IsNullable=false)]
        public PagosPagoDoctoRelacionadoImpuestosDRTrasladoDR[] TrasladosDR {
            get {
                return trasladosDRField;
            }
            set {
                trasladosDRField = value;
            }
        }
    }
}