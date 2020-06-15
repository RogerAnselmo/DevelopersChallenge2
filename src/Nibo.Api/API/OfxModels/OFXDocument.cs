using System.Xml.Serialization;

namespace Api.OfxModels
{
    [XmlRoot("OFX")]
    public class OfxDocument
    {
        [XmlElement("SIGNONMSGSRSV1")]
        public virtual SignonOperation Signon { get; set; }

        [XmlElement("BANKMSGSRSV1")]
        public virtual Bank Bank { get; set; }
    }
}
