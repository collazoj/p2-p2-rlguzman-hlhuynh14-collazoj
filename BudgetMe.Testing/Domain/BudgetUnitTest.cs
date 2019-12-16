using BudgetMe.Domain.Controllers;
using BudgetMe.Domain.Models;
using Xunit;

namespace BudgetMe.Testing.Domain
{
  public class BudgetUnitTest
  {
    [Theory]
    [InlineData("Bob", 1000)]
    public async void Test_CreateIncome(string name, int amount)
    {
    // arrange 
      var sut = new BudgetController();
    // act
      var actual = await sut.CreateIncome(name, amount);
    // assert
      
      // Assert.IsType<Income>(actual);
      Assert.NotNull(actual);
    }
  }
}