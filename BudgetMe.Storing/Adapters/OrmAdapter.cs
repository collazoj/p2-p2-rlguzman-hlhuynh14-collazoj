using System.Collections.Generic;
using System.Linq;
using BudgetMe.Storing.Models;

namespace BudgetMe.Storing.Adapters
{
    public class OrmAdapter<T> where T:BudgetDbContext
    {
        private T _db;
        public OrmAdapter(T db)
        {
            _db = db;
        }
        
        //Get all objects from a table Methods.
        public List<Budget> GetBudgets()
        {
          return _db.Budget.ToList();
        }

        public List<Bill> GetBills()
        {
          return _db.Bill.ToList();
        }

        public List<Expense> GetExpenses()
        {
          return _db.Expense.ToList();
        }

        public List<Goal> GetGoals()
        {
          return _db.Goal.ToList();
        }

        public List<Income> GetIncomes()
        {
          return _db.Income.ToList();
        }

        public List<Member> GetMembers()
        {
          return _db.Member.ToList();
        }



        //Add and Save to DB Methods.
        public bool InsertBudget(Budget budget)
        {
          _db.Budget.Add(budget);
          return _db.SaveChanges()==1;
        }
        public bool InsertBill(Bill bill)
        {
          _db.Bill.Add(bill);
          return _db.SaveChanges()==1;
        }
        public bool InsertExpense(Expense expense)
        {
          _db.Expense.Add(expense);
          return _db.SaveChanges()==1;
        }
        public bool InsertGoal(Goal goal)
        {
          _db.Goal.Add(goal);
          return _db.SaveChanges()==1;
        }
        public bool InsertIncome(Income income)
        {
          _db.Income.Add(income);
          return _db.SaveChanges()==1;
        }
        public bool InsertMember(Member member)
        {
          _db.Member.Add(member);
          return _db.SaveChanges()==1;
        }
        //Update DB object Methods
        public bool UpdateBill(Bill bill)
        {
          _db.Bill.Update(bill);
          return _db.SaveChanges()==1;
        }
        public bool UpdateExpense(Expense expense)
        {
          _db.Expense.Update(expense);
          return _db.SaveChanges()==1;
        }
        public bool UpdateGoal(Goal goal)
        {
          _db.Goal.Update(goal);
          return _db.SaveChanges()==1;
        }
        public bool UpdateIncome(Income income)
        {
          _db.Income.Update(income);
          return _db.SaveChanges()==1;
        }
        public bool UpdateMember(Member member)
        {
          _db.Member.Update(member);
          return _db.SaveChanges()==1;
        }




        //Delete DB object Methods
        public bool RemoveBill(int id)
        {
          Bill bill = _db.Bill.First(b => b.Id==id);
          _db.Bill.Remove(bill);
          return _db.SaveChanges()==1;
        }
        public bool RemoveExpense(int id)
        {
          Expense expense = _db.Expense.First(e=>e.Id==id);
          _db.Expense.Remove(expense);
          return _db.SaveChanges()==1;
        }
        public bool RemoveGoal(int id)
        {
          Goal goal = _db.Goal.First(g => g.Id==id);
          _db.Goal.Remove(goal);
          return _db.SaveChanges()==1;
        }
        public bool RemoveIncome(int id)
        {
          Income income = _db.Income.First(i => i.Id==id);
          _db.Income.Remove(income);
          return _db.SaveChanges()==1;
        }
        public bool RemoveMember(int id)
        {
          Member member = _db.Member.First(m => m.Id==id);
          _db.Member.Remove(member);
          return _db.SaveChanges()==1;
        }

        public bool SaveDBChanges()
        {
          return _db.SaveChanges()==1;
        }
        

    }
}