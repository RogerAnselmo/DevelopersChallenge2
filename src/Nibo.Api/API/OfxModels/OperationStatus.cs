using System.Xml.Serialization;

namespace Api.OfxModels
{
    public class OperationStatus
    {
        [XmlElement("CODE")]
        public virtual byte Code { get; set; }

        [XmlElement("SEVERITY")]
        public virtual string Serverity { get; set; }
    }
}
