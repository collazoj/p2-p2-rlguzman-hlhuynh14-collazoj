using BudgetMe.Client.Controllers;
using Xunit;

namespace SaveEm.Testing.Client
{
    public class HomeControllerUnitTest
    {
      [Fact]
      public void TestLogin()
      {
      //Arrange
      var sut = new HomeController();
      //Act
      var login = sut.Login();
      //Assert
      Assert.NotNull(login);
      }

      [Fact]
      public void TestIndex()
      {
      var sut = new HomeController();
      var index = sut.Index();
      
      Assert.NotNull(index);
      }

      [Fact]
      public void TestSignUp()
      {
      var sut = new HomeController();
      var signup = sut.Signup();

      Assert.NotNull(signup);
      }
      [Fact]
      public void TestAbout()
      {
      var sut = new HomeController();
      var about = sut.About();

      Assert.NotNull(about);
      }
      [Fact]
      public void TestContact()
      {
      var sut = new HomeController();
      var contact = sut.Contact();

      Assert.NotNull(contact);
      }
    }
}