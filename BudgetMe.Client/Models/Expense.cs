

using System.ComponentModel.DataAnnotations;

namespace BudgetMe.Client.Models
{
  public class Expense
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Percent { get; set; }
        public double Amount { get; set; }
        public int? BudgetId { get; set; }

    }
}
