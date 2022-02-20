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
    public class ExpensesService : IExpensesService
    {
        private readonly AppDbContext _dbContext;

        public ExpensesService(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task AddAsync(ExpenseModel expense)
        {
            var entity = new ExpenseEntity
            {
                Name = expense.Name,
                Amount = Int32.Parse(expense.Amount),
                ExpenseDate = expense.ExpenseDate,
                Category = expense.Category,
            };

            await _dbContext.Expenses.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var expense = await _dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
            _dbContext.Expenses.Remove(expense);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Edit(ExpenseModel expenseModel)
        {
            var entity = new ExpenseEntity
            {
                Name = expenseModel.Name,
                Amount = Int32.Parse(expenseModel.Amount),
                ExpenseDate = expenseModel.ExpenseDate,
                Category = expenseModel.Category,
            };

            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
