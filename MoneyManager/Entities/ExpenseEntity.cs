using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Entities
{
    public class ExpenseEntity
    {
        private string _category;
        private readonly Dictionary<string, string> Categories;

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ExpenseDate { get; set; }
        public string Category
        {
            get => Categories[_category];
            set => _category = value;
        }
        public IdentityUser Owner { get; set; }

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
