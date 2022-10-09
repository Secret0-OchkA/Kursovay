using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addCompanyInExpenseTyp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "expenseTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_expenseTypes_CompanyId",
                table: "expenseTypes",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_expenseTypes_Company_CompanyId",
                table: "expenseTypes",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenseTypes_Company_CompanyId",
                table: "expenseTypes");

            migrationBuilder.DropIndex(
                name: "IX_expenseTypes_CompanyId",
                table: "expenseTypes");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "expenseTypes");
        }
    }
}
