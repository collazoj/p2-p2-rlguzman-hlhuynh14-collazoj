using System.Collections.Generic;
using System.Linq;
using BudgetMe.Storing.Models;
using BudgetMe.Storing.Adapters;
using BudgetMe.Storing.Interface;

namespace BudgetMe.Storing.Repositories
{
    public class MemberRepository 
    {

        private OrmAdapter<BudgetDbContext> _oa;
        public MemberRepository()
        {
          BudgetDbContext _db = new BudgetDbContext();
          _oa = new OrmAdapter<BudgetDbContext>(_db);
        }

        public List<Budget> GetBudgets()
        {
          return _oa.GetBudgets();
        }
        public List<Bill> GetBills()
        {
          return _oa.GetBills();
        }
        public List<Expense> GetExpenses()
        {
          return _oa.GetExpenses();
        }
        public List<Goal> GetGoals()
        {
          return _oa.GetGoals();
        }
        public List<Income> GetIncomes()
        {
          return _oa.GetIncomes();
        }
        public List<Member> GetMembers()
        {
          return _oa.GetMembers();
        }
        //Grabs an object from the database given a specified id.
        public Budget GetBudget(int id)
        {
          List<Budget> blist = GetBudgets();

          Budget budget = blist.Where(b => b.Id==id).SingleOrDefault();
          return budget;
        }
        public Bill GetBill(int id)
        {
          List<Bill> billlist = GetBills();

          Bill bill = billlist.Where(b => b.Id==id).SingleOrDefault();
          return bill;
        }
        public Expense GetExpense(int id)
        {
          List<Expense> expenselist = GetExpenses();

          Expense expense = expenselist.Where(e => e.Id==id).SingleOrDefault();
          return expense;
        }
        public Goal GetGoal(int id)
        {
          List<Goal> goallist = GetGoals();
          Goal goal = goallist.Where(g => g.Id==id).SingleOrDefault();

          return goal;
        }
        public Income GetIncome(int id)
        {
          List<Income> incomelist = GetIncomes();
          Income income = incomelist.Where(i => i.Id==id).SingleOrDefault();
          return income;
        }
        public Member GetMember(int id)
        {
          List<Member> memberlist = GetMembers();
          Member member = memberlist.Where(m => m.Id == id).SingleOrDefault();
          return member;
        }


        //Create and Add object onto DB

        public bool CreateBill(Bill bill)
        {
          bill.BudgetId = 1;
          return _oa.InsertBill(bill);
        }
        public bool CreateExpense(Expense expense)
        {
          expense.BudgetId = 1;
          return _oa.InsertExpense(expense);
        }
        public bool CreateGoal(Goal goal)
        {
          goal.BudgetId = 1;
          return _oa.InsertGoal(goal);
        }
        public bool CreateIncome(Income income)
        {
          income.BudgetId = 1;
          return _oa.InsertIncome(income);
        }

        //Update a DB object Method
public bool UpdateBill(Bill bill)
        {
          Bill bill2 = GetBill(bill.Id);
          bill2.Amount = bill.Amount;
          bill2.Name = bill.Name;
          return _oa.UpdateBill(bill2);
        }
        public bool UpdateExpense(Expense expense)
        {
          Expense expense2 = GetExpense(expense.Id);
          expense2.Amount = expense.Amount;
          expense2.Name = expense.Name;
          expense2.Percent = expense.Percent;
          return _oa.UpdateExpense(expense2);
        }
        public bool UpdateGoal(Goal goal)
        {
          Goal goal2 = GetGoal(goal.Id);
          goal2.Name = goal.Name;
          goal2.GoalsSavings = goal.GoalsSavings;
          goal2.GoalSavingsPerMonth = goal.GoalSavingsPerMonth;
          goal2.MonthGoals = goal.MonthGoals;
          goal2.LoanTermInYears = goal.LoanTermInYears;
          goal2.InterestRate = goal.InterestRate;
          goal2.EstimatedLowLoan = goal.EstimatedLowLoan;
          goal2.EstimatedHighLoan = goal.EstimatedHighLoan;
          goal2.EstimatedHighTotal = goal.EstimatedHighTotal;
          goal2.EstimatedLowTotal = goal.EstimatedLowTotal;
          return _oa.UpdateGoal(goal2);
        }
        public bool UpdateIncome(Income income)
        {
          Income income2 = GetIncome(income.Id);
          income2.Amount = income.Amount;
          income2.Name = income.Name;
          return _oa.UpdateIncome(income2);
        }



        //Delete a DB object Methods
        public bool DeleteBill(int id)
        {
          return _oa.RemoveBill(id);
        }
        public bool DeleteExpense(int id)
        {
          return _oa.RemoveExpense(id);
        }
        public bool DeleteGoal(int id)
        {
          return _oa.RemoveGoal(id);
        }
        public bool DeleteIncome(int id)
        {
          return _oa.RemoveIncome(id);
        }
    }
}