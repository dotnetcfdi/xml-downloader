using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Authenticate;

[XmlRoot(ElementName = "Header")]
public class Header
{
    [XmlElement(ElementName = "Security")] public Security Security { get; set; }
}