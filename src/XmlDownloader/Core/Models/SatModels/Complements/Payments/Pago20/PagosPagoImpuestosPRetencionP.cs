using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago20
{
    [Serializable, XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos20")]
    public  class PagosPagoImpuestosPRetencionP {
    
        private string impuestoPField;
    
        private decimal importePField;
    
    
        [XmlAttribute]
        public string ImpuestoP {
            get {
                return impuestoPField;
            }
            set {
                impuestoPField = value;
            }
        }
    
    
        [XmlAttribute]
        public decimal ImporteP {
            get {
                return importePField;
            }
            set {
                importePField = value;
            }
        }
    }
}