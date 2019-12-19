using BudgetMe.Storing.Abstracts;

namespace BudgetMe.Storing.Models
{
  public class Income : ABalance
    {
        public int? BudgetId { get; set; }

    }
}
