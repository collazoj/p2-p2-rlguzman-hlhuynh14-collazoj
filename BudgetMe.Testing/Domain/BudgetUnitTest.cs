using BudgetMe.Domain.Controllers;
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
      Assert.True(actual.ToString() == "200");
    }
  //  [Theory]
  //   [InlineData(1)]
  //   [InlineData(2)]
  //   [InlineData(3)]
  //   public void Test_GetPokemon(int id)
  //   {
  //     var sut = new PokemonController();
  //     var actual = sut.Get(id);

  //     Assert.False(string.IsNullOrWhiteSpace(actual.Name));      
  //   }

  }
}