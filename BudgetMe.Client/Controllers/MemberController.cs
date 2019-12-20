using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BudgetMe.Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        [HttpGet("{id}")]
        public async Task<Member> GetMember(int id)
        {
        string path = $"http://app/api/Budget/GetMember/{id}";
        Member member = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            member = await response.Content.ReadAsAsync<Member>();
        }
        return (member);
        }
        [HttpGet("{id}")]
        public async Task<Budget> GetBudget(int id)
        {
        string path = $"http://app/api/Budget/GetBudget/{id}";
        Budget budget = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            budget = await response.Content.ReadAsAsync<Budget>();
        }
        return (budget);
        }
        public async Task<IActionResult> SeeBudget(int id)
        {
            Budget budget = await GetBudget(1);
            return View(budget);
        }
        //Income
        public IActionResult CreateIncome(int id)
        {
            Income income = new Income();
            return View(income);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateIncome(int id, Income income)
        {
        string path = $"http://app/api/Budget/CreateIncome";
        
        HttpResponseMessage response = await client.PostAsJsonAsync(path, income);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("SeeBudget", new { id });
        }
        return RedirectToAction("SeeBudget", new { id });
        }
        public IActionResult DeleteIncome(int id)
        {
            Income income = new Income();
            return View(income);
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteIncome(int id, Income income)
        {
        string path = $"http://app/api/Budget/DeleteIncome/{id}";
        HttpResponseMessage response = await client.DeleteAsync(path);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("SeeBudget", new { id });
        }
        return RedirectToAction("SeeBudget", new { id });
        }

        //Bill
        public IActionResult CreateBill(int id)
        {
            Bill bill = new Bill();
            return View(bill);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBill(int id, Bill bill)
        {
        string path = $"http://app/api/Budget/CreateBill/";
        
        HttpResponseMessage response = await client.PostAsJsonAsync(path, bill);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("SeeBudget", new { id });
        }
        return RedirectToAction("SeeBudget", new { id });
        }
        public IActionResult DeleteBill(int id)
        {
            Bill bill = new Bill();
            return View(bill);
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBill(int id, Bill bill)
        {
        string path = $"http://app/api/Budget/DeleteBill/{bill.Id}";
        HttpResponseMessage response = await client.DeleteAsync(path);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("SeeBudget", new { id });
        }
        return RedirectToAction("SeeBudget", new { id });
        }

        //Goal
        public IActionResult CreateGoal(int id)
        {
            Goal goal = new Goal();
            return View(goal);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGoal(int id, Goal goal)
        {
        string path = $"http://app/api/Budget/CreateGoal/";
        
        HttpResponseMessage response = await client.PostAsJsonAsync(path, goal);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("SeeBudget", new { id });
        }
        return RedirectToAction("SeeBudget", new { id });
        }
        public IActionResult DeleteGoal(int id)
        {
            Goal goal = new Goal();
            return View(goal);
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteGoal(int id, Goal goal)
        {
        string path = $"http://app/api/Budget/DeleteGoal/{goal.Id}";
        HttpResponseMessage response = await client.DeleteAsync(path);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("SeeBudget", new { id });
        }
        return RedirectToAction("SeeBudget", new { id });
        }

        //Expense
        public IActionResult CreateExpense(int id)
        {
            Expense expense = new Expense();
            return View(expense);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExpense(int id, Expense expense)
        {
        string path = $"http://app/api/Budget/CreateExpense/";
        
        HttpResponseMessage response = await client.PostAsJsonAsync(path, expense);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("SeeBudget", new { id });
        }
        return RedirectToAction("SeeBudget", new { id });
        }
        public IActionResult DeleteExpense(int id)
        {
            Expense expense = new Expense();
            return View(expense);
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteExpense(int id, Expense expense)
        {
        string path = $"http://app/api/Budget/DeleteExpense/{expense.Id}";
        HttpResponseMessage response = await client.DeleteAsync(path);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("SeeBudget", new { id });
        }
        return RedirectToAction("SeeBudget", new { id });
        }

        public async Task<Budget> Calculate(int id)
        {
        string path = $"http://app/api/Budget/Calculate/{id}";
        Budget budget = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            budget = await response.Content.ReadAsAsync<Budget>();
        }
        return (budget);
        }
    }   
}