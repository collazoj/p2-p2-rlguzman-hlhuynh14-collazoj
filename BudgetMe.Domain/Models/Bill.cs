using BudgetMe.Domain.Abstracts;

namespace BudgetMe.Domain.Models
{
  public class Bill : ABalance
    {
        // [ForeignKey("Budget")]
        public int? BudgetId { get; set; }

    }
}
