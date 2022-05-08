using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago10;

/// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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