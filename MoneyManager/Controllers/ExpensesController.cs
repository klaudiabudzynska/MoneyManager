using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Database;
using MoneyManager.Entities;
using MoneyManager.Models;
using MoneyManager.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IExpensesService _service;
        public readonly Dictionary<string, string> Categories;
        
        public ExpensesController(AppDbContext dbContext, IExpensesService service)
        {
            _dbContext = dbContext;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExpenseModel expense)
        {
            await _service.AddAsync(expense);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ExpenseModel expense)
        {
            await _service.Edit(expense);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Index(string name)
        {
            List<ExpenseEntity> expenses = await FilterExpenses(name);
            return View(expenses);
        }

        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var expense = await _dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
            if (expense == null) return View("Error");
            return View(expense);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var expense = await _dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
            if (expense == null) return View("Error");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
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
