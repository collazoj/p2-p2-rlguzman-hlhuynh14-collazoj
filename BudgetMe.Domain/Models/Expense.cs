using SaveEm.Domain.Abstracts;

namespace SaveEm.Domain.Models
{
  public class Expense : ABalance
    {
        // [Key]
        public double Percent { get; set; }
        // [ForeignKey("Budget")]
        public int? BudgetId { get; set; }

    }
}
