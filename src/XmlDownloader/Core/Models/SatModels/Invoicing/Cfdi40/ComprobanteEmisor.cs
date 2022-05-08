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

namespace XmlDownloader.Core.Models.SatModels.Invoicing.Cfdi40
{
    [Serializable]
  
    public class ComprobanteEmisor
    {
        private string rfcField;

        private string nombreField;

        private string regimenFiscalField;

        private string facAtrAdquirenteField;


        [XmlAttribute]
        public string Rfc
        {
            get { return rfcField; }
            set { rfcField = value; }
        }


        [XmlAttribute]
        public string Nombre
        {
            get { return nombreField; }
            set { nombreField = value; }
        }


        [XmlAttribute]
        public string RegimenFiscal
        {
            get { return regimenFiscalField; }
            set { regimenFiscalField = value; }
        }


        [XmlAttribute]
        public string FacAtrAdquirente
        {
            get { return facAtrAdquirenteField; }
            set { facAtrAdquirenteField = value; }
        }
    }
}