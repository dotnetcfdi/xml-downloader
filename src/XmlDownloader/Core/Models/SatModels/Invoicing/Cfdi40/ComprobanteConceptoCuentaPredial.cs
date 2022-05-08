//***************************************************************************************
// <Author>                                                                             *
//     Jesús Mendoza Jaurez.                                                            *
//     mendoza.git@gmail.com                                                            *
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
    // [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
    public class ComprobanteConceptoCuentaPredial
    {
        private string numeroField;


        [XmlAttribute]
        public string Numero
        {
            get { return numeroField; }
            set { numeroField = value; }
        }
    }
}