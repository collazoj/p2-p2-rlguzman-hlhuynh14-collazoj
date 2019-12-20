using System.ComponentModel.DataAnnotations;

namespace BudgetMe.Client.Models
{
  public class Bill 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Amount { get; set; }
        public int? BudgetId { get; set; }

    }
}
