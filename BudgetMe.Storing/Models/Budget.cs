using System.Collections.Generic;

namespace BudgetMe.Storing.Models
{
  public class Budget
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public int? MemberId { get; set; }
        public Member Member { get; set; }
        public List<Income> IncomeList { get; set; }
        public double TotalMonthlyNetIncome { get; set; }
        public List<Bill> BillList { get; set; }
        public double RemainderAfterBill { get; set; }
        public List<Goal> GoalList { get; set; }
        public double RemainderAfterGoals { get; set; }
        public List<Expense> ExpenseList { get; set; }
        public double Percent { get; set; }
        public double RemainderAfterExpenses { get; set; }
    }
}
