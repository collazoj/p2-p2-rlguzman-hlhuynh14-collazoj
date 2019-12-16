using BudgetMe.Storing.Abstracts;

namespace BudgetMe.Storing.Models
{
  public class Expense : ABalance
    {
        // [Key]
        public double Percent { get; set; }
        // [ForeignKey("Budget")]
        public int? BudgetId { get; set; }

    }
}
