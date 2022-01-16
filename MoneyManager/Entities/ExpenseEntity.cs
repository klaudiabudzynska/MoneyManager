using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Entities
{
    public class ExpenseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Category { get; set; }
    }
}
