using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class ExpenseModel
    {
        public string Name { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Category { get; set; }
    }
}
