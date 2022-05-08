using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago20
{
    [Serializable, XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos20")]
    public  class PagosPagoImpuestosP {
    
        private PagosPagoImpuestosPRetencionP[] retencionesPField;
    
        private PagosPagoImpuestosPTrasladoP[] trasladosPField;
    
    
        [XmlArrayItem("RetencionP", IsNullable=false)]
        public PagosPagoImpuestosPRetencionP[] RetencionesP {
            get {
                return retencionesPField;
            }
            set {
                retencionesPField = value;
            }
        }
    
    
        [XmlArrayItem("TrasladoP", IsNullable=false)]
        public PagosPagoImpuestosPTrasladoP[] TrasladosP {
            get {
                return trasladosPField;
            }
            set {
                trasladosPField = value;
            }
        }
    }
}