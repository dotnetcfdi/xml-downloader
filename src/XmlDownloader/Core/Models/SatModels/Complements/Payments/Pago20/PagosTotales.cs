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
    public  class PagosTotales
    {

        private decimal totalRetencionesIVAField;

        private bool totalRetencionesIVAFieldSpecified;

        private decimal totalRetencionesISRField;

        private bool totalRetencionesISRFieldSpecified;

        private decimal totalRetencionesIEPSField;

        private bool totalRetencionesIEPSFieldSpecified;

        private decimal totalTrasladosBaseIVA16Field;

        private bool totalTrasladosBaseIVA16FieldSpecified;

        private decimal totalTrasladosImpuestoIVA16Field;

        private bool totalTrasladosImpuestoIVA16FieldSpecified;

        private decimal totalTrasladosBaseIVA8Field;

        private bool totalTrasladosBaseIVA8FieldSpecified;

        private decimal totalTrasladosImpuestoIVA8Field;

        private bool totalTrasladosImpuestoIVA8FieldSpecified;

        private decimal totalTrasladosBaseIVA0Field;

        private bool totalTrasladosBaseIVA0FieldSpecified;

        private decimal totalTrasladosImpuestoIVA0Field;

        private bool totalTrasladosImpuestoIVA0FieldSpecified;

        private decimal totalTrasladosBaseIVAExentoField;

        private bool totalTrasladosBaseIVAExentoFieldSpecified;

        private decimal montoTotalPagosField;


        [XmlAttribute]
        public decimal TotalRetencionesIVA
        {
            get
            {
                return totalRetencionesIVAField;
            }
            set
            {
                totalRetencionesIVAField = value;
            }
        }


        [XmlIgnore]
        public bool TotalRetencionesIVASpecified
        {
            get
            {
                return totalRetencionesIVAFieldSpecified;
            }
            set
            {
                totalRetencionesIVAFieldSpecified = value;
            }
        }


        [XmlAttribute]
        public decimal TotalRetencionesISR
        {
            get
            {
                return totalRetencionesISRField;
            }
            set
            {
                totalRetencionesISRField = value;
            }
        }


        [XmlIgnore]
        public bool TotalRetencionesISRSpecified
        {
            get
            {
                return totalRetencionesISRFieldSpecified;
            }
            set
            {
                totalRetencionesISRFieldSpecified = value;
            }
        }


        [XmlAttribute]
        public decimal TotalRetencionesIEPS
        {
            get
            {
                return totalRetencionesIEPSField;
            }
            set
            {
                totalRetencionesIEPSField = value;
            }
        }


        [XmlIgnore]
        public bool TotalRetencionesIEPSSpecified
        {
            get
            {
                return totalRetencionesIEPSFieldSpecified;
            }
            set
            {
                totalRetencionesIEPSFieldSpecified = value;
            }
        }


        [XmlAttribute]
        public decimal TotalTrasladosBaseIVA16
        {
            get
            {
                return totalTrasladosBaseIVA16Field;
            }
            set
            {
                totalTrasladosBaseIVA16Field = value;
                totalTrasladosBaseIVA16FieldSpecified = value > 0;
            }
        }


        [XmlIgnore]
        public bool TotalTrasladosBaseIVA16Specified
        {
            get
            {
                return totalTrasladosBaseIVA16FieldSpecified;
            }
            set
            {
                totalTrasladosBaseIVA16FieldSpecified = value;
            }
        }


        [XmlAttribute]
        public decimal TotalTrasladosImpuestoIVA16
        {
            get
            {
                return totalTrasladosImpuestoIVA16Field;
            }
            set
            {
                totalTrasladosImpuestoIVA16Field = value;
                totalTrasladosImpuestoIVA16FieldSpecified = value > 0;
            }
        }


        [XmlIgnore]
        public bool TotalTrasladosImpuestoIVA16Specified
        {
            get
            {
                return totalTrasladosImpuestoIVA16FieldSpecified;
            }
            set
            {
                totalTrasladosImpuestoIVA16FieldSpecified = value;
            }
        }


        [XmlAttribute]
        public decimal TotalTrasladosBaseIVA8
        {
            get
            {
                return totalTrasladosBaseIVA8Field;
            }
            set
            {
                totalTrasladosBaseIVA8Field = value;
            }
        }


        [XmlIgnore]
        public bool TotalTrasladosBaseIVA8Specified
        {
            get
            {
                return totalTrasladosBaseIVA8FieldSpecified;
            }
            set
            {
                totalTrasladosBaseIVA8FieldSpecified = value;
            }
        }


        [XmlAttribute]
        public decimal TotalTrasladosImpuestoIVA8
        {
            get
            {
                return totalTrasladosImpuestoIVA8Field;
            }
            set
            {
                totalTrasladosImpuestoIVA8Field = value;
            }
        }


        [XmlIgnore]
        public bool TotalTrasladosImpuestoIVA8Specified
        {
            get
            {
                return totalTrasladosImpuestoIVA8FieldSpecified;
            }
            set
            {
                totalTrasladosImpuestoIVA8FieldSpecified = value;
            }
        }


        [XmlAttribute]
        public decimal TotalTrasladosBaseIVA0
        {
            get
            {
                return totalTrasladosBaseIVA0Field;
            }
            set
            {
                totalTrasladosBaseIVA0Field = value;
            }
        }


        [XmlIgnore]
        public bool TotalTrasladosBaseIVA0Specified
        {
            get
            {
                return totalTrasladosBaseIVA0FieldSpecified;
            }
            set
            {
                totalTrasladosBaseIVA0FieldSpecified = value;
            }
        }


        [XmlAttribute]
        public decimal TotalTrasladosImpuestoIVA0
        {
            get
            {
                return totalTrasladosImpuestoIVA0Field;
            }
            set
            {
                totalTrasladosImpuestoIVA0Field = value;
            }
        }


        [XmlIgnore]
        public bool TotalTrasladosImpuestoIVA0Specified
        {
            get
            {
                return totalTrasladosImpuestoIVA0FieldSpecified;
            }
            set
            {
                totalTrasladosImpuestoIVA0FieldSpecified = value;
            }
        }


        [XmlAttribute]
        public decimal TotalTrasladosBaseIVAExento
        {
            get
            {
                return totalTrasladosBaseIVAExentoField;
            }
            set
            {
                totalTrasladosBaseIVAExentoField = value;
                totalTrasladosBaseIVAExentoFieldSpecified = value > 0;
            }
        }


        [XmlIgnore]
        public bool TotalTrasladosBaseIVAExentoSpecified
        {
            get
            {
                return totalTrasladosBaseIVAExentoFieldSpecified;
            }
            set
            {
                totalTrasladosBaseIVAExentoFieldSpecified = value;
            }
        }


        [XmlAttribute]
        public decimal MontoTotalPagos
        {
            get
            {
                return montoTotalPagosField;
            }
            set
            {
                montoTotalPagosField = value;
            }
        }
    }
}