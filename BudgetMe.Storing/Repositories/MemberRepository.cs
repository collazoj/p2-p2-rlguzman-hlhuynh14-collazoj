using System.Collections.Generic;
using System.Linq;
using BudgetMe.Storing.Models;
using BudgetMe.Storing.Adapters;
using BudgetMe.Storing.Interface;

namespace BudgetMe.Storing.Repositories
{
    public class MemberRepository 
    {

        private OrmAdapter _oa;
        public MemberRepository()
        {
          _oa = new OrmAdapter();          
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
          return _oa.UpdateBill(bill);
        }
        public bool UpdateExpense(Expense expense)
        {
          return _oa.UpdateExpense(expense);
        }
        public bool UpdateGoal(Goal goal)
        {
          return _oa.UpdateGoal(goal);
        }
        public bool UpdateIncome(Income income)
        {
          return _oa.UpdateIncome(income);
        }


        //Delete a DB object Methods
        public bool DeleteBudget(int id)
        {
          return _oa.RemoveBudget(id);
        }
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
        public bool DeleteMember(int id)
        {
          return _oa.RemoveMember(id);
        }


        public bool SaveUpdates()
        {
          return _oa.SaveDBChanges();
        }

    }
}