using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago20
{
    [Serializable()]
    [XmlType(AnonymousType=true, Namespace="http://www.sat.gob.mx/Pagos20")]
    public  class PagosPagoDoctoRelacionadoImpuestosDRRetencionDR {
    
        private decimal baseDRField;
    
        private string impuestoDRField;
    
        private string tipoFactorDRField;
    
        private decimal tasaOCuotaDRField;
    
        private decimal importeDRField;
    
    
        [XmlAttribute()]
        public decimal BaseDR {
            get {
                return this.baseDRField;
            }
            set {
                this.baseDRField = value;
            }
        }
    
    
        [XmlAttribute()]
        public string ImpuestoDR {
            get {
                return this.impuestoDRField;
            }
            set {
                this.impuestoDRField = value;
            }
        }
    
    
        [XmlAttribute()]
        public string TipoFactorDR {
            get {
                return this.tipoFactorDRField;
            }
            set {
                this.tipoFactorDRField = value;
            }
        }
    
    
        [XmlAttribute()]
        public decimal TasaOCuotaDR {
            get {
                return this.tasaOCuotaDRField;
            }
            set {
                this.tasaOCuotaDRField = value;
            }
        }
    
    
        [XmlAttribute()]
        public decimal ImporteDR {
            get {
                return this.importeDRField;
            }
            set {
                this.importeDRField = value;
            }
        }
    }
}