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
    [Serializable, XmlRoot(Namespace = "http://www.sat.gob.mx/Pagos20", IsNullable = false)]
    // [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos20")]
    public  class Pagos {
    
        private PagosTotales totalesField;
    
        private PagosPago[] pagoField;
    
        private string versionField;
    
        public Pagos() {
            versionField = "2.0";
        }
    
    
        public PagosTotales Totales {
            get {
                return totalesField;
            }
            set {
                totalesField = value;
            }
        }
    
    
        [XmlElement("Pago")]
        public PagosPago[] Pago {
            get {
                return pagoField;
            }
            set {
                pagoField = value;
            }
        }
    
    
        [XmlAttribute]
        public string Version {
            get {
                return versionField;
            }
            set {
                versionField = value;
            }
        }
    }
}