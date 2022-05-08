using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago20
{
    [Serializable, XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos20")]
    public  class PagosPagoDoctoRelacionadoImpuestosDRRetencionDR {
    
        private decimal baseDRField;
    
        private string impuestoDRField;
    
        private string tipoFactorDRField;
    
        private decimal tasaOCuotaDRField;
    
        private decimal importeDRField;
    
    
        [XmlAttribute]
        public decimal BaseDR {
            get {
                return baseDRField;
            }
            set {
                baseDRField = value;
            }
        }
    
    
        [XmlAttribute]
        public string ImpuestoDR {
            get {
                return impuestoDRField;
            }
            set {
                impuestoDRField = value;
            }
        }
    
    
        [XmlAttribute]
        public string TipoFactorDR {
            get {
                return tipoFactorDRField;
            }
            set {
                tipoFactorDRField = value;
            }
        }
    
    
        [XmlAttribute]
        public decimal TasaOCuotaDR {
            get {
                return tasaOCuotaDRField;
            }
            set {
                tasaOCuotaDRField = value;
            }
        }
    
    
        [XmlAttribute]
        public decimal ImporteDR {
            get {
                return importeDRField;
            }
            set {
                importeDRField = value;
            }
        }
    }
}