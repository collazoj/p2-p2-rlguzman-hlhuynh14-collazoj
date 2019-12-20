using System.ComponentModel.DataAnnotations;

namespace BudgetMe.Client.Models
{
  public class Goal 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Amount { get; set; }
        [Required]
        public double GoalsSavings { get; set; }
        public double EstimatedHighLoan { get; set; }
        public double EstimatedLowLoan { get; set; }
        [Required]
        public double GoalSavingsPerMonth { get; set; }
        [Required]
        public int MonthGoals { get; set; }
        public double EstimatedHighTotal { get; set; }
        public double EstimatedLowTotal { get; set; }
        [Required]
        public int LoanTermInYears { get; set; }
        [Required]
        public double InterestRate { get; set; }
        public int? BudgetId { get; set; }

    }
}
