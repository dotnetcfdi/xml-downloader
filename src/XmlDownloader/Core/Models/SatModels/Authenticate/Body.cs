using System.Xml.Serialization;


namespace XmlDownloader.Core.Models.SatModels.Authenticate;

[XmlRoot(ElementName = "Body")]
public class Body
{
    [XmlElement(ElementName = "AutenticaResponse")]
    public AutenticaResponse AutenticaResponse { get; set; }
}