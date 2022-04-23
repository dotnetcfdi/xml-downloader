using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Authenticate.Success;

public class Header
{
    [XmlElement(ElementName = "Security")] public Security Security { get; set; }
}