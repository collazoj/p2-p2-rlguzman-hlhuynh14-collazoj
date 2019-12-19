using BudgetMe.Storing.Abstracts;

namespace BudgetMe.Storing.Models
{
  public class Bill : ABalance
    {
        public int? BudgetId { get; set; }

    }
}
