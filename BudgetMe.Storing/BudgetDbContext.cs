using System.Collections.Generic;
using BudgetMe.Storing.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetMe.Storing
{
    public class BudgetDbContext : DbContext
    {
      public DbSet<Bill> Bill { get; set; }
      public DbSet<Budget> Budget { get; set; }
      public DbSet<Expense> Expense { get; set; }
      public DbSet<Goal> Goal { get; set; }
      public DbSet<Income> Income { get; set; }
      public DbSet<Member> Member { get; set; }

      public BudgetDbContext(DbContextOptions<BudgetDbContext> options)
      : base(options)
      {
        
      }
      public BudgetDbContext()
      {
      }

      protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
      {
        dbContext.UseNpgsql("server=db;database=budgetdb;user id=postgres;password=postgres");
      }

      protected override void OnModelCreating(ModelBuilder builder)
      {

        base.OnModelCreating(builder);
        
        builder.Entity<Member>(o => o.HasKey(k => k.Id));
        
        builder.Entity<Member>().Property(p => p.Id).UseSerialColumn();

        builder.Entity<Member>().HasData(new List<Member>()
        {
          new Member(){Id = 1, FirstName = "Jimmy", LastName ="C"},
        });

        builder.Entity<Budget>(o => o.HasKey(k => k.Id));

        builder.Entity<Budget>().Property(p => p.Id).UseSerialColumn();

        builder.Entity<Budget>().HasData(new List<Budget>()
        {
          new Budget(){Id = 1, Name = "jimmybudget", MemberId=1, TotalMonthlyNetIncome=0, RemainderAfterBill=0, RemainderAfterGoals=0, Percent=0, RemainderAfterExpenses=0}
        });

      }
    }
}