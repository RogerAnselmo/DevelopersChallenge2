using System.Xml.Serialization;

namespace Api.OfxModels
{
    public class Balance
    {
        [XmlElement("BALAMT")]
        public virtual decimal BalanceAmount { get; set; }

        [XmlElement("DTASOF")]
        public virtual string Date { get; set; }
    }
}
