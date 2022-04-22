using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Authenticate;

[XmlRoot(ElementName = "AutenticaResponse")]
public class AutenticaResponse
{
    [XmlElement(ElementName = "AutenticaResult")]
    public string AutenticaResult { get; set; }

    [XmlAttribute(AttributeName = "xmlns")]
    public string Xmlns { get; set; }

    [XmlText] public string Text { get; set; }
}