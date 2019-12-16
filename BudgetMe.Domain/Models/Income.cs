using SaveEm.Domain.Abstracts;

namespace SaveEm.Domain.Models
{
  public class Income : ABalance
    {
        // [ForeignKey("Budget")]
        public int? BudgetId { get; set; }

    }
}
