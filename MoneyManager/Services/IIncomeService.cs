using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public interface IIncomeService
    {
        public Task AddAsync(IncomeModel income);
        public Task DeleteAsync(int id);
        public Task Edit(IncomeModel income);
    }
}
