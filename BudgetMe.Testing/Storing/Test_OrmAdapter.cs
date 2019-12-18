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
        Test_BudgetDbContext _tdb = new Test_BudgetDbContext();
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        _oa.InsertMember(new Member(){Id = 120, FirstName="Fred", LastName="B"});


        //Act
        var members = _tdb.Member.ToList();

        //Assert
        Assert.True(members.Count()!=0); //Should be 4. Passes.
      }

      [Fact]
      public void TestOrmAdapter_Insert()
      {
        //Arrange
        Test_BudgetDbContext _tdb = new Test_BudgetDbContext();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);

        //Act
        bool insertmemberbool = _oa.InsertMember(new Member(){Id = 20, FirstName="Fred", LastName="B"});
        Member member = _tdb.Member.Where(m => m.Id == 20).SingleOrDefault();
        string last = member.LastName;
        _oa.RemoveMember(20);

        //Assert
        Assert.True(last == "B");
      }

      [Fact]
      public void TestOrmAdapter_Get()
      {
        Test_BudgetDbContext _tdb = new Test_BudgetDbContext();
        
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        _oa.InsertMember(new Member(){FirstName="Fred", LastName="B"});
        List<Member> members = _oa.GetMembers();

        Assert.True(members.Count!=0);
      }

      // [Fact]
      // public void TestOrmAdapter_Update()
      // {
      //   Test_BudgetDbContext _tdb = new Test_BudgetDbContext();
      //   _tdb.Database.EnsureCreated();
      //   OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        
      //   Member member = _tdb.Member.Where(m => m.Id == 1).SingleOrDefault();
      //   member.FirstName = "Brad";
      //   member.LastName = "Pitt";
      //   _oa.UpdateMember(member);

      //   Member mem = _tdb.Member.Where(m => m.LastName == "Pitt").SingleOrDefault();
      //   string newFirstName = mem.FirstName;

      //   Member member1 = _tdb.Member.Where(m => m.Id == 1).SingleOrDefault();
      //   member1.FirstName = "Jimmy";
      //   member1.LastName = "Collazo";
      //   _oa.UpdateMember(member1);

      //   Assert.True(newFirstName=="Brad");
      // }

      [Fact]
      public void TestOrmAdapter_Remove()
      {
        Test_BudgetDbContext _tdb = new Test_BudgetDbContext();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        _oa.InsertMember(new Member(){Id = 21, FirstName="Fred", LastName="B"});
        int MemberCount = _oa.GetMembers().Count();

        _oa.RemoveMember(21);
        int newMemberCount = _oa.GetMembers().Count();

        Assert.True(newMemberCount==MemberCount-1);
      }

    }
}