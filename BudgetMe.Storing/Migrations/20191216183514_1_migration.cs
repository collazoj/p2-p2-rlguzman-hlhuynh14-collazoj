using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BudgetMe.Storing.Migrations
{
    public partial class _1_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    MemberId = table.Column<int>(nullable: true),
                    TotalMonthlyNetIncome = table.Column<double>(nullable: false),
                    RemainderAfterBill = table.Column<double>(nullable: false),
                    RemainderAfterGoals = table.Column<double>(nullable: false),
                    Percent = table.Column<double>(nullable: false),
                    RemainderAfterExpenses = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budget_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    BudgetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Percent = table.Column<double>(nullable: false),
                    BudgetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    GoalsSavings = table.Column<double>(nullable: false),
                    EstimatedHighLoan = table.Column<double>(nullable: false),
                    EstimatedLowLoan = table.Column<double>(nullable: false),
                    GoalSavingsPerMonth = table.Column<double>(nullable: false),
                    MonthGoals = table.Column<int>(nullable: false),
                    EstimatedHighTotal = table.Column<double>(nullable: false),
                    EstimatedLowTotal = table.Column<double>(nullable: false),
                    LoanTermInYears = table.Column<int>(nullable: false),
                    InterestRate = table.Column<double>(nullable: false),
                    BudgetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goal_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Income",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    BudgetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Income_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "Jimmy", "C" });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_BudgetId",
                table: "Bill",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_MemberId",
                table: "Budget",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_BudgetId",
                table: "Expense",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_BudgetId",
                table: "Goal",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Income_BudgetId",
                table: "Income",
                column: "BudgetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "Income");

            migrationBuilder.DropTable(
                name: "Budget");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
