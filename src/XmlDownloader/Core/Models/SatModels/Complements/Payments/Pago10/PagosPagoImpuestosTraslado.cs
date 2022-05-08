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

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago10;


[Serializable,
 XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos")]
public class PagosPagoImpuestosTraslado
{

    private string impuestoField;

    private string tipoFactorField;

    private decimal tasaOCuotaField;

    private decimal importeField;

    
    [XmlAttribute]
    public string Impuesto
    {
        get
        {
            return impuestoField;
        }
        set
        {
            impuestoField = value;
        }
    }

    
    [XmlAttribute]
    public string TipoFactor
    {
        get
        {
            return tipoFactorField;
        }
        set
        {
            tipoFactorField = value;
        }
    }

    
    [XmlAttribute]
    public decimal TasaOCuota
    {
        get
        {
            return tasaOCuotaField;
        }
        set
        {
            tasaOCuotaField = value;
        }
    }

    
    [XmlAttribute]
    public decimal Importe
    {
        get
        {
            return importeField;
        }
        set
        {
            importeField = value;
        }
    }
}