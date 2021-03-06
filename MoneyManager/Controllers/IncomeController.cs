using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
            if (ModelState.IsValid)
            {
                await _service.AddAsync(income);

                return RedirectToAction(nameof(Index));
            } 
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IncomeModel income)
        {
            if (ModelState.IsValid)
            {
                await _service.Edit(income);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(income);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index(string name)
        {
            IEnumerable<IncomeEntity> income = await _service.GetAll(name);
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

            var entity = new IncomeModel
            {
                Name = income.Name,
                Amount = income.Amount.ToString(),
                IncomeDate = income.IncomeDate
            };

            return View(entity);
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
    }
}
