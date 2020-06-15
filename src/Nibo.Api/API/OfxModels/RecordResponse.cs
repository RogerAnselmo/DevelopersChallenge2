using System.Xml.Serialization;

namespace Api.OfxModels
{
    public class RecordResponse
    {
        [XmlElement("STATUS")]
        public virtual OperationStatus Status { get; set; }

        [XmlElement("DTSERVER")]
        public virtual string DateServer { get; set; }

        [XmlElement("LANGUAGE")]
        public virtual string Language { get; set; }

    }
}
