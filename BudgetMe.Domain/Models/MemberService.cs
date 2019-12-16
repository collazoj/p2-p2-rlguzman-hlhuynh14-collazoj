using BudgetMe.Domain.Interfaces;
using BudgetMe.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BudgetMe.Domain.Models
{
  public class MemberService : IMemberService 
    {
        //Budget
        public void GetNetIncome(Budget budget, List<Income> incomeList)
        {
            double income = 0;
            foreach(var item in incomeList)
            {
                income += item.Amount;
            }
            budget.TotalMonthlyNetIncome = income;
        }
        public void DeductBills(Budget budget, List<Bill> billList)
        {
            double billTotal = 0;
            foreach ( var item in billList)
            {
                billTotal += item.Amount;
            }
            
            budget.RemainderAfterBill = budget.TotalMonthlyNetIncome - billTotal;
        }
        public void DeductGoals(Budget budget, List<Goal> goalList)
        {
            double goalTotal = 0;
            foreach(var item in goalList)
            {
                goalTotal += item.GoalSavingsPerMonth;
            }
            budget.RemainderAfterGoals = budget.RemainderAfterBill - goalTotal;
        }
        public void DivideRemainder(Budget budget, List<Expense> expenseList)
        {
            budget.Percent = 1;
            foreach (var item in expenseList)
            {
                item.Amount = (item.Percent * .01) * budget.RemainderAfterBill;
               budget.Percent =  budget.Percent - (item.Percent * .01);
            }
            budget.RemainderAfterExpenses = budget.Percent * budget.RemainderAfterBill;
        }
        //Goals
        public void EstimatedGoalSavings(Goal goal)
        {
            goal.EstimatedHighTotal = (goal.GoalSavingsPerMonth * goal.MonthGoals) + goal.GoalsSavings + goal.EstimatedHighLoan;
            goal.EstimatedLowTotal = (goal.GoalSavingsPerMonth * goal.MonthGoals) + goal.GoalsSavings + goal.EstimatedLowLoan;
        }
        public void CalculateLoan(Goal goal)
        {
            double highGoal = goal.GoalSavingsPerMonth * (12 * goal.LoanTermInYears);
            goal.EstimatedHighLoan = highGoal - (highGoal * (goal.InterestRate *.01));
            double lowGoal = goal.GoalSavingsPerMonth * (6 * goal.LoanTermInYears);
            goal.EstimatedLowLoan = lowGoal - (lowGoal * (goal.InterestRate * .01));
        }
    }
}
