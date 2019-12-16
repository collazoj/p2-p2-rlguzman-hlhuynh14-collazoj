using BudgetMe.Storing.Abstracts;

namespace BudgetMe.Storing.Models
{
  public class Goal : ABalance
    {
        public double GoalsSavings { get; set; }
        public double EstimatedHighLoan { get; set; }
        public double EstimatedLowLoan { get; set; }
        public double GoalSavingsPerMonth { get; set; }
        public int MonthGoals { get; set; }
        public double EstimatedHighTotal { get; set; }
        public double EstimatedLowTotal { get; set; }
        public int LoanTermInYears { get; set; }
        public double InterestRate { get; set; }
        //Budget
        // [ForeignKey("Budget")]
        public int? BudgetId { get; set; }

    }
}
