using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlDownloader.Core.Models.SatModels.Authenticate.Failure
{
	// using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Envelope)serializer.Deserialize(reader);
    // }

   // [XmlRoot(ElementName = "faultcode")]
    public class Faultcode
    {

        [XmlAttribute(AttributeName = "a")]
        public string A { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    //[XmlRoot(ElementName = "faultstring")]
    public class Faultstring
    {

        [XmlAttribute(AttributeName = "lang")]
        public string Lang { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

   // [XmlRoot(ElementName = "Fault")]
    public class Fault
    {

        [XmlElement(ElementName = "faultcode")]
        public Faultcode Faultcode { get; set; }

        [XmlElement(ElementName = "faultstring")]
        public Faultstring Faultstring { get; set; }
    }

    
    //[XmlRoot(ElementName = "Body")]
    public class Body
    {

        [XmlElement(ElementName = "Fault")]
        public Fault Fault { get; set; }
    }

    [XmlRoot(ElementName = "Envelope")]
    public class ErrorEnvelope
    {

        [XmlElement(ElementName = "Body")]
        public Body Body { get; set; }

        [XmlAttribute(AttributeName = "s")]
        public string S { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

}
