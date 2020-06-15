using System.Xml.Serialization;

namespace Api.OfxModels
{
    public class StatementResponse
    {
        [XmlElement("CURDEF")]
        public virtual string CurDef { get; set; }

        [XmlElement("BANKACCTFROM")]
        public virtual BanckAccountFrom AcctFrom { get; set; }

        [XmlElement("BANKTRANLIST")]
        public virtual StatementTransactionData TranList { get; set; }

        [XmlElement("LEDGERBAL")]
        public virtual Balance LedgerBalance { get; set; }
    }
}
