using System.Collections.Generic;
using System.Linq;
using BudgetMe.Storing;
using BudgetMe.Storing.Adapters;
using BudgetMe.Storing.Models;
using Xunit;

namespace BudgetMe.Testing.Domain
{
    public class Test_MemberService
    {

      [Fact]
      public void Test_GetNetIncomeTest()
      {
        //Arrange
        Test_BudgetDbContext _tdb1 = new Test_BudgetDbContext();
        _tdb1.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb1);
        MemberService memberService = new MemberService();
        Budget budget = _tdb1.Budget.Where(m => m.Id == 1).Single();
        List<Income> incomeList = _tdb1.Income.ToList();

        //Act
        memberService.GetNetIncome(budget, incomeList);
        Budget budget2 = _tdb1.Budget.Where(m => m.Id == 1).Single();
        double actual = 4450;
        double expected = budget2.TotalMonthlyNetIncome;
         _tdb1.Database.EnsureDeleted();

        //Assert
        Assert.True(expected == actual); 
      }
      [Fact]
      public void Test_GetBillTest()
      {
        //Arrange
        Test_BudgetDbContext _tdb2 = new Test_BudgetDbContext();
        _tdb2.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb2);
        MemberService memberService = new MemberService();
        Budget budget = _tdb2.Budget.Where(m => m.Id == 1).Single();
        List<Bill> billList = _tdb2.Bill.ToList();

        //Act
        budget.TotalMonthlyNetIncome = 4450;
        memberService.DeductBills(budget, billList);
        Budget budget2 = _tdb2.Budget.Where(m => m.Id == 1).Single();
        double actual = 3680;
        double expected = budget2.RemainderAfterBill;
         _tdb2.Database.EnsureDeleted();

        //Assert
        Assert.True(expected == actual); 
      }
      [Fact]
      public void Test_GetGoalTest()
      {
        //Arrange
        Test_BudgetDbContext _tdb3 = new Test_BudgetDbContext();
        _tdb3.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb3);
        MemberService memberService = new MemberService();
        Budget budget = _tdb3.Budget.Where(m => m.Id == 1).Single();
        List<Goal> goalList = _tdb3.Goal.ToList();

        //Act
        budget.RemainderAfterBill = 3680;
        memberService.DeductGoals(budget, goalList);
        Budget budget2 = _tdb3.Budget.Where(m => m.Id == 1).Single();
        double actual = 2980;
        double expected = budget2.RemainderAfterGoals;
         _tdb3.Database.EnsureDeleted();

        //Assert
        Assert.True(expected == actual); 
      }
      [Fact]
      public void Test_GetExpenseTest()
      {
        //Arrange
        Test_BudgetDbContext _tdb4 = new Test_BudgetDbContext();
        _tdb4.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb4);
        MemberService memberService = new MemberService();
        Budget budget = _tdb4.Budget.Where(m => m.Id == 1).Single();
        List<Expense> expenseList = _tdb4.Expense.ToList();

        //Act
        budget.RemainderAfterGoals = 2980;
        memberService.DivideRemainder(budget, expenseList);
        Budget budget2 = _tdb4.Budget.Where(m => m.Id == 1).Single();
        double actual = 2235;
        double expected = budget2.RemainderAfterExpenses;
         _tdb4.Database.EnsureDeleted();

        //Assert
        Assert.True(expected == actual); 
      }
      [Fact]
      public void Test_CalculatLoanTest()
      {
        //Arrange
        Test_BudgetDbContext _tdb5 = new Test_BudgetDbContext();
        _tdb5.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb5);
        MemberService memberService = new MemberService();
        Goal goal = _tdb5.Goal.Where(m => m.Id == 2).SingleOrDefault();

        //Act
        memberService.CalculateLoan(goal);
        Goal goal2 = _tdb5.Goal.Where(m => m.Id == 2).SingleOrDefault();
        double actual = 34200;
        double expected = goal2.EstimatedHighLoan;
         _tdb5.Database.EnsureDeleted();

        //Assert
        Assert.True(expected == actual); 
      }
      [Fact]
      public void Test_GoalSavingsTest()
      {
        //Arrange
        Test_BudgetDbContext _tdb6 = new Test_BudgetDbContext();
        _tdb6.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb6);
        MemberService memberService = new MemberService();
        Goal goal = _tdb6.Goal.Where(m => m.Id == 2).SingleOrDefault();

        //Act
        memberService.CalculateLoan(goal);
        Goal goal2 = _tdb6.Goal.Where(m => m.Id == 2).SingleOrDefault();
        memberService.EstimatedGoalSavings(goal2);
        Goal goal3 = _tdb6.Goal.Where(m => m.Id == 2).SingleOrDefault();
        double actual = 49200;
        double expected = goal2.EstimatedHighTotal;
        _tdb6.Database.EnsureDeleted();

        //Assert
        Assert.True(expected == actual); 
      }
    }
}