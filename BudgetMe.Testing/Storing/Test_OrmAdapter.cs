using System.Collections.Generic;
using System.Linq;
using BudgetMe.Storing;
using BudgetMe.Storing.Adapters;
using BudgetMe.Storing.Models;
using Xunit;

namespace BudgetMe.Testing.Storing
{
    public class Test_OrmAdapter
    {
      [Fact]
      public void Test_TestDbContext()
      {
        //Arrange
        Test_BudgetDbContext tdb = new Test_BudgetDbContext();
        tdb.Database.EnsureCreated();

        //Act
        var members = tdb.Member;

        //Assert
        Assert.True(members.Count()!=0); //Should be 4. Passes.
      }

      // [Fact]
      // public void TestOrmAdapter_Insert()
      // {
      //   //Arrange
      //   Test_BudgetDbContext tdb = new Test_BudgetDbContext();
      //   OrmAdapter<Test_BudgetDbContext> oa = new OrmAdapter<Test_BudgetDbContext>(tdb);

      //   //Act
      //   Member m = new Member(){Id=10, FirstName="Henry", LastName="H"};
      //   bool a = oa.InsertMember(m);

      //   List<Member> memberlist = oa.GetMembers();
      //   Member member = memberlist.Where(m => m.Id == 10).SingleOrDefault();

      //   //Assert
      //   Assert.NotNull(member);
      // }

    }
}