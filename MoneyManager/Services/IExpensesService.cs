using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public interface IExpensesService
    {
        public Task AddAsync(ExpenseModel expense);
        public Task DeleteAsync(int id);
        public Task Edit(ExpenseModel expenseModel);
    }
}
