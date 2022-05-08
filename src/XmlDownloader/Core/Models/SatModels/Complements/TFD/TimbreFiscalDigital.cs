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
    [Serializable, XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital"),
     XmlRoot(Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital", IsNullable = false)]
    public class TimbreFiscalDigital
    {

        private string versionField;

        private string uUIDField;

        private DateTime fechaTimbradoField;

        private string rfcProvCertifField;

        private string leyendaField;

        private string selloCFDField;

        private string noCertificadoSATField;

        private string selloSATField;

        public TimbreFiscalDigital()
        {
            versionField = "1.1";
        }

        /// <remarks/>
        [XmlAttribute]
        public string Version
        {
            get
            {
                return versionField;
            }
            set
            {
                versionField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string UUID
        {
            get
            {
                return uUIDField;
            }
            set
            {
                uUIDField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public DateTime FechaTimbrado
        {
            get
            {
                return fechaTimbradoField;
            }
            set
            {
                fechaTimbradoField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string RfcProvCertif
        {
            get
            {
                return rfcProvCertifField;
            }
            set
            {
                rfcProvCertifField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Leyenda
        {
            get
            {
                return leyendaField;
            }
            set
            {
                leyendaField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string SelloCFD
        {
            get
            {
                return selloCFDField;
            }
            set
            {
                selloCFDField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string NoCertificadoSAT
        {
            get
            {
                return noCertificadoSATField;
            }
            set
            {
                noCertificadoSATField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string SelloSAT
        {
            get
            {
                return selloSATField;
            }
            set
            {
                selloSATField = value;
            }
        }
    }

}
