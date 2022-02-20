using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Entities
{
    public class IncomeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime IncomeDate { get; set; }
        public IdentityUser Owner { get; set; }
    }
}
