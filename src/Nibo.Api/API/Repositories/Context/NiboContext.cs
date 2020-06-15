using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Context
{
    public class NiboContext: DbContext
    {
        public NiboContext() { }
        public NiboContext(DbContextOptions options) : base(options) { }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
