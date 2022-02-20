using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class IncomeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [RegularExpression(@"\d*\.?\d{1,2}?", ErrorMessage = "Niepoprawny format")]
        public string Amount { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public DateTime IncomeDate { get; set; }
    }
}
