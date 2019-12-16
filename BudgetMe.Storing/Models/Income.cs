using BudgetMe.Storing.Abstracts;

namespace BudgetMe.Storing.Models
{
  public class Income : ABalance
    {
        // [ForeignKey("Budget")]
        public int? BudgetId { get; set; }

    }
}
