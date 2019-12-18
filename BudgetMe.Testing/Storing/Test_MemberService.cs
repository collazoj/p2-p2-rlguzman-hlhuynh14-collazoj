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
        Test_BudgetDbContext _tdb = new Test_BudgetDbContext();
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        MemberService memberService = new MemberService();
        Budget budget = _tdb.Budget.Where(m => m.Id == 1).Single();
        List<Income> incomeList = _tdb.Income.ToList();

        //Act
        memberService.GetNetIncome(budget, incomeList);
        Budget budget2 = _tdb.Budget.Where(m => m.Id == 1).Single();
        double actual = 4450;
        double expected = budget2.TotalMonthlyNetIncome;
         _tdb.Database.EnsureDeleted();

        //Assert
        Assert.True(expected == actual); //
      }
      [Fact]
      public void Test_GetBillTest()
      {
        //Arrange
        Test_BudgetDbContext _tdb = new Test_BudgetDbContext();
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        MemberService memberService = new MemberService();
        Budget budget = _tdb.Budget.Where(m => m.Id == 1).Single();
        List<Bill> billList = _tdb.Bill.ToList();

        //Act
        budget.TotalMonthlyNetIncome = 4450;
        memberService.DeductBills(budget, billList);
        Budget budget2 = _tdb.Budget.Where(m => m.Id == 1).Single();
        double actual = 3680;
        double expected = budget2.RemainderAfterBill;
         _tdb.Database.EnsureDeleted();

        //Assert
        Assert.True(expected == actual); //
      }
      [Fact]
      public void Test_GetGoalTest()
      {
        //Arrange
        Test_BudgetDbContext _tdb = new Test_BudgetDbContext();
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        MemberService memberService = new MemberService();
        Budget budget = _tdb.Budget.Where(m => m.Id == 1).Single();
        List<Goal> goalList = _tdb.Goal.ToList();

        //Act
        budget.RemainderAfterBill = 3680;
        memberService.DeductGoals(budget, goalList);
        Budget budget2 = _tdb.Budget.Where(m => m.Id == 1).Single();
        double actual = 2980;
        double expected = budget2.RemainderAfterGoals;
         _tdb.Database.EnsureDeleted();

        //Assert
        Assert.True(expected == actual); //
      }
      [Fact]
      public void Test_GetExpenseTest()
      {
        //Arrange
        Test_BudgetDbContext _tdb = new Test_BudgetDbContext();
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        MemberService memberService = new MemberService();
        Budget budget = _tdb.Budget.Where(m => m.Id == 1).Single();
        List<Expense> expenseList = _tdb.Expense.ToList();

        //Act
        budget.RemainderAfterGoals = 2980;
        memberService.DivideRemainder(budget, expenseList);
        Budget budget2 = _tdb.Budget.Where(m => m.Id == 1).Single();
        double actual = 2235;
        double expected = budget2.RemainderAfterExpenses;
         _tdb.Database.EnsureDeleted();

        //Assert
        Assert.True(expected == actual); //
      }
    }
}