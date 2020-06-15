using System.Xml.Serialization;

namespace Api.OfxModels
{
    public class StatementTransactionData
    {
        [XmlElement("DTSTART")]
        public virtual string DateStart { get; set; }

        [XmlElement("DTEND")]
        public virtual string DateEnd { get; set; }

        [XmlElement("STMTTRN")]
        public virtual StatementTransaction[] Transactions { get; set; }
    }
}
