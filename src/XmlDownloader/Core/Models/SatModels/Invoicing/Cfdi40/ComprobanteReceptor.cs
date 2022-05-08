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
    public class ComprobanteReceptor
    {
        private string rfcField;

        private string nombreField;

        private string domicilioFiscalReceptorField;

        private string residenciaFiscalField;

        private bool residenciaFiscalFieldSpecified;

        private string numRegIdTribField;

        private string regimenFiscalReceptorField;

        private string usoCFDIField;


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
        public string DomicilioFiscalReceptor
        {
            get { return domicilioFiscalReceptorField; }
            set { domicilioFiscalReceptorField = value; }
        }


        [XmlAttribute]
        public string ResidenciaFiscal
        {
            get { return residenciaFiscalField; }
            set { residenciaFiscalField = value; }
        }


        [XmlIgnore]
        public bool ResidenciaFiscalSpecified
        {
            get { return residenciaFiscalFieldSpecified; }
            set { residenciaFiscalFieldSpecified = value; }
        }


        [XmlAttribute]
        public string NumRegIdTrib
        {
            get { return numRegIdTribField; }
            set { numRegIdTribField = value; }
        }


        [XmlAttribute]
        public string RegimenFiscalReceptor
        {
            get { return regimenFiscalReceptorField; }
            set { regimenFiscalReceptorField = value; }
        }


        [XmlAttribute]
        public string UsoCFDI
        {
            get { return usoCFDIField; }
            set { usoCFDIField = value; }
        }
    }
}