
using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago20
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos20")]
    [XmlRoot(Namespace = "http://www.sat.gob.mx/Pagos20", IsNullable = false)]
    public  class Pagos {
    
        private PagosTotales totalesField;
    
        private PagosPago[] pagoField;
    
        private string versionField;
    
        public Pagos() {
            this.versionField = "2.0";
        }
    
    
        public PagosTotales Totales {
            get {
                return this.totalesField;
            }
            set {
                this.totalesField = value;
            }
        }
    
    
        [XmlElement("Pago")]
        public PagosPago[] Pago {
            get {
                return this.pagoField;
            }
            set {
                this.pagoField = value;
            }
        }
    
    
        [XmlAttribute()]
        public string Version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
    }
}