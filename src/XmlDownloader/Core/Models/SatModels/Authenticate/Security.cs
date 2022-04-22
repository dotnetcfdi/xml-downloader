using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Authenticate;

[XmlRoot(ElementName = "Security")]
public class Security
{
    [XmlElement(ElementName = "Timestamp")]
    public Timestamp Timestamp { get; set; }

    [XmlAttribute(AttributeName = "mustUnderstand")]
    public int MustUnderstand { get; set; }

    [XmlAttribute(AttributeName = "o")] public string O { get; set; }

    [XmlText] public string Text { get; set; }
}