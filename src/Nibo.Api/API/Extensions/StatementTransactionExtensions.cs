using Api.OfxModels;
using API.Enums;
using API.Models;

namespace API.Extensions
{
    public static class StatementTransactionExtensions
    {
        public static Transaction ToTransaction(this StatementTransaction transactionDto) =>
            new Transaction
            {
                Memo = transactionDto.Memo,
                TransactionAmount = transactionDto.TransactionAmount,
                Type = transactionDto.TransactionType.ToUpper().Trim() == "CREDIT" ? TransactionType.Credit : TransactionType.Debit,
                DatePosted = transactionDto.DatePosted.ConvertOfxDateToDateTime()
            };
    }
}
