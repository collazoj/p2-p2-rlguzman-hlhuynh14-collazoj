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
        [HttpGet]
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
        [HttpGet]
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
        public async Task<Income> GetIncome(int id)
        {
        string path = $"http://app/api/Budget/GetIncome/{id}";
        Income income = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            income = await response.Content.ReadAsAsync<Income>();
        }
        return (income);
        }
        [HttpGet]
        public async Task<Bill> GetBill(int id)
        {
        string path = $"http://app/api/Budget/GetBill/{id}";
        Bill bill = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            bill = await response.Content.ReadAsAsync<Bill>();
        }
        return (bill);
        }
        [HttpGet]
        public async Task<Goal> GetGoal(int id)
        {
        string path = $"http://app/api/Budget/GetGoal/{id}";
        Goal goal = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            goal = await response.Content.ReadAsAsync<Goal>();
        }
        return (goal);
        }
        [HttpGet]
        public async Task<Expense> GetExpense(int id)
        {
        string path = $"http://app/api/Budget/GetExpense/{id}";
        Expense expense = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            expense = await response.Content.ReadAsAsync<Expense>();
        }
        return (expense);
        }
        [HttpGet]
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

        public async Task<IActionResult> UpdateIncome(int id)
        {
            Income income = await GetIncome(id);
            return View(income);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateIncome(int id, Income income)
        {
        string path = $"http://app/api/Budget/UpdateIncome";
        
        HttpResponseMessage response = await client.PostAsJsonAsync(path, income);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("SeeBudget", new { id });
        }
        return RedirectToAction("SeeBudget", new { id });
        }
        public async Task<IActionResult> DeleteIncome(int id)
        {
            Income income = await GetIncome(id);
            return View(income);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteIncome(int id, Income income)
        {
        string path = $"http://app/api/Budget/DeleteIncome/{id}";
     
        HttpResponseMessage response = await client.GetAsync(path);
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
        public async Task<IActionResult> UpdateBill(int id)
        {
            Bill bill = await GetBill(id);
            return View(bill);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBill(int id, Bill bill)
        {
        string path = $"http://app/api/Budget/UpdateBill";
        
        HttpResponseMessage response = await client.PostAsJsonAsync(path, bill);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("SeeBudget", new { id });
        }
        return RedirectToAction("SeeBudget", new { id });
        }

        public async Task<IActionResult> DeleteBill(int id)
        {
            Bill bill = await GetBill(id);
            return View(bill);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteBill(int id, Bill bill)
        {
        string path = $"http://app/api/Budget/DeleteBill/{id}";
        HttpResponseMessage response = await client.GetAsync(path);
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
            return RedirectToAction("CalculateGoal", new { id });
        }
        return RedirectToAction("SeeBudget", new { id });
        }
        public async Task<IActionResult> UpdateGoal(int id)
        {
            Goal goal = await GetGoal(id);
            return View(goal);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateGoal(int id, Goal goal)
        {
        string path = $"http://app/api/Budget/UpdateGoal";
        
        HttpResponseMessage response = await client.PostAsJsonAsync(path, goal);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("SeeBudget", new { id });
        }
        return RedirectToAction("SeeBudget", new { id });
        }
        public async Task<IActionResult> CalculateGoal(int id)
        {
            Goal goal = await GetGoal(id);
            return View(goal);
        }
        public async Task<IActionResult> DeleteGoal(int id)
        {
            Goal goal = await GetGoal(id);
            return View(goal);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteGoal(int id, Goal goal)
        {
        string path = $"http://app/api/Budget/DeleteGoal/{id}";
        HttpResponseMessage response = await client.GetAsync(path);
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
        public async Task<IActionResult> UpdateExpense(int id)
        {
            Expense expense = await GetExpense(id);
            return View(expense);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateExpense(int id, Expense expense)
        {
        string path = $"http://app/api/Budget/UpdateExpense";
        
        HttpResponseMessage response = await client.PostAsJsonAsync(path, expense);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("SeeBudget", new { id });
        }
        return RedirectToAction("SeeBudget", new { id });
        }
        public async Task<IActionResult> DeleteExpense(int id)
        {
            Expense expense = await GetExpense(id);
            return View(expense);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteExpense(int id, Expense expense)
        {
        string path = $"http://app/api/Budget/DeleteExpense/{id}";
     
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
        return RedirectToAction("SeeBudget", new { id });
        }
            return RedirectToAction("SeeBudget", new { id });
        }
        public async Task<IActionResult> Calculate(int id)
        {
        string path = $"http://app/api/Budget/Calculate/{id}";
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("SeeBudget", new { id });
        }
        return RedirectToAction("SeeBudget", new { id });
        }
    }   
}