using API.Enums;
using API.Extensions;
using System;

namespace API.Models
{
    public class Transaction: IEquatable<Transaction>
    {
        public int Id { get; set; }

        public TransactionType Type { get; set; }
        public string TypeDescription => Type.ToString();

        public DateTime DatePosted { get; set; }
        public string FormatedDate => DatePosted.ToLongDateString();

        public decimal TransactionAmount { get; set; }
        public string TransactionValue => TransactionAmount.ToCurrency();

        public string Memo { get; set; }
        
        public bool Equals(Transaction transaction) =>
            transaction != null &&
            Type == transaction.Type &&
            TransactionAmount == transaction.TransactionAmount &&
            DatePosted == transaction.DatePosted &&
            Memo == transaction.Memo;
    }
}
