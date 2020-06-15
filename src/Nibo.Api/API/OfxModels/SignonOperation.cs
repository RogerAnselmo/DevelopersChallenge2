using System.Xml.Serialization;

namespace Api.OfxModels
{

    public class SignonOperation
    {
        [XmlElement("SONRS")]
        public virtual RecordResponse RecordResponse { get; set; }
    }
}
