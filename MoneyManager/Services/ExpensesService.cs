using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ExpensesService(AppDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task AddAsync(ExpenseModel expense)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var entity = new ExpenseEntity
            {
                Name = expense.Name,
                Amount = Int32.Parse(expense.Amount),
                ExpenseDate = expense.ExpenseDate,
                Category = expense.Category,
                Owner = currentUser,
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

        public async Task Edit(ExpenseModel expense)
        {
            var dbExpense = await _dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == expense.Id);
            if (dbExpense != null)
            {
                dbExpense.Name = expense.Name;
                dbExpense.Amount = Int32.Parse(expense.Amount);
                dbExpense.ExpenseDate = expense.ExpenseDate;
                dbExpense.Category = expense.Category;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ExpenseEntity>> GetAll(string name)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            IQueryable<ExpenseEntity> expensesQuery = _dbContext.Expenses;

            expensesQuery = expensesQuery.Where(x => x.Owner == currentUser);

            if (!string.IsNullOrEmpty(name))
            {
                expensesQuery = expensesQuery.Where(x => x.Name.Contains(name));
            }

            return await expensesQuery.ToListAsync();
        }
    }
}
