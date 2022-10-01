using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addBugetPlanToDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bugetPlans_departments_DepartmentId",
                table: "bugetPlans");

            migrationBuilder.DropIndex(
                name: "IX_bugetPlans_DepartmentId",
                table: "bugetPlans");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "bugetPlans");

            migrationBuilder.AddColumn<int>(
                name: "BugetPlanId",
                table: "departments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_departments_BugetPlanId",
                table: "departments",
                column: "BugetPlanId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_departments_bugetPlans_BugetPlanId",
                table: "departments",
                column: "BugetPlanId",
                principalTable: "bugetPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_bugetPlans_BugetPlanId",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_departments_BugetPlanId",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "BugetPlanId",
                table: "departments");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "bugetPlans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bugetPlans_DepartmentId",
                table: "bugetPlans",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_bugetPlans_departments_DepartmentId",
                table: "bugetPlans",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
