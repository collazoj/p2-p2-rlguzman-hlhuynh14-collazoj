using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetMe.Storing.Migrations
{
    public partial class _4_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Budget",
                keyColumn: "Id",
                keyValue: 1,
                column: "MemberId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Budget",
                keyColumn: "Id",
                keyValue: 1,
                column: "MemberId",
                value: null);
        }
    }
}
