//*********************************************************************************
// <Author>
//     Jesús Mendoza Jaurez. 
//     mendoza.git@gmail.com
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto.

//     Este código no ofrece ningún tipo de garantía, se generó para ayudar a la 
//     Comunidad open source, siéntanse libre de utilizarlo, sin ninguna garantía.
//     Nota: Mantenga este comentario para respetar al autor.
// </Author>
//*********************************************************************************


using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.TFD
{
    [System.Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
    [XmlRoot(Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital", IsNullable = false)]
    public partial class TimbreFiscalDigital
    {

        private string versionField;

        private string uUIDField;

        private System.DateTime fechaTimbradoField;

        private string rfcProvCertifField;

        private string leyendaField;

        private string selloCFDField;

        private string noCertificadoSATField;

        private string selloSATField;

        public TimbreFiscalDigital()
        {
            this.versionField = "1.1";
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string UUID
        {
            get
            {
                return this.uUIDField;
            }
            set
            {
                this.uUIDField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public System.DateTime FechaTimbrado
        {
            get
            {
                return this.fechaTimbradoField;
            }
            set
            {
                this.fechaTimbradoField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string RfcProvCertif
        {
            get
            {
                return this.rfcProvCertifField;
            }
            set
            {
                this.rfcProvCertifField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Leyenda
        {
            get
            {
                return this.leyendaField;
            }
            set
            {
                this.leyendaField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string SelloCFD
        {
            get
            {
                return this.selloCFDField;
            }
            set
            {
                this.selloCFDField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string NoCertificadoSAT
        {
            get
            {
                return this.noCertificadoSATField;
            }
            set
            {
                this.noCertificadoSATField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string SelloSAT
        {
            get
            {
                return this.selloSATField;
            }
            set
            {
                this.selloSATField = value;
            }
        }
    }

}
