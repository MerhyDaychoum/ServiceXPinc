using Microsoft.EntityFrameworkCore;
using ServiceXPinc.Models;

namespace ServiceXPinc.DatabaseContext
{
    public class XPDatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "XPDatabase");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerInvestment> CustomerInvestments { get; set; }
        public DbSet<InvestmentProduct> InvestmentProducts { get; set; }
    }
}
