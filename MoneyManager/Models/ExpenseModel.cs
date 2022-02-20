using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [RegularExpression(@"\d*\.?\d{1,2}?", ErrorMessage = "Niepoprawny format")]
        public string Amount { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public DateTime ExpenseDate { get; set; }

        public string Category { get; set; }
    }
}
