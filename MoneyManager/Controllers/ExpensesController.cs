using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Database;
using MoneyManager.Entities;
using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly AppDbContext _dbContext;
        public ExpensesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Index(ExpenseModel expense)
        {
            var entity = new ExpenseEntity
            {
                Name = expense.Name,
                ExpenseDate = expense.ExpenseDate,
                Category = expense.Category,
            };

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            var expenses = await FilterExpenses("");
            return View(expenses);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string name)
        {
            var expenses = await FilterExpenses(name);
            return View(expenses);
        }


        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        private async Task<List<ExpenseEntity>> FilterExpenses(string name)
        {
            IQueryable<ExpenseEntity> expensesQuery = _dbContext.Expenses;
            if (!string.IsNullOrEmpty(name))
            {
                expensesQuery = expensesQuery.Where(x => x.Name.Contains(name));
            }
            return await expensesQuery.ToListAsync();
        }
    }
}
