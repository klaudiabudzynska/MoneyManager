using Microsoft.EntityFrameworkCore;
using MoneyManager.Database;
using MoneyManager.Entities;
using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly AppDbContext _dbContext;

        public IncomeService(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task AddAsync(IncomeModel income)
        {
            var entity = new IncomeEntity
            {
                Name = income.Name,
                Amount = Int32.Parse(income.Amount),
                IncomeDate = income.IncomeDate,
            };

            await _dbContext.Income.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var income = await _dbContext.Income.FirstOrDefaultAsync(e => e.Id == id);
            _dbContext.Income.Remove(income);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Edit(IncomeModel income)
        {
            var dbIncome = await _dbContext.Income.FirstOrDefaultAsync(e => e.Id == income.Id);
            if (dbIncome != null)
            {
                dbIncome.Name = income.Name;
                dbIncome.Amount = Int32.Parse(income.Amount);
                dbIncome.IncomeDate = income.IncomeDate;

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
