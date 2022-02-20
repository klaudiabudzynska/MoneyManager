using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Entities;

namespace MoneyManager.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<ExpenseEntity> Expenses { get; set; }
        public DbSet<IncomeEntity> Income { get; set; }
        public AppDbContext(DbContextOptions options)
        : base(options)
        {
        }

    }
}
