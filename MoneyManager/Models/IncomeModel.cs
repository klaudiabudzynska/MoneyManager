using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class IncomeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public DateTime IncomeDate { get; set; }
    }
}
