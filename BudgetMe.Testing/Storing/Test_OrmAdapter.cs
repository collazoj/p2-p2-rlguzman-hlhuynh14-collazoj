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
      public void Test_GetMember()
      {
        //Arrange
        Test_BudgetDbContext tdb = new Test_BudgetDbContext();
        BudgetDbContext db = new BudgetDbContext();

        //Act
        OrmAdapter<BudgetDbContext> oa = new OrmAdapter<BudgetDbContext>(db);
        List<Member> memberslist = oa.GetMembers();
        Member a = memberslist[0];

        //Assert
        Assert.True(memberslist.Count!=0);
      }

      [Fact]
      public void TestOrmAdapter_Insert()
      {
        //Arrange
        Test_BudgetDbContext tdb = new Test_BudgetDbContext();
        OrmAdapter<Test_BudgetDbContext> oa = new OrmAdapter<Test_BudgetDbContext>(tdb);

        //Act
        Member m = new Member(){Id=10, FirstName="Henry", LastName="H"};
        bool a = oa.InsertMember(m);

        List<Member> memberlist = oa.GetMembers();
        Member member = memberlist.Where(m => m.Id == 10).SingleOrDefault();

        //Assert
        Assert.NotNull(member);
      }

      [Fact]
      public void TestName()
      {
      //Given
      
      //When
      
      //Then
      }
    }
}