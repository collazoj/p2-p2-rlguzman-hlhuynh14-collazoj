using System.Collections.Generic;
using BudgetMe.Storing.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetMe.Storing
{
    public class Test_BudgetDbContext : BudgetDbContext
    {

      protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
      {
        dbContext.UseInMemoryDatabase("testbudgetdb");
      }

      protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.Entity<Member>(o => o.HasKey(k => k.Id));
        builder.Entity<Member>().Property(p => p.Id).UseSerialColumn();
        builder.Entity<Member>().HasData(MakeSeedMembers());

        builder.Entity<Budget>(o => o.HasKey(k => k.Id));
        builder.Entity<Budget>().Property(p => p.Id).UseSerialColumn();
        builder.Entity<Budget>().HasData(new List<Budget>()
        {
          new Budget(){Id = 1, Name = "jimmybudget", MemberId=1, TotalMonthlyNetIncome=0, RemainderAfterBill=0, RemainderAfterGoals=0, Percent=0, RemainderAfterExpenses=0}
        });

        builder.Entity<Income>(o => o.HasKey(k => k.Id));
        builder.Entity<Income>().Property(p => p.Id).UseSerialColumn();
        builder.Entity<Income>().HasData(MakeSeedIncomes());

        builder.Entity<Bill>(o => o.HasKey(k => k.Id));
        builder.Entity<Bill>().Property(p => p.Id).UseSerialColumn();
        builder.Entity<Bill>().HasData(MakeSeedBills());
      }


      public List<Member> MakeSeedMembers()
      {
        return new List<Member>(){
          new Member(){Id = 1, FirstName = "Jimmy", LastName ="Collazo"},
          new Member(){Id = 2, FirstName = "Henry", LastName="Huynh"},
          new Member(){Id = 3, FirstName = "John", LastName="Harvey"},
          new Member(){Id = 4, FirstName = "Roberto", LastName="Guzman"}
        };
      }
      public List<Income> MakeSeedIncomes()
      {
        return new List<Income>(){
          new Income(){Id = 1, Name = "Wells Fargo", Amount = 3750},
          new Income(){Id = 2, Name = "Trading", Amount= 400},
          new Income(){Id = 3, Name = "Side Job", Amount= 300},
        };
      }
      public List<Bill> MakeSeedBills()
      {
        return new List<Bill>(){
          new Bill(){Id = 1, Name = "Rent", Amount = 500},
          new Bill(){Id = 2, Name = "Utilities", Amount= 200},
          new Bill(){Id = 3, Name = "Phone", Amount= 70},
        };
      }
    }
}