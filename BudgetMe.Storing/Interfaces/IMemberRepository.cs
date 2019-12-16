using System.Collections.Generic;
using BudgetMe.Domain.Models;

namespace BudgetMe.Storing.Interface
{
    public interface IMemberRepository
    {
        //Returns a list of all the items in database.
        List<Budget> GetBudgets();
        List<Bill> GetBills();
        List<Expense> GetExpenses();
        List<Goal> GetGoals();
        List<Income> GetIncomes();
        List<Member> GetMembers();
        
        //Grabs an object given its id.
        Budget GetBudget(int id);
        Bill GetBill(int id);
        Expense GetExpense(int id);
        Goal GetGoal(int id);
        Income GetIncome(int id);
        Member GetMember(int id);
        
        //Creates the object and saves it in the database.
        bool CreateBudget(string name, int memberid, double totalmonthlynetincome, double remainderafterbill, double percent, double remainderafterexpenses);
        bool CreateBill(string name, double amount, int budgetid);
        bool CreateExpense(string name, double amount, double percent, int budgetid);
        bool CreateGoal(string name, double goalssavings, double goalsavingspermonth, int monthgoals, int loanterminyears, double interestrate, int budgetid);
        bool CreateIncome(string name, double amount, int budgetid);
        bool CreateMember(string firstname, string lastname);

        //Update object Methods given parameters
        bool UpdateBill(Bill bill);
        bool UpdateExpense(Expense expense);
        bool UpdateGoal(Goal goal);
        bool UpdateIncome(Income income);


        //Deletes an object given its id and saves the change on the database.
        bool DeleteBudget(int id);
        bool DeleteBill(int id);
        bool DeleteExpense(int id);
        bool DeleteGoal(int id);
        bool DeleteIncome(int id);
        bool DeleteMember(int id);

        bool SaveUpdates();
    }
}