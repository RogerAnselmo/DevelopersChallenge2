using API.Models;
using API.Repositories.Context;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>
    {
        public TransactionRepository(NiboContext db)
            : base(db) { }

        public virtual IEnumerable<Transaction> VerifyNewTransactions(IEnumerable<Transaction> transactions) => 
            transactions.Where(x => !DbSet.Contains(x));
    }
}
