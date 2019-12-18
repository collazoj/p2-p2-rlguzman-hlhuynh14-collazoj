using System.Collections.Generic;
using System.Linq;
using BudgetMe.Storing;
using BudgetMe.Storing.Models;
using BudgetMe.Storing.Repositories;
using Xunit;

namespace BudgetMe.Testing.Storing
{
    public class Test_MemberRepo
    {
        [Fact]
        public void TestMemberRepo_Get1()
        {
          //Arrange
          Test_BudgetDbContext tdb = new Test_BudgetDbContext();
          tdb.Database.EnsureCreated();
          MemberRepository<Test_BudgetDbContext> _mr = new MemberRepository<Test_BudgetDbContext>(tdb);
          
          //Act
          List<Bill> blist = _mr.GetBills();
          
          //Assert
          tdb.Database.EnsureDeleted();
          Assert.True(blist.Count()!=0);
        }

        [Fact]
        public void TestMemberRepo_Get2()
        {
          Test_BudgetDbContext tdb = new Test_BudgetDbContext();
          tdb.Database.EnsureCreated();
          MemberRepository<Test_BudgetDbContext> _mr = new MemberRepository<Test_BudgetDbContext>(tdb);
          
          List<Income> ilist = _mr.GetIncomes();
          
          tdb.Database.EnsureDeleted();
          Assert.True(ilist.Count()!=0);
        }

        [Fact]
        public void TestMemberRepo_GetBill()
        {
          Test_BudgetDbContext tdb = new Test_BudgetDbContext();
          tdb.Database.EnsureCreated();
          MemberRepository<Test_BudgetDbContext> _mr = new MemberRepository<Test_BudgetDbContext>(tdb);

          Bill bill = _mr.GetBill(2);
          string a = bill.Name;
          
          tdb.Database.EnsureDeleted();
          Assert.True(a=="Utilities");
        }
        
    }
}