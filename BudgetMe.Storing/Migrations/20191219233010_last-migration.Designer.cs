﻿// <auto-generated />
using System;
using BudgetMe.Storing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BudgetMe.Storing.Migrations
{
    [DbContext(typeof(BudgetDbContext))]
    [Migration("20191219233010_last-migration")]
    partial class lastmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BudgetMe.Storing.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int?>("BudgetId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("BudgetMe.Storing.Models.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int?>("MemberId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Percent")
                        .HasColumnType("double precision");

                    b.Property<double>("RemainderAfterBill")
                        .HasColumnType("double precision");

                    b.Property<double>("RemainderAfterExpenses")
                        .HasColumnType("double precision");

                    b.Property<double>("RemainderAfterGoals")
                        .HasColumnType("double precision");

                    b.Property<double>("TotalMonthlyNetIncome")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("Budget");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MemberId = 1,
                            Name = "jimmybudget",
                            Percent = 0.0,
                            RemainderAfterBill = 0.0,
                            RemainderAfterExpenses = 0.0,
                            RemainderAfterGoals = 0.0,
                            TotalMonthlyNetIncome = 0.0
                        });
                });

            modelBuilder.Entity("BudgetMe.Storing.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int?>("BudgetId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Percent")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("Expense");
                });

            modelBuilder.Entity("BudgetMe.Storing.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int?>("BudgetId")
                        .HasColumnType("integer");

                    b.Property<double>("EstimatedHighLoan")
                        .HasColumnType("double precision");

                    b.Property<double>("EstimatedHighTotal")
                        .HasColumnType("double precision");

                    b.Property<double>("EstimatedLowLoan")
                        .HasColumnType("double precision");

                    b.Property<double>("EstimatedLowTotal")
                        .HasColumnType("double precision");

                    b.Property<double>("GoalSavingsPerMonth")
                        .HasColumnType("double precision");

                    b.Property<double>("GoalsSavings")
                        .HasColumnType("double precision");

                    b.Property<double>("InterestRate")
                        .HasColumnType("double precision");

                    b.Property<int>("LoanTermInYears")
                        .HasColumnType("integer");

                    b.Property<int>("MonthGoals")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("Goal");
                });

            modelBuilder.Entity("BudgetMe.Storing.Models.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int?>("BudgetId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("Income");
                });

            modelBuilder.Entity("BudgetMe.Storing.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Member");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Jimmy",
                            LastName = "C"
                        });
                });

            modelBuilder.Entity("BudgetMe.Storing.Models.Bill", b =>
                {
                    b.HasOne("BudgetMe.Storing.Models.Budget", "Budget")
                        .WithMany("BillList")
                        .HasForeignKey("BudgetId");
                });

            modelBuilder.Entity("BudgetMe.Storing.Models.Budget", b =>
                {
                    b.HasOne("BudgetMe.Storing.Models.Member", "Member")
                        .WithOne("Budget")
                        .HasForeignKey("BudgetMe.Storing.Models.Budget", "MemberId");
                });

            modelBuilder.Entity("BudgetMe.Storing.Models.Expense", b =>
                {
                    b.HasOne("BudgetMe.Storing.Models.Budget", "Budget")
                        .WithMany("ExpenseList")
                        .HasForeignKey("BudgetId");
                });

            modelBuilder.Entity("BudgetMe.Storing.Models.Goal", b =>
                {
                    b.HasOne("BudgetMe.Storing.Models.Budget", "Budget")
                        .WithMany("GoalList")
                        .HasForeignKey("BudgetId");
                });

            modelBuilder.Entity("BudgetMe.Storing.Models.Income", b =>
                {
                    b.HasOne("BudgetMe.Storing.Models.Budget", "Budget")
                        .WithMany("IncomeList")
                        .HasForeignKey("BudgetId");
                });
#pragma warning restore 612, 618
        }
    }
}
