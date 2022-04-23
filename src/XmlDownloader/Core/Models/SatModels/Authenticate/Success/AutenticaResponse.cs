using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Authenticate.Success;


public class AutenticaResponse
{
    [XmlElement(ElementName = "AutenticaResult")]
    public string AutenticaResult { get; set; }

    [XmlAttribute(AttributeName = "xmlns")]
    public string Xmlns { get; set; }

    [XmlText] public string Text { get; set; }
}