using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago10;

/// <remarks/>
[Serializable,
 XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos")]
public class PagosPago
{

    private PagosPagoDoctoRelacionado[] doctoRelacionadoField;

    private PagosPagoImpuestos[] impuestosField;

    private DateTime fechaPagoField;

    private string formaDePagoPField;

    private string monedaPField;

    private decimal tipoCambioPField;

    private bool tipoCambioPFieldSpecified;

    private decimal montoField;

    private string numOperacionField;

    private string rfcEmisorCtaOrdField;

    private string nomBancoOrdExtField;

    private string ctaOrdenanteField;

    private string rfcEmisorCtaBenField;

    private string ctaBeneficiarioField;

    private string tipoCadPagoField;

    private bool tipoCadPagoFieldSpecified;

    private byte[] certPagoField;

    private string cadPagoField;

    private byte[] selloPagoField;

    /// <remarks/>
    [XmlElement("DoctoRelacionado")]
    public PagosPagoDoctoRelacionado[] DoctoRelacionado
    {
        get
        {
            return doctoRelacionadoField;
        }
        set
        {
            doctoRelacionadoField = value;
        }
    }

    /// <remarks/>
    [XmlElement("Impuestos")]
    public PagosPagoImpuestos[] Impuestos
    {
        get
        {
            return impuestosField;
        }
        set
        {
            impuestosField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute]
    public DateTime FechaPago
    {
        get
        {
            return fechaPagoField;
        }
        set
        {
            fechaPagoField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute]
    public string FormaDePagoP
    {
        get
        {
            return formaDePagoPField;
        }
        set
        {
            formaDePagoPField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute]
    public string MonedaP
    {
        get
        {
            return monedaPField;
        }
        set
        {
            monedaPField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute]
    public decimal TipoCambioP
    {
        get
        {
            return tipoCambioPField;
        }
        set
        {
            tipoCambioPField = value;
        }
    }

    /// <remarks/>
    [XmlIgnore]
    public bool TipoCambioPSpecified
    {
        get
        {
            return tipoCambioPFieldSpecified;
        }
        set
        {
            tipoCambioPFieldSpecified = value;
        }
    }

    /// <remarks/>
    [XmlAttribute]
    public decimal Monto
    {
        get
        {
            return montoField;
        }
        set
        {
            montoField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute]
    public string NumOperacion
    {
        get
        {
            return numOperacionField;
        }
        set
        {
            numOperacionField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute]
    public string RfcEmisorCtaOrd
    {
        get
        {
            return rfcEmisorCtaOrdField;
        }
        set
        {
            rfcEmisorCtaOrdField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute]
    public string NomBancoOrdExt
    {
        get
        {
            return nomBancoOrdExtField;
        }
        set
        {
            nomBancoOrdExtField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute]
    public string CtaOrdenante
    {
        get
        {
            return ctaOrdenanteField;
        }
        set
        {
            ctaOrdenanteField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute]
    public string RfcEmisorCtaBen
    {
        get
        {
            return rfcEmisorCtaBenField;
        }
        set
        {
            rfcEmisorCtaBenField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute]
    public string CtaBeneficiario
    {
        get
        {
            return ctaBeneficiarioField;
        }
        set
        {
            ctaBeneficiarioField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute]
    public string TipoCadPago
    {
        get
        {
            return tipoCadPagoField;
        }
        set
        {
            tipoCadPagoField = value;
        }
    }

    /// <remarks/>
    [XmlIgnore]
    public bool TipoCadPagoSpecified
    {
        get
        {
            return tipoCadPagoFieldSpecified;
        }
        set
        {
            tipoCadPagoFieldSpecified = value;
        }
    }

    /// <remarks/>
    [XmlAttribute(DataType = "base64Binary")]
    public byte[] CertPago
    {
        get
        {
            return certPagoField;
        }
        set
        {
            certPagoField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute]
    public string CadPago
    {
        get
        {
            return cadPagoField;
        }
        set
        {
            cadPagoField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute(DataType = "base64Binary")]
    public byte[] SelloPago
    {
        get
        {
            return selloPagoField;
        }
        set
        {
            selloPagoField = value;
        }
    }
}