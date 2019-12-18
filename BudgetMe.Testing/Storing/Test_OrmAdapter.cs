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

      private Test_BudgetDbContext _tdb = new Test_BudgetDbContext();

      [Fact]
      public void Test_TestDbContext()
      {
        //Arrange
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);

        //Act
        var members = _tdb.Member.ToList();
        _tdb.Database.EnsureDeleted();

        //Assert
        Assert.True(members.Count()!=0); //Should be 4. Passes.
      }

      [Fact]
      public void TestOrmAdapter_Get1()
      {
        _tdb.Database.EnsureCreated();
        
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        List<Income> incomes = _oa.GetIncomes();
        _tdb.Database.EnsureDeleted();

        Assert.True(incomes.Count!=0);
      }

      [Fact]
      public void TestOrmAdapter_Get2()
      {
        _tdb.Database.EnsureCreated();
        
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        List<Bill> bills = _oa.GetBills();
        _tdb.Database.EnsureDeleted();

        Assert.True(bills.Count!=0);
      }

      [Fact]
      public void TestOrmAdapter_Insert1()
      {
        //Arrange
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);

        //Act
        bool insertincomebool = _oa.InsertIncome(new Income(){Id = 100, Name="Lockheed", Amount=10000});
        Income income = _tdb.Income.Where(m => m.Id == 100).SingleOrDefault();
        string name = income.Name;
        _tdb.Database.EnsureDeleted();

        //Assert
        Assert.True(name == "Lockheed");
      }

      [Fact]
      public void TestOrmAdapter_Insert2()
      {
        //Arrange
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);

        //Act
        bool insertbillbool = _oa.InsertBill(new Bill(){Id = 99, Name="testbill"});
        Bill bill = _tdb.Bill.Where(b => b.Id == 99).SingleOrDefault();
        string name = bill.Name;
        _tdb.Database.EnsureDeleted();

        //Assert
        Assert.True(name == "testbill");
      }

      [Fact]
      public void TestOrmAdapter_Update1()
      {
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        
        Income income = _tdb.Income.Where(m => m.Id == 1).SingleOrDefault();
        income.Name = "Great job";
        _oa.UpdateIncome(income);

        Income inc = _tdb.Income.Where(m => m.Id == 1).SingleOrDefault();
        string newName = inc.Name;
        _tdb.Database.EnsureDeleted();

        Assert.True(newName=="Great job");
      }

      [Fact]
      public void TestOrmAdapter_Update2()
      {
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        
        Bill bill = _tdb.Bill.Where(b => b.Id == 1).SingleOrDefault();
        bill.Name = "Orange Juice";
        _oa.UpdateBill(bill);

        Bill bill1 = _tdb.Bill.Where(b => b.Id == 1).SingleOrDefault();
        string newName = bill1.Name;
        _tdb.Database.EnsureDeleted();

        Assert.True(newName=="Orange Juice");
      }

      [Fact]
      public void TestOrmAdapter_Remove1()
      {
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        int IncomeCount = _oa.GetIncomes().Count();

        _oa.RemoveIncome(1);
        int newIncomeCount = _oa.GetIncomes().Count();
        _tdb.Database.EnsureDeleted();

        Assert.True(newIncomeCount==IncomeCount-1);
      }

      [Fact]
      public void TestOrmAdapter_Remove2()
      {
        _tdb.Database.EnsureCreated();
        OrmAdapter<Test_BudgetDbContext> _oa = new OrmAdapter<Test_BudgetDbContext>(_tdb);
        int BillCount = _oa.GetBills().Count();

        _oa.RemoveBill(1);
        int newBillCount = _oa.GetBills().Count();
        _tdb.Database.EnsureDeleted();

        Assert.True(newBillCount==BillCount-1);
      }

    }
}