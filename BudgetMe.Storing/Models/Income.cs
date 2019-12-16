using BudgetMe.Domain.Abstracts;

namespace BudgetMe.Domain.Models
{
  public class Income : ABalance
    {
        // [ForeignKey("Budget")]
        public int? BudgetId { get; set; }

    }
}
