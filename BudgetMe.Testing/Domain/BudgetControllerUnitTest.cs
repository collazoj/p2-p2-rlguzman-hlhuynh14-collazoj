using BudgetMe.Domain.Controllers;
using BudgetMe.Storing;
using BudgetMe.Storing.Adapters;
using BudgetMe.Storing.Models;
using Xunit;

namespace BudgetMe.Testing.Domain
{
    public class Test_BudgetController
    {

      [Fact]
      public void Test_GetMemberTest()
      {
        //Arrange
        Test_BudgetDbContext _tdb = new Test_BudgetDbContext();
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        BudgetController budgetController = new BudgetController();

        //Act
        var member = budgetController.GetMember(1);
        _tdb.Database.EnsureDeleted();

        //Assert
        Assert.True(member != null); //
      }
    [Fact]
    public void Test_GetBudgetTest()
      {
        //Arrange
        Test_BudgetDbContext _tdb = new Test_BudgetDbContext();
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        BudgetController budgetController = new BudgetController();

        //Act
        var budget = budgetController.GetBudget(1);
        _tdb.Database.EnsureDeleted();

        //Assert
        Assert.True(budget != null); //
      }
      [Fact]
    public void Test_CreateIncomeTest()
      {
        //Arrange
        Test_BudgetDbContext _tdb = new Test_BudgetDbContext();
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        BudgetController budgetController = new BudgetController();
        Income income = new Income();

        //Act
        var income2 = budgetController.CreateIncome(income);
        _tdb.Database.EnsureDeleted();

        //Assert
        Assert.True(income2 != null); //
      }
    public void Test_CreateBillTest()
      {
        //Arrange
        Test_BudgetDbContext _tdb = new Test_BudgetDbContext();
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        BudgetController budgetController = new BudgetController();
        Bill bill = new Bill();

        //Act
        var bill2 = budgetController.CreateBill(bill);
        _tdb.Database.EnsureDeleted();

        //Assert
        Assert.True(bill2 != null); //
      }
    public void Test_CreateGoalTest()
      {
        //Arrange
        Test_BudgetDbContext _tdb = new Test_BudgetDbContext();
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        BudgetController budgetController = new BudgetController();
        Goal goal = new Goal();

        //Act
        var goal2 = budgetController.CreateGoal(goal);
        _tdb.Database.EnsureDeleted();

        //Assert
        Assert.True(goal2 != null); //
      }
    public void Test_CreateExpenseTest()
      {
        //Arrange
        Test_BudgetDbContext _tdb = new Test_BudgetDbContext();
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        BudgetController budgetController = new BudgetController();
        Expense expense = new Expense();

        //Act
        var expense2 = budgetController.CreateExpense(expense);
        _tdb.Database.EnsureDeleted();

        //Assert
        Assert.True(expense2 != null); //
      }
    }
}