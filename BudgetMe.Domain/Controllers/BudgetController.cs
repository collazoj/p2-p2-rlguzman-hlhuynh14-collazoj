using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BudgetMe.Storing.Repositories;
using BudgetMe.Storing.Models;

namespace BudgetMe.Domain.Controllers
{
  [Produces("application/json")]
  [Route("/api/[Controller]/[action]")]
  [ApiController]
  public class BudgetController : ControllerBase
  {
    private readonly MemberRepository _mr = new MemberRepository();
    [HttpPost]
    public async Task<IActionResult> CreateIncome(string name, int amount)
    {
      if (ModelState.IsValid)
      {
        Income income = new Income();
        income.Name = name;
        income.Amount = amount;
        // _mr.CreateIncome(name, amount, 1);
        return await Task.FromResult(Ok(income));
      }
      return await Task.FromResult(NotFound());
    }
    [HttpPost]
    public async Task<IActionResult> UpdateIncome(string name, int amount)
    {
      if (ModelState.IsValid)
      {
        Income income = new Income();
        income.Name = name;
        income.Amount = amount;
        // _mr.UpdateIncome(income);
        return await Task.FromResult(Ok(income));
      }
      return await Task.FromResult(NotFound());
    }
    [HttpPost]
    public async Task<IActionResult> DeleteIncome(int id)
    {
      if (ModelState.IsValid)
      {
        // _mr.DeleteIncome(1);
        return await Task.FromResult(Ok(id));
      }
      return await Task.FromResult(NotFound(id));
    }
  
    public BudgetController(MemberRepository mr)
    {
      _mr = mr;
    } 
    public BudgetController()
    {
      _mr = new MemberRepository();
    } 
    

  }
}