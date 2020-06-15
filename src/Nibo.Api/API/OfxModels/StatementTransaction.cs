using System.Xml.Serialization;

namespace Api.OfxModels
{
    public class StatementTransaction
    {
        [XmlElement("TRNTYPE")]
        public virtual string TransactionType { get; set; }

        [XmlElement("DTPOSTED")]
        public virtual string DatePosted { get; set; }

        [XmlElement("TRNAMT")]
        public virtual decimal TransactionAmount { get; set; }

        [XmlElement("MEMO")]
        public virtual string Memo { get; set; }
    }
}
