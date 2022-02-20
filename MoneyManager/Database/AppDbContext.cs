using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Entities;

namespace MoneyManager.Database
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<ExpenseEntity> Expenses { get; set; }
        public DbSet<IncomeEntity> Income { get; set; }
        public AppDbContext(DbContextOptions options)
        : base(options)
        {
        }

    }
}
