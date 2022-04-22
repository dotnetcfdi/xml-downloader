using System.Xml.Serialization;


namespace XmlDownloader.Core.Models.SatModels.Authenticate;

[XmlRoot(ElementName = "Envelope")]
public class AuthenticateEnvelope
{
    [XmlElement(ElementName = "Header")] public Header Header { get; set; }

    [XmlElement(ElementName = "Body")] public Body Body { get; set; }

    [XmlAttribute(AttributeName = "s")] public string S { get; set; }

    [XmlAttribute(AttributeName = "u")] public string U { get; set; }

    [XmlText] public string Text { get; set; }
}