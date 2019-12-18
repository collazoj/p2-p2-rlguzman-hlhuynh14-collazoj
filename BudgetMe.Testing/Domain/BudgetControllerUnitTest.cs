using System.Linq;
using BudgetMe.Domain.Controllers;
using BudgetMe.Storing;
using BudgetMe.Storing.Adapters;
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
    }
}