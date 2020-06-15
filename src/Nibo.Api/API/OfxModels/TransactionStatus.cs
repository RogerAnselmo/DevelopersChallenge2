using System.Xml.Serialization;

namespace Api.OfxModels
{
    public class TransactionStatus
    {
        [XmlElement("CODE")]
        public virtual byte Code { get; set; }

        [XmlElement("SEVERITY")]
        public virtual string Severity { get; set; }
    }
}
