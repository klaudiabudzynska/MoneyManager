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
    public class IncomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IIncomeService _service;
        public readonly Dictionary<string, string> Categories;

        public IncomeController(AppDbContext dbContext, IIncomeService service)
        {
            _dbContext = dbContext;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(IncomeModel income)
        {
            await _service.AddAsync(income);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IncomeModel income)
        {
            await _service.Edit(income);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Index(string name)
        {
            List<IncomeEntity> income = await FilterIncome(name);
            return View(income);
        }

        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var income = await _dbContext.Income.FirstOrDefaultAsync(e => e.Id == id);
            if (income == null) return View("Error");
            return View(income);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var income = await _dbContext.Income.FirstOrDefaultAsync(e => e.Id == id);
            if (income == null) return View("Error");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Index()
        {
            return View();
        }

        private async Task<List<IncomeEntity>> FilterIncome(string name)
        {
            IQueryable<IncomeEntity> incomeQuery = _dbContext.Income;
            if (!string.IsNullOrEmpty(name))
            {
                incomeQuery = incomeQuery.Where(x => x.Name.Contains(name));
            }
            return await incomeQuery.ToListAsync();
        }
    }
}
