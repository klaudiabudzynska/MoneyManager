using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Database;
using MoneyManager.Entities;
using MoneyManager.Models;
using MoneyManager.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Controllers
{
    [Authorize]
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
            if (ModelState.IsValid)
            {
                await _service.AddAsync(expense);

                return RedirectToAction(nameof(Index));
            } 
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ExpenseModel expense)
        {
            if (ModelState.IsValid)
            {
                await _service.Edit(expense);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(expense);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index(string name)
        {
            IEnumerable<ExpenseEntity> expenses = await _service.GetAll(name);
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

            var entity = new ExpenseModel
            {
                Name = expense.Name,
                Amount = expense.Amount.ToString(),
                ExpenseDate = expense.ExpenseDate
            };

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
    }
}
