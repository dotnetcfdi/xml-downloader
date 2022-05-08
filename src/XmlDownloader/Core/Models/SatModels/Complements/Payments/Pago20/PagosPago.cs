using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago20
{
    [Serializable]


    //// [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos20")]
    public class PagosPago
    {

        private PagosPagoDoctoRelacionado[] doctoRelacionadoField;

        private PagosPagoImpuestosP impuestosPField;

        private string fechaPagoField;

        private string formaDePagoPField;

        private string monedaPField;

        private decimal tipoCambioPField;

        private bool tipoCambioPFieldSpecified;

        private decimal montoField;

        private string numOperacionField;

        private string rfcEmisorCtaOrdField;

        private string nomBancoOrdExtField;

        private string ctaOrdenanteField;

        private string rfcEmisorCtaBenField;

        private string ctaBeneficiarioField;

        private string tipoCadPagoField;

        private bool tipoCadPagoFieldSpecified;

        private byte[] certPagoField;

        private string cadPagoField;

        private byte[] selloPagoField;


        [XmlElement("DoctoRelacionado")]
        public PagosPagoDoctoRelacionado[] DoctoRelacionado
        {
            get
            {
                return doctoRelacionadoField;
            }
            set
            {
                doctoRelacionadoField = value;
            }
        }


        public PagosPagoImpuestosP ImpuestosP
        {
            get
            {
                return impuestosPField;
            }
            set
            {
                impuestosPField = value;
            }
        }


        [XmlAttribute]
        public string FechaPago
        {
            get
            {
                return fechaPagoField;
            }
            set
            {
                fechaPagoField = value;
            }
        }


        [XmlAttribute]
        public string FormaDePagoP
        {
            get
            {
                return formaDePagoPField;
            }
            set
            {
                formaDePagoPField = value;
            }
        }


        [XmlAttribute]
        public string MonedaP
        {
            get
            {
                return monedaPField;
            }
            set
            {
                monedaPField = value;
            }
        }


        [XmlAttribute]
        public decimal TipoCambioP
        {
            get
            {
                return tipoCambioPField;
            }
            set
            {
                tipoCambioPField = value;
                tipoCambioPFieldSpecified = true;
            }
        }


        [XmlIgnore]
        public bool TipoCambioPSpecified
        {
            get
            {
                return tipoCambioPFieldSpecified;
            }
            set
            {
                tipoCambioPFieldSpecified = value;
            }
        }


        [XmlAttribute]
        public decimal Monto
        {
            get
            {
                return montoField;
            }
            set
            {
                montoField = value;
            }
        }


        [XmlAttribute]
        public string NumOperacion
        {
            get
            {
                return numOperacionField;
            }
            set
            {
                numOperacionField = value;

            }
        }


        [XmlAttribute]
        public string RfcEmisorCtaOrd
        {
            get
            {
                return rfcEmisorCtaOrdField;
            }
            set
            {
                rfcEmisorCtaOrdField = value;
            }
        }


        [XmlAttribute]
        public string NomBancoOrdExt
        {
            get
            {
                return nomBancoOrdExtField;
            }
            set
            {
                nomBancoOrdExtField = value;
            }
        }


        [XmlAttribute]
        public string CtaOrdenante
        {
            get
            {
                return ctaOrdenanteField;
            }
            set
            {
                ctaOrdenanteField = value;
            }
        }


        [XmlAttribute]
        public string RfcEmisorCtaBen
        {
            get
            {
                return rfcEmisorCtaBenField;
            }
            set
            {
                rfcEmisorCtaBenField = value;
            }
        }


        [XmlAttribute]
        public string CtaBeneficiario
        {
            get
            {
                return ctaBeneficiarioField;
            }
            set
            {
                ctaBeneficiarioField = value;
            }
        }


        [XmlAttribute]
        public string TipoCadPago
        {
            get
            {
                return tipoCadPagoField;
            }
            set
            {
                tipoCadPagoField = value;
            }
        }


        [XmlIgnore]
        public bool TipoCadPagoSpecified
        {
            get
            {
                return tipoCadPagoFieldSpecified;
            }
            set
            {
                tipoCadPagoFieldSpecified = value;
            }
        }


        [XmlAttribute(DataType = "base64Binary")]
        public byte[] CertPago
        {
            get
            {
                return certPagoField;
            }
            set
            {
                certPagoField = value;
            }
        }


        [XmlAttribute]
        public string CadPago
        {
            get
            {
                return cadPagoField;
            }
            set
            {
                cadPagoField = value;
            }
        }


        [XmlAttribute(DataType = "base64Binary")]
        public byte[] SelloPago
        {
            get
            {
                return selloPagoField;
            }
            set
            {
                selloPagoField = value;
            }
        }
    }
}