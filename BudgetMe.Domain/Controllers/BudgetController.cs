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
  // [Consumes("application/json")]
  [Route("/api/[Controller]/[action]")]
  [ApiController]
  public class BudgetController : ControllerBase
  {
    private readonly MemberRepository _mr = new MemberRepository();
    [HttpGet()]
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

    public async Task<IActionResult> DeleteIncome(int id)
    {
      if (ModelState.IsValid)
      {
        // _mr.DeleteIncome(1);
        return await Task.FromResult(Ok(id));
      }
      return await Task.FromResult(NotFound(id));
    }

    // [HttpGet("{id}")]
    // public async Task<IActionResult> Get(int id)
    // {
    //   _logger.LogInformation($"Get by Id Method {id}");
    //   return await Task.FromResult(Ok(_db.Pokemon.FirstOrDefault(p => p.Id ==id)));
    // }

    // // public async Task<IActionResult> Post([FromBody]Pokemon poke) //If we didnt use ApiController
    // [HttpPost]
    // public async Task<IActionResult> Post(Pokemon poke)
    // {
    //   if (ModelState.IsValid)
    //   {
    //     _db.Pokemon.Add(poke);
    //     _db.SaveChanges();

    //     return await Task.FromResult(Ok(poke));
    //   }

    //   return await Task.FromResult(NotFound(poke));
    // }
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