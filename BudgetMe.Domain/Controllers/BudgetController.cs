using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BudgetMe.Storing.Repositories;
using BudgetMe.Storing.Models;
using BudgetMe.Storing;

namespace BudgetMe.Domain.Controllers
{
  [Produces("application/json")]
  [Route("/api/[Controller]/[action]")]
  [ApiController]

  public class BudgetController : ControllerBase
  {
    private readonly MemberService memberService = new MemberService();
    private readonly MemberRepository<BudgetDbContext> _mr;
    private readonly BudgetDbContext _db;
    public BudgetController(BudgetDbContext db)
    {
      _db =db;
      _mr = new MemberRepository<BudgetDbContext>(db);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMember(int id)
    {
      return await Task.FromResult(Ok(_mr.GetMember(id)));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBudget(int id)
    {
      return await Task.FromResult(Ok(_mr.GetBudget(id)));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetIncome(int id)
    {
      return await Task.FromResult(Ok(_mr.GetIncome(id)));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBill(int id)
    {
      return await Task.FromResult(Ok(_mr.GetBill(id)));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetGoal(int id)
    {
      return await Task.FromResult(Ok(_mr.GetGoal(id)));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetExpense(int id)
    {
      return await Task.FromResult(Ok(_mr.GetExpense(id)));
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
 [HttpPost("{id}")]
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
 [HttpPost("{id}")]
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
  [HttpPost("{id}")]
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
 [HttpPost("{id}")]
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
      Budget budget = _mr.GetBudget(id);
      budget.IncomeList = _mr.GetIncomes();
      budget.BillList = _mr.GetBills();
      budget.GoalList = _mr.GetGoals();
      budget.ExpenseList = _mr.GetExpenses();
      memberService.GetNetIncome(budget, budget.IncomeList);
      memberService.DeductBills(budget, budget.BillList);
      memberService.DeductGoals(budget, budget.GoalList);
      memberService.DivideRemainder(budget, budget.ExpenseList);
      _mr.UpdateBudget(budget);
      return await Task.FromResult(Ok(_mr.GetBudget(id)));
    }
  }
}