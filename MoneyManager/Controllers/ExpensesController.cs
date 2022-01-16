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
        public async Task<IActionResult> Add(ExpenseModel expense)
        {
            var entity = new ExpenseEntity
            {
                Name = expense.Name,
                ExpenseDate = expense.ExpenseDate,
                Category = expense.Category,
            };

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var products = await _dbContext.Expenses.ToListAsync();
            return View(products);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
