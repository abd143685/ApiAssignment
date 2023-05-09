using APIv2.Models;
using Microsoft.EntityFrameworkCore;

namespace APIv2.Data
{
    public class AccountsContext: DbContext
    {
        public AccountsContext(DbContextOptions<AccountsContext> options) : base(options)
        {

        }
        public DbSet<Accounts> account { get; set; }
    }
}
