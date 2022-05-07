using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago20
{
    [Serializable()]


    [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos20")]
    public class PagosPagoImpuestosPTrasladoP
    {

        private decimal basePField;

        private string impuestoPField;

        private string tipoFactorPField;

        private decimal tasaOCuotaPField;

        private bool tasaOCuotaPFieldSpecified;

        private decimal importePField;

        private bool importePFieldSpecified;


        [XmlAttribute()]
        public decimal BaseP
        {
            get
            {
                return this.basePField;
            }
            set
            {
                this.basePField = value;
            }
        }


        [XmlAttribute()]
        public string ImpuestoP
        {
            get
            {
                return this.impuestoPField;
            }
            set
            {
                this.impuestoPField = value;
            }
        }


        [XmlAttribute()]
        public string TipoFactorP
        {
            get
            {
                return this.tipoFactorPField;
            }
            set
            {
                this.tipoFactorPField = value;
            }
        }


        [XmlAttribute()]
        public decimal TasaOCuotaP
        {
            get
            {
                return this.tasaOCuotaPField;
            }
            set
            {
                this.tasaOCuotaPField = value;
                this.tasaOCuotaPFieldSpecified = value >= 0;
            }
        }


        [XmlIgnore()]
        public bool TasaOCuotaPSpecified
        {
            get
            {
                return this.tasaOCuotaPFieldSpecified;
            }
            set
            {
                this.tasaOCuotaPFieldSpecified = value;
            }
        }


        [XmlAttribute()]
        public decimal ImporteP
        {
            get
            {
                return this.importePField;
            }
            set
            {
                this.importePField = value;
                this.importePFieldSpecified = value >= 0;
            }
        }


        [XmlIgnore()]
        public bool ImportePSpecified
        {
            get
            {
                return this.importePFieldSpecified;
            }
            set
            {
                this.importePFieldSpecified = value;
            }
        }
    }
}