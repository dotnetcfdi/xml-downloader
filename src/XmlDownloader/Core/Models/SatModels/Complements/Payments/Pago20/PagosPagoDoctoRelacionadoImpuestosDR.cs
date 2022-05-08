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
    [Serializable, XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos20")]
    public  class PagosPagoDoctoRelacionadoImpuestosDR {
    
        private PagosPagoDoctoRelacionadoImpuestosDRRetencionDR[] retencionesDRField;
    
        private PagosPagoDoctoRelacionadoImpuestosDRTrasladoDR[] trasladosDRField;
    
    
        [XmlArrayItem("RetencionDR", IsNullable=false)]
        public PagosPagoDoctoRelacionadoImpuestosDRRetencionDR[] RetencionesDR {
            get {
                return retencionesDRField;
            }
            set {
                retencionesDRField = value;
            }
        }
    
    
        [XmlArrayItem("TrasladoDR", IsNullable=false)]
        public PagosPagoDoctoRelacionadoImpuestosDRTrasladoDR[] TrasladosDR {
            get {
                return trasladosDRField;
            }
            set {
                trasladosDRField = value;
            }
        }
    }
}