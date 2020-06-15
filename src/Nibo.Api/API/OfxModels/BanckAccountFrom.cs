using System.Xml.Serialization;

namespace Api.OfxModels
{
    public class BanckAccountFrom
    {
        [XmlElement("BANKID")]
        public virtual ushort BankId { get; set; }

        [XmlElement("ACCTID")]
        public virtual ulong AccountId { get; set; }

        [XmlElement("ACCTTYPE")]
        public virtual string AccountType { get; set; }
    }
}
