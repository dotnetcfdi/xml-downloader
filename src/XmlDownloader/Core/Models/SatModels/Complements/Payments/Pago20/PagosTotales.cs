using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago20
{
    [Serializable()]


    [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos20")]
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


        [XmlAttribute()]
        public decimal TotalRetencionesIVA
        {
            get
            {
                return this.totalRetencionesIVAField;
            }
            set
            {
                this.totalRetencionesIVAField = value;
            }
        }


        [XmlIgnore()]
        public bool TotalRetencionesIVASpecified
        {
            get
            {
                return this.totalRetencionesIVAFieldSpecified;
            }
            set
            {
                this.totalRetencionesIVAFieldSpecified = value;
            }
        }


        [XmlAttribute()]
        public decimal TotalRetencionesISR
        {
            get
            {
                return this.totalRetencionesISRField;
            }
            set
            {
                this.totalRetencionesISRField = value;
            }
        }


        [XmlIgnore()]
        public bool TotalRetencionesISRSpecified
        {
            get
            {
                return this.totalRetencionesISRFieldSpecified;
            }
            set
            {
                this.totalRetencionesISRFieldSpecified = value;
            }
        }


        [XmlAttribute()]
        public decimal TotalRetencionesIEPS
        {
            get
            {
                return this.totalRetencionesIEPSField;
            }
            set
            {
                this.totalRetencionesIEPSField = value;
            }
        }


        [XmlIgnore()]
        public bool TotalRetencionesIEPSSpecified
        {
            get
            {
                return this.totalRetencionesIEPSFieldSpecified;
            }
            set
            {
                this.totalRetencionesIEPSFieldSpecified = value;
            }
        }


        [XmlAttribute()]
        public decimal TotalTrasladosBaseIVA16
        {
            get
            {
                return this.totalTrasladosBaseIVA16Field;
            }
            set
            {
                this.totalTrasladosBaseIVA16Field = value;
                this.totalTrasladosBaseIVA16FieldSpecified = value > 0;
            }
        }


        [XmlIgnore()]
        public bool TotalTrasladosBaseIVA16Specified
        {
            get
            {
                return this.totalTrasladosBaseIVA16FieldSpecified;
            }
            set
            {
                this.totalTrasladosBaseIVA16FieldSpecified = value;
            }
        }


        [XmlAttribute()]
        public decimal TotalTrasladosImpuestoIVA16
        {
            get
            {
                return this.totalTrasladosImpuestoIVA16Field;
            }
            set
            {
                this.totalTrasladosImpuestoIVA16Field = value;
                this.totalTrasladosImpuestoIVA16FieldSpecified = value > 0;
            }
        }


        [XmlIgnore()]
        public bool TotalTrasladosImpuestoIVA16Specified
        {
            get
            {
                return this.totalTrasladosImpuestoIVA16FieldSpecified;
            }
            set
            {
                this.totalTrasladosImpuestoIVA16FieldSpecified = value;
            }
        }


        [XmlAttribute()]
        public decimal TotalTrasladosBaseIVA8
        {
            get
            {
                return this.totalTrasladosBaseIVA8Field;
            }
            set
            {
                this.totalTrasladosBaseIVA8Field = value;
            }
        }


        [XmlIgnore()]
        public bool TotalTrasladosBaseIVA8Specified
        {
            get
            {
                return this.totalTrasladosBaseIVA8FieldSpecified;
            }
            set
            {
                this.totalTrasladosBaseIVA8FieldSpecified = value;
            }
        }


        [XmlAttribute()]
        public decimal TotalTrasladosImpuestoIVA8
        {
            get
            {
                return this.totalTrasladosImpuestoIVA8Field;
            }
            set
            {
                this.totalTrasladosImpuestoIVA8Field = value;
            }
        }


        [XmlIgnore()]
        public bool TotalTrasladosImpuestoIVA8Specified
        {
            get
            {
                return this.totalTrasladosImpuestoIVA8FieldSpecified;
            }
            set
            {
                this.totalTrasladosImpuestoIVA8FieldSpecified = value;
            }
        }


        [XmlAttribute()]
        public decimal TotalTrasladosBaseIVA0
        {
            get
            {
                return this.totalTrasladosBaseIVA0Field;
            }
            set
            {
                this.totalTrasladosBaseIVA0Field = value;
            }
        }


        [XmlIgnore()]
        public bool TotalTrasladosBaseIVA0Specified
        {
            get
            {
                return this.totalTrasladosBaseIVA0FieldSpecified;
            }
            set
            {
                this.totalTrasladosBaseIVA0FieldSpecified = value;
            }
        }


        [XmlAttribute()]
        public decimal TotalTrasladosImpuestoIVA0
        {
            get
            {
                return this.totalTrasladosImpuestoIVA0Field;
            }
            set
            {
                this.totalTrasladosImpuestoIVA0Field = value;
            }
        }


        [XmlIgnore()]
        public bool TotalTrasladosImpuestoIVA0Specified
        {
            get
            {
                return this.totalTrasladosImpuestoIVA0FieldSpecified;
            }
            set
            {
                this.totalTrasladosImpuestoIVA0FieldSpecified = value;
            }
        }


        [XmlAttribute()]
        public decimal TotalTrasladosBaseIVAExento
        {
            get
            {
                return this.totalTrasladosBaseIVAExentoField;
            }
            set
            {
                this.totalTrasladosBaseIVAExentoField = value;
                this.totalTrasladosBaseIVAExentoFieldSpecified = value > 0;
            }
        }


        [XmlIgnore()]
        public bool TotalTrasladosBaseIVAExentoSpecified
        {
            get
            {
                return this.totalTrasladosBaseIVAExentoFieldSpecified;
            }
            set
            {
                this.totalTrasladosBaseIVAExentoFieldSpecified = value;
            }
        }


        [XmlAttribute()]
        public decimal MontoTotalPagos
        {
            get
            {
                return this.montoTotalPagosField;
            }
            set
            {
                this.montoTotalPagosField = value;
            }
        }
    }
}