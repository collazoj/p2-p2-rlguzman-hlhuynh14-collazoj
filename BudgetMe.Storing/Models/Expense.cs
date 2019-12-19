using BudgetMe.Storing.Abstracts;

namespace BudgetMe.Storing.Models
{
  public class Expense : ABalance
    {

        public double Percent { get; set; }

        public int? BudgetId { get; set; }

    }
}
