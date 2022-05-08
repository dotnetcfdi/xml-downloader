using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago10;

/// <remarks/>
[Serializable,
 XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos")]
public class PagosPagoImpuestos
{

    private PagosPagoImpuestosRetencion[] retencionesField;

    private PagosPagoImpuestosTraslado[] trasladosField;

    private decimal totalImpuestosRetenidosField;

    private bool totalImpuestosRetenidosFieldSpecified;

    private decimal totalImpuestosTrasladadosField;

    private bool totalImpuestosTrasladadosFieldSpecified;

    /// <remarks/>
    [XmlArrayItem("Retencion", IsNullable = false)]
    public PagosPagoImpuestosRetencion[] Retenciones
    {
        get
        {
            return retencionesField;
        }
        set
        {
            retencionesField = value;
        }
    }

    /// <remarks/>
    [XmlArrayItem("Traslado", IsNullable = false)]
    public PagosPagoImpuestosTraslado[] Traslados
    {
        get
        {
            return trasladosField;
        }
        set
        {
            trasladosField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute]
    public decimal TotalImpuestosRetenidos
    {
        get
        {
            return totalImpuestosRetenidosField;
        }
        set
        {
            totalImpuestosRetenidosField = value;
        }
    }

    /// <remarks/>
    [XmlIgnore]
    public bool TotalImpuestosRetenidosSpecified
    {
        get
        {
            return totalImpuestosRetenidosFieldSpecified;
        }
        set
        {
            totalImpuestosRetenidosFieldSpecified = value;
        }
    }

    /// <remarks/>
    [XmlAttribute]
    public decimal TotalImpuestosTrasladados
    {
        get
        {
            return totalImpuestosTrasladadosField;
        }
        set
        {
            totalImpuestosTrasladadosField = value;
        }
    }

    /// <remarks/>
    [XmlIgnore]
    public bool TotalImpuestosTrasladadosSpecified
    {
        get
        {
            return totalImpuestosTrasladadosFieldSpecified;
        }
        set
        {
            totalImpuestosTrasladadosFieldSpecified = value;
        }
    }
}