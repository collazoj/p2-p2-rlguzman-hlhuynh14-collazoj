using System;
using System.Collections.Generic;
using System.Text;
using SaveEm.Domain.Models;

namespace SaveEm.Domain.Interfaces
{
    public interface IMemberService
    {
        void GetNetIncome(Budget budget, List<Income> incomeList);
        void DeductBills(Budget budget, List<Bill> billList);
        void DeductGoals(Budget budget, List<Goal> goalList);
        void DivideRemainder(Budget budget, List<Expense> expenseList);
        void EstimatedGoalSavings(Goal goal);
        void CalculateLoan(Goal goal);
    }
}
