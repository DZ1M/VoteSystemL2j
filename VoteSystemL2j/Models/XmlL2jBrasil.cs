using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace VoteSystemL2j.Models
{
    public class XmlL2jBrasil
    {
        public static LerXmlL2jbrasil Load(XmlDocument documento)
        {
            var obj = new LerXmlL2jbrasil();
            XmlSerializer serializer = new XmlSerializer(typeof(LerXmlL2jbrasil));
            using (TextReader reader = new StringReader(documento.OuterXml))
            {
                obj = (LerXmlL2jbrasil)serializer.Deserialize(reader);
            }
            return obj;
        }

        [XmlRoot(ElementName = "votes")]
        public class LerXmlL2jbrasil
        {
            [XmlElement(ElementName = "vote")]
            public ResultL2jBrasil Voto { get; set; }
        }
        [XmlRoot(ElementName = "vote")]
        public class ResultL2jBrasil
        {
            [XmlElement(ElementName = "id")]
            public string id { get; set; }
            [XmlElement(ElementName = "site_id")]
            public string site_id { get; set; }
            [XmlElement(ElementName = "ip")]
            public string ip { get; set; }
            [XmlElement(ElementName = "date")]
            public string date { get; set; }
            [XmlElement(ElementName = "status")]
            public string status { get; set; }
            [XmlElement(ElementName = "server_time")]
            public string server_time { get; set; }
            [XmlElement(ElementName = "hours_since_vote")]
            public string hours_since_vote { get; set; }
        }
    }
}
