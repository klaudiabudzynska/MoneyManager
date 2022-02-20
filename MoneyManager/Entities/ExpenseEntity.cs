using MoneyManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Entities
{
    public class ExpenseEntity
    {
        private string _category;
        private readonly Dictionary<string, string> Categories;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Category
        {
            get => Categories[_category];
            set => _category = value;
        }

        public ExpenseEntity ()
        {
            Categories = new Dictionary<string, string>(){
                {"food", "Jedzenie"},
                {"transport", "Transport"},
                {"medications", "Leki"},
                {"apartment", "Mieszkanie"},
                {"entertainment", "Rozrywka"},
                {"others", "Inne"}
            };
        }
    }
}
