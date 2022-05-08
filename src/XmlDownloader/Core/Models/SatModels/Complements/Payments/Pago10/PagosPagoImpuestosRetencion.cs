using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Complements.Payments.Pago10;

/// <remarks/>
[Serializable,
 XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/Pagos")]
public class PagosPagoImpuestosRetencion
{

    private string impuestoField;

    private decimal importeField;

    /// <remarks/>
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

    /// <remarks/>
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