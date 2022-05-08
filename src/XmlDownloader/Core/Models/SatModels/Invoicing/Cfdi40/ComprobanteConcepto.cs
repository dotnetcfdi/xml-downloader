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
   
    public class ComprobanteConcepto
    {
        private ComprobanteConceptoImpuestos impuestosField;

        private ComprobanteConceptoACuentaTerceros aCuentaTercerosField;

        private ComprobanteConceptoInformacionAduanera[] informacionAduaneraField;

        private ComprobanteConceptoCuentaPredial[] cuentaPredialField;

        private ComprobanteConceptoComplementoConcepto complementoConceptoField;

        private ComprobanteConceptoParte[] parteField;

        private string claveProdServField;

        private string noIdentificacionField;

        private decimal cantidadField;

        private string claveUnidadField;

        private string unidadField;

        private string descripcionField;

        private decimal valorUnitarioField;

        private decimal importeField;

        private decimal descuentoField;

        private bool descuentoFieldSpecified;

        private string objetoImpField;


        public ComprobanteConceptoImpuestos Impuestos
        {
            get { return impuestosField; }
            set { impuestosField = value; }
        }


        public ComprobanteConceptoACuentaTerceros ACuentaTerceros
        {
            get { return aCuentaTercerosField; }
            set { aCuentaTercerosField = value; }
        }


        [XmlElement("InformacionAduanera")]
        public ComprobanteConceptoInformacionAduanera[] InformacionAduanera
        {
            get { return informacionAduaneraField; }
            set { informacionAduaneraField = value; }
        }


        [XmlElement("CuentaPredial")]
        public ComprobanteConceptoCuentaPredial[] CuentaPredial
        {
            get { return cuentaPredialField; }
            set { cuentaPredialField = value; }
        }


        public ComprobanteConceptoComplementoConcepto ComplementoConcepto
        {
            get { return complementoConceptoField; }
            set { complementoConceptoField = value; }
        }


        [XmlElement("Parte")]
        public ComprobanteConceptoParte[] Parte
        {
            get { return parteField; }
            set { parteField = value; }
        }


        [XmlAttribute]
        public string ClaveProdServ
        {
            get { return claveProdServField; }
            set { claveProdServField = value; }
        }


        [XmlAttribute]
        public string NoIdentificacion
        {
            get { return noIdentificacionField; }
            set { noIdentificacionField = value; }
        }


        [XmlAttribute]
        public decimal Cantidad
        {
            get { return cantidadField; }
            set { cantidadField = value; }
        }


        [XmlAttribute]
        public string ClaveUnidad
        {
            get { return claveUnidadField; }
            set { claveUnidadField = value; }
        }


        [XmlAttribute]
        public string Unidad
        {
            get { return unidadField; }
            set { unidadField = value; }
        }


        [XmlAttribute]
        public string Descripcion
        {
            get { return descripcionField; }
            set { descripcionField = value; }
        }


        [XmlAttribute]
        public decimal ValorUnitario
        {
            get { return valorUnitarioField; }
            set { valorUnitarioField = value; }
        }


        [XmlAttribute]
        public decimal Importe
        {
            get { return importeField; }
            set { importeField = value; }
        }


        [XmlAttribute]
        public decimal Descuento
        {
            get { return descuentoField; }
            set { descuentoField = value; }
        }


        [XmlIgnore]
        public bool DescuentoSpecified
        {
            get { return descuentoFieldSpecified; }
            set { descuentoFieldSpecified = value; }
        }


        [XmlAttribute]
        public string ObjetoImp
        {
            get { return objetoImpField; }
            set { objetoImpField = value; }
        }
    }
}