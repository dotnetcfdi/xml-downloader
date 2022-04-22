using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Authenticate;

[XmlRoot(ElementName = "Timestamp")]
public class Timestamp
{
    [XmlElement(ElementName = "Created")] public DateTime Created { get; set; }

    [XmlElement(ElementName = "Expires")] public DateTime Expires { get; set; }

    [XmlAttribute(AttributeName = "Id")] public string Id { get; set; }

    [XmlText] public string Text { get; set; }
}