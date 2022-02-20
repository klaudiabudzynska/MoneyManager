using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Category { get; set; }
    }
}
