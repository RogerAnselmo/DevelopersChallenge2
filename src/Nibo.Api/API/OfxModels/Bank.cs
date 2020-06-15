using System.Xml.Serialization;

namespace Api.OfxModels
{
    public class Bank
    {
        [XmlElement("STMTTRNRS")]
        public virtual TransactionWrapper TransactionWrapper { get; set; }
    }
}
