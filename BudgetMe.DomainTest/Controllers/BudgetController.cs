using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BudgetMe.Storing.Repositories;
using BudgetMe.Storing.Models;
using BudgetMe.Storing;
using Newtonsoft.Json;

namespace BudgetMe.Domain.Controllers
{
  [Produces("application/json")]
  [Route("/api/[Controller]/[action]")]
  [ApiController]

  public class BudgetController : ControllerBase
  {
    private readonly MemberService memberService = new MemberService();
    private readonly MemberRepository _mr = new MemberRepository();
    private readonly BudgetDbContext _db = new BudgetDbContext();

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMember(int id)
    {
      Member test = new Member();
      test.FirstName = "John";
      test.LastName = "Hancock";
      Budget hey = new Budget();
      hey.Name = "Daddys Wallet";
      test.Budget = hey;
      return await Task.FromResult(Ok(test));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBudget(int id)
    {
      return await Task.FromResult(Ok(_db.Budget.FirstOrDefault(p => p.Id == id)));
    }
    //Income
    [HttpPost]
    public async Task<IActionResult> CreateIncome(Income income)
    {
      if (ModelState.IsValid)
      {
 
        _mr.CreateIncome(income);
        return await Task.FromResult(Ok(income));
      }
      return await Task.FromResult(NotFound());
    }
    public async Task<IActionResult> UpdateIncome( int id,Income income)
    {
      if (ModelState.IsValid)
      {
        _mr.UpdateIncome(income);
        return await Task.FromResult(Ok(income));
      }
      return await Task.FromResult(NotFound());
    }
 [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIncome(int id)
    {
      if (ModelState.IsValid)
      {
        _mr.DeleteIncome(id);
        return await Task.FromResult(Ok(id));
      }
      return await Task.FromResult(NotFound(id));
    }

//Bill
    public async Task<IActionResult> CreateBill(Bill bill)
    {
      if (ModelState.IsValid)
      {
         _mr.CreateBill(bill);
        return await Task.FromResult(Ok(bill));
      }
      return await Task.FromResult(NotFound());
    }

    public async Task<IActionResult> UpdateBill(Bill bill)
    {
      if (ModelState.IsValid)
      {
         _mr.UpdateBill(bill);
        return await Task.FromResult(Ok(bill));
      }
      return await Task.FromResult(NotFound());
    }
 [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBill(int id)
    {
      if (ModelState.IsValid)
      {
        _mr.DeleteBill(1);
        return await Task.FromResult(Ok(id));
      }
      return await Task.FromResult(NotFound(id));
    }

//Goal
    public async Task<IActionResult> CreateGoal(Goal goal)
    {
      if (ModelState.IsValid)
      {
        memberService.CalculateLoan(goal);
        memberService.EstimatedGoalSavings(goal);
         _mr.CreateGoal(goal);
        return await Task.FromResult(Ok(goal));
      }
      return await Task.FromResult(NotFound());
    }

    public async Task<IActionResult> UpdateGoal(Goal goal)
    {
      if (ModelState.IsValid)
      {
        memberService.CalculateLoan(goal);
        memberService.EstimatedGoalSavings(goal);
        _mr.UpdateGoal(goal);
        return await Task.FromResult(Ok(goal));
      }
      return await Task.FromResult(NotFound());
    }
  [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGoal(int id)
    {
      if (ModelState.IsValid)
      {
         _mr.DeleteGoal(id);
        return await Task.FromResult(Ok(id));
      }
      return await Task.FromResult(NotFound(id));
    }

//Expense
    public async Task<IActionResult> CreateExpense(Expense expense)
    {
      if (ModelState.IsValid)
      {
       _mr.CreateExpense(expense);
        return await Task.FromResult(Ok(expense));
      }
      return await Task.FromResult(NotFound());
    }

    public async Task<IActionResult> UpdateExpense(Expense expense)
    {
      if (ModelState.IsValid)
      {

         _mr.UpdateExpense(expense);
        return await Task.FromResult(Ok(expense));
      }
      return await Task.FromResult(NotFound());
    }
 [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense(int id)
    {
      if (ModelState.IsValid)
      {
         _mr.DeleteExpense(id);
        return await Task.FromResult(Ok(id));
      }
      return await Task.FromResult(NotFound(id));
    }
     [HttpGet("{id}")]
    public async Task<IActionResult> Calculate(int id)
    {
      Budget budget = _db.Budget.FirstOrDefault(p => p.Id == id);
      budget.IncomeList = _db.Income.ToList();
      budget.BillList = _db.Bill.ToList();
      budget.GoalList = _db.Goal.ToList();
      budget.ExpenseList = _db.Expense.ToList();
      memberService.GetNetIncome(budget, budget.IncomeList);
      memberService.DeductBills(budget, budget.BillList);
      memberService.DeductGoals(budget, budget.GoalList);
      memberService.DivideRemainder(budget, budget.ExpenseList);
      return await Task.FromResult(Ok(_db.Budget.FirstOrDefault(p => p.Id == id)));
    }
  }
}