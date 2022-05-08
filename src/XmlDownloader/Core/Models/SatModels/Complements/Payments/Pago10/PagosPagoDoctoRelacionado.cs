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
public class PagosPagoDoctoRelacionado
{

    private string idDocumentoField;

    private string serieField;

    private string folioField;

    private string monedaDRField;

    private decimal tipoCambioDRField;

    private bool tipoCambioDRFieldSpecified;

    private string metodoDePagoDRField;

    private string numParcialidadField;

    private decimal impSaldoAntField;

    private bool impSaldoAntFieldSpecified;

    private decimal impPagadoField;

    private bool impPagadoFieldSpecified;

    private decimal impSaldoInsolutoField;

    private bool impSaldoInsolutoFieldSpecified;

    
    [XmlAttribute]
    public string IdDocumento
    {
        get
        {
            return idDocumentoField;
        }
        set
        {
            idDocumentoField = value;
        }
    }

    
    [XmlAttribute]
    public string Serie
    {
        get
        {
            return serieField;
        }
        set
        {
            serieField = value;
        }
    }

    
    [XmlAttribute]
    public string Folio
    {
        get
        {
            return folioField;
        }
        set
        {
            folioField = value;
        }
    }

    
    [XmlAttribute]
    public string MonedaDR
    {
        get
        {
            return monedaDRField;
        }
        set
        {
            monedaDRField = value;
        }
    }

    
    [XmlAttribute]
    public decimal TipoCambioDR
    {
        get
        {
            return tipoCambioDRField;
        }
        set
        {
            tipoCambioDRField = value;
        }
    }

    
    [XmlIgnore]
    public bool TipoCambioDRSpecified
    {
        get
        {
            return tipoCambioDRFieldSpecified;
        }
        set
        {
            tipoCambioDRFieldSpecified = value;
        }
    }

    
    [XmlAttribute]
    public string MetodoDePagoDR
    {
        get
        {
            return metodoDePagoDRField;
        }
        set
        {
            metodoDePagoDRField = value;
        }
    }

    
    [XmlAttribute(DataType = "integer")]
    public string NumParcialidad
    {
        get
        {
            return numParcialidadField;
        }
        set
        {
            numParcialidadField = value;
        }
    }

    
    [XmlAttribute]
    public decimal ImpSaldoAnt
    {
        get
        {
            return impSaldoAntField;
        }
        set
        {
            impSaldoAntField = value;
        }
    }

    
    [XmlIgnore]
    public bool ImpSaldoAntSpecified
    {
        get
        {
            return impSaldoAntFieldSpecified;
        }
        set
        {
            impSaldoAntFieldSpecified = value;
        }
    }

    
    [XmlAttribute]
    public decimal ImpPagado
    {
        get
        {
            return impPagadoField;
        }
        set
        {
            impPagadoField = value;
        }
    }

    
    [XmlIgnore]
    public bool ImpPagadoSpecified
    {
        get
        {
            return impPagadoFieldSpecified;
        }
        set
        {
            impPagadoFieldSpecified = value;
        }
    }

    
    [XmlAttribute]
    public decimal ImpSaldoInsoluto
    {
        get
        {
            return impSaldoInsolutoField;
        }
        set
        {
            impSaldoInsolutoField = value;
        }
    }

    
    [XmlIgnore]
    public bool ImpSaldoInsolutoSpecified
    {
        get
        {
            return impSaldoInsolutoFieldSpecified;
        }
        set
        {
            impSaldoInsolutoFieldSpecified = value;
        }
    }
}