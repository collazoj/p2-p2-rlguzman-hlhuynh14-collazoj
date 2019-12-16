using BudgetMe.Storing.Abstracts;

namespace BudgetMe.Storing.Models
{
  public class Bill : ABalance
    {
        // [ForeignKey("Budget")]
        public int? BudgetId { get; set; }

    }
}
