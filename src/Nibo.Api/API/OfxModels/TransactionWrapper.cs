using System.Xml.Serialization;

namespace Api.OfxModels
{
    public class TransactionWrapper
    {
        [XmlElement("TRNUID")]
        public virtual ushort TrnUid { get; set; }

        [XmlElement("STATUS")]
        public virtual TransactionStatus Status { get; set; }

        [XmlElement("STMTRS")]
        public virtual StatementResponse StmTrs { get; set; }
    }
}
