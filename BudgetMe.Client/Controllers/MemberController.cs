using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using BudgetMe.Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetMe.Client.Controllers
{
    public class MemberController : Controller
    {
    static HttpClient client = new HttpClient();
    public MemberController()
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    }
        public async Task<IActionResult> Index()
        {
            Member loggedInMember =  await GetMember(1);
            {
                loggedInMember.Budget = await GetBudget(1);
                return View(loggedInMember);
            }
        } 
        [HttpGet]
        public async Task<Member> GetMember(int id)
        {
        string path = $"https://localhost:5001/api/Budget/GetMember/{id}";
        Member member = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            member = await response.Content.ReadAsAsync<Member>();
        }
        return (member);
        }
        public async Task<Budget> GetBudget(int id)
        {
        string path = $"https://localhost:5001/api/Budget/GetBudget/{id}";
        Budget budget = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            budget = await response.Content.ReadAsAsync<Budget>();
        }
        return (budget);
        }
    //     public IActionResult SeeBudget(int id)
    //     {
    //         Budget budget = GetBudget(1);
    //         return View(budget);
    //     }
    //     public IActionResult CreateIncome(int id)
    //     {
    //         Income income = new Income();
    //         return View(income);
    //     }
    //     [HttpPost]
    //     [ValidateAntiForgeryToken]
    //     public IActionResult CreateIncome(int id, Income income)
    //     {
            
    //         return RedirectToAction("SeeBudget", new { id });
    //     }
    //     [HttpPut]
    //     public IActionResult UpdateIncome(int id)
    //     {
    //         Income income = clientModelMapper.ConvertDomainIncomeToClientIncome(memberRepository.GetIncome(id));
    //         return View(income);
    //     }
    //     [HttpPut]
    //     [ValidateAntiForgeryToken]
    //     public IActionResult UpdateIncome(int id, Income newIncome)
    //     {
    //         Domain.Models.Income income = domainModelMapper.ConvertClientIncomeToDomainIncome(newIncome);
    //         memberRepository.UpdateIncome(income);
    //         id = 1;
    //         return RedirectToAction("SeeBudget", new {id});
    //     }
    //     public IActionResult DeleteIncome(int id)
    //     {
    //         Income income = clientModelMapper.ConvertDomainIncomeToClientIncome(memberRepository.GetIncome(id));
    //         return View(income);
    //     }
    //     [HttpDelete]
    //     [ValidateAntiForgeryToken]
    //     public IActionResult DeleteIncome(int id, Income income)
    //     {
    //          memberRepository.DeleteIncome(income.Id);
    //         id = 1;
    //         return RedirectToAction("SeeBudget", new { id });
    //     }
    // }
    }
}