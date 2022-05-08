//***************************************************************************************
// <Author>                                                                             *
//     Jesús Mendoza Jaurez.                                                            *
//     mendoza.git@gmail.com                                                            *
//     https://github.com/mendozagit                                                    *
//                                                                                      *
//     Los cambios en este archivo podrían causar un comportamiento incorrecto.         *
//     Este código no ofrece ningún tipo de garantía, se generó para ayudar a la        *
//     Comunidad open source, siéntanse libre de utilizarlo, sin ninguna garantía.      *
//     Nota: Mantenga este comentario para respetar al autor.                           *
// </Author>                                                                            *
//***************************************************************************************


using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago20
{
    [Serializable]


    // [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos20")]
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
                return impuestosDRField;
            }
            set
            {
                impuestosDRField = value;
            }
        }


        [XmlAttribute]
        public string IdDocumento
        {
            get
            {
                return idDocumentoField;
            }
            set
            {
                idDocumentoField = value;
            }
        }


        [XmlAttribute]
        public string Serie
        {
            get
            {
                return serieField;
            }
            set
            {
                serieField = value;
            }
        }


        [XmlAttribute]
        public string Folio
        {
            get
            {
                return folioField;
            }
            set
            {
                folioField = value;
            }
        }


        [XmlAttribute]
        public string MonedaDR
        {
            get
            {
                return monedaDRField;
            }
            set
            {
                monedaDRField = value;
            }
        }


        [XmlAttribute]
        public decimal EquivalenciaDR
        {
            get
            {
                return equivalenciaDRField;
            }
            set
            {
                equivalenciaDRField = value;
                equivalenciaDRFieldSpecified = true;
            }
        }


        [XmlIgnore]
        public bool EquivalenciaDRSpecified
        {
            get
            {
                return equivalenciaDRFieldSpecified;
            }
            set
            {
                equivalenciaDRFieldSpecified = value;
            }
        }


        [XmlAttribute(DataType = "integer")]
        public string NumParcialidad
        {
            get
            {
                return numParcialidadField;
            }
            set
            {
                numParcialidadField = value;
            }
        }


        [XmlAttribute]
        public decimal ImpSaldoAnt
        {
            get
            {
                return impSaldoAntField;
            }
            set
            {
                impSaldoAntField = value;
            }
        }


        [XmlAttribute]
        public decimal ImpPagado
        {
            get
            {
                return impPagadoField;
            }
            set
            {
                impPagadoField = value;
            }
        }


        [XmlAttribute]
        public decimal ImpSaldoInsoluto
        {
            get
            {
                return impSaldoInsolutoField;
            }
            set
            {
                impSaldoInsolutoField = value;
            }
        }


        [XmlAttribute]
        public string ObjetoImpDR
        {
            get
            {
                return objetoImpDRField;
            }
            set
            {
                objetoImpDRField = value;
            }
        }
    }
}