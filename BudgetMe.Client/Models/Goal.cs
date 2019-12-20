namespace BudgetMe.Client.Models
{
  public class Goal 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public double GoalsSavings { get; set; }
        public double EstimatedHighLoan { get; set; }
        public double EstimatedLowLoan { get; set; }
        public double GoalSavingsPerMonth { get; set; }
        public int MonthGoals { get; set; }
        public double EstimatedHighTotal { get; set; }
        public double EstimatedLowTotal { get; set; }
        public int LoanTermInYears { get; set; }
        public double InterestRate { get; set; }
        public int? BudgetId { get; set; }

    }
}
