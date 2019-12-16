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



      protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
      {
        dbContext.UseNpgsql("server=localhost;database=postgres;user id=postgres;password=postgres");
      }

      protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.Entity<Member>(o => o.HasKey(k => k.Id));
        
        builder.Entity<Member>().Property(p => p.Id).UseSerialColumn();

        builder.Entity<Member>().HasData(new List<Member>()
        {
          new Member(){Id = 1, FirstName = "Jimmy", LastName ="C"},
        });
      }
    }
}