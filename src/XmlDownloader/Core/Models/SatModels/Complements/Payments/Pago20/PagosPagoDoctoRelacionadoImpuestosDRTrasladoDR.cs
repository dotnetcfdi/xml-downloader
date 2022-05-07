using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago20
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos20")]
    public class PagosPagoDoctoRelacionadoImpuestosDRTrasladoDR
    {

        private decimal baseDRField;

        private string impuestoDRField;

        private string tipoFactorDRField;

        private decimal tasaOCuotaDRField;

        private bool tasaOCuotaDRFieldSpecified;

        private decimal importeDRField;

        private bool importeDRFieldSpecified;


        [XmlAttribute()]
        public decimal BaseDR
        {
            get
            {
                return this.baseDRField;
            }
            set
            {
                this.baseDRField = value;
            }
        }


        [XmlAttribute()]
        public string ImpuestoDR
        {
            get
            {
                return this.impuestoDRField;
            }
            set
            {
                this.impuestoDRField = value;
            }
        }


        [XmlAttribute()]
        public string TipoFactorDR
        {
            get
            {
                return this.tipoFactorDRField;
            }
            set
            {
                this.tipoFactorDRField = value;
                this.tasaOCuotaDRFieldSpecified = true;
            }
        }


        [XmlAttribute()]
        public decimal TasaOCuotaDR
        {
            get
            {
                return this.tasaOCuotaDRField;
            }
            set
            {
                this.tasaOCuotaDRField = value;
                this.tasaOCuotaDRFieldSpecified = value >= 0;
            }
        }


        [XmlIgnore()]
        public bool TasaOCuotaDRSpecified
        {
            get
            {
                return this.tasaOCuotaDRFieldSpecified;
            }
            set
            {
                this.tasaOCuotaDRFieldSpecified = value;
            }
        }


        [XmlAttribute()]
        public decimal ImporteDR
        {
            get
            {
                return this.importeDRField;
            }
            set
            {
                this.importeDRField = value;
                this.importeDRFieldSpecified = value >= 0;
            }
        }


        [XmlIgnore()]
        public bool ImporteDRSpecified
        {
            get
            {
                return this.importeDRFieldSpecified;
            }
            set
            {
                this.importeDRFieldSpecified = value;
            }
        }
    }
}