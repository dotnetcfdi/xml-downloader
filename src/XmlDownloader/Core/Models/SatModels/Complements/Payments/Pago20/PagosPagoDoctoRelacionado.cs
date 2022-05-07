
using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago20
{
    [Serializable()]


    [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos20")]
    public class PagosPagoDoctoRelacionado
    {

        private PagosPagoDoctoRelacionadoImpuestosDR impuestosDRField;

        private string idDocumentoField;

        private string serieField;

        private string folioField;

        private string monedaDRField;

        private decimal equivalenciaDRField;

        private bool equivalenciaDRFieldSpecified;

        private string numParcialidadField;

        private decimal impSaldoAntField;

        private decimal impPagadoField;

        private decimal impSaldoInsolutoField;

        private string objetoImpDRField;


        public PagosPagoDoctoRelacionadoImpuestosDR ImpuestosDR
        {
            get
            {
                return this.impuestosDRField;
            }
            set
            {
                this.impuestosDRField = value;
            }
        }


        [XmlAttribute()]
        public string IdDocumento
        {
            get
            {
                return this.idDocumentoField;
            }
            set
            {
                this.idDocumentoField = value;
            }
        }


        [XmlAttribute()]
        public string Serie
        {
            get
            {
                return this.serieField;
            }
            set
            {
                this.serieField = value;
            }
        }


        [XmlAttribute()]
        public string Folio
        {
            get
            {
                return this.folioField;
            }
            set
            {
                this.folioField = value;
            }
        }


        [XmlAttribute()]
        public string MonedaDR
        {
            get
            {
                return this.monedaDRField;
            }
            set
            {
                this.monedaDRField = value;
            }
        }


        [XmlAttribute()]
        public decimal EquivalenciaDR
        {
            get
            {
                return this.equivalenciaDRField;
            }
            set
            {
                this.equivalenciaDRField = value;
                this.equivalenciaDRFieldSpecified = true;
            }
        }


        [XmlIgnore()]
        public bool EquivalenciaDRSpecified
        {
            get
            {
                return this.equivalenciaDRFieldSpecified;
            }
            set
            {
                this.equivalenciaDRFieldSpecified = value;
            }
        }


        [XmlAttribute(DataType = "integer")]
        public string NumParcialidad
        {
            get
            {
                return this.numParcialidadField;
            }
            set
            {
                this.numParcialidadField = value;
            }
        }


        [XmlAttribute()]
        public decimal ImpSaldoAnt
        {
            get
            {
                return this.impSaldoAntField;
            }
            set
            {
                this.impSaldoAntField = value;
            }
        }


        [XmlAttribute()]
        public decimal ImpPagado
        {
            get
            {
                return this.impPagadoField;
            }
            set
            {
                this.impPagadoField = value;
            }
        }


        [XmlAttribute()]
        public decimal ImpSaldoInsoluto
        {
            get
            {
                return this.impSaldoInsolutoField;
            }
            set
            {
                this.impSaldoInsolutoField = value;
            }
        }


        [XmlAttribute()]
        public string ObjetoImpDR
        {
            get
            {
                return this.objetoImpDRField;
            }
            set
            {
                this.objetoImpDRField = value;
            }
        }
    }
}