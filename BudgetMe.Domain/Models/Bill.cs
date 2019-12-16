using SaveEm.Domain.Abstracts;

namespace SaveEm.Domain.Models
{
  public class Bill : ABalance
    {
        // [ForeignKey("Budget")]
        public int? BudgetId { get; set; }

    }
}
