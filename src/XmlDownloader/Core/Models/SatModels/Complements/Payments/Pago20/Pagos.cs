
using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago20
{
    [Serializable, XmlRoot(Namespace = "http://www.sat.gob.mx/Pagos20", IsNullable = false)]
    // [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos20")]
    public  class Pagos {
    
        private PagosTotales totalesField;
    
        private PagosPago[] pagoField;
    
        private string versionField;
    
        public Pagos() {
            versionField = "2.0";
        }
    
    
        public PagosTotales Totales {
            get {
                return totalesField;
            }
            set {
                totalesField = value;
            }
        }
    
    
        [XmlElement("Pago")]
        public PagosPago[] Pago {
            get {
                return pagoField;
            }
            set {
                pagoField = value;
            }
        }
    
    
        [XmlAttribute]
        public string Version {
            get {
                return versionField;
            }
            set {
                versionField = value;
            }
        }
    }
}