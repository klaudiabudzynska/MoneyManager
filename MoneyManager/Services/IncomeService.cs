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
    public class IncomeService : IIncomeService
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public IncomeService(AppDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(IncomeModel income)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var entity = new IncomeEntity
            {
                Name = income.Name,
                Amount = decimal.Parse(income.Amount),
                IncomeDate = income.IncomeDate,
                Owner = currentUser,
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
                dbIncome.Amount = decimal.Parse(income.Amount);
                dbIncome.IncomeDate = income.IncomeDate;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<IncomeEntity>> GetAll(string name)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            IQueryable<IncomeEntity> incomeQuery = _dbContext.Income;

            incomeQuery = incomeQuery.Where(x => x.Owner == currentUser);

            if (!string.IsNullOrEmpty(name))
            {
                incomeQuery = incomeQuery.Where(x => x.Name.Contains(name));
            }

            return await incomeQuery.ToListAsync();
        }
    }
}
