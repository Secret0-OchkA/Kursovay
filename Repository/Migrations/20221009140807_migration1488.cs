using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class migration1488 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bugetPlans_departments_DeparmentId",
                table: "bugetPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_departments_companies_CompanyId",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_departments_DepartmentId",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_expenses_departments_DepartmentId",
                table: "expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departments",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_departments_CompanyId",
                table: "departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companies",
                table: "companies");

            migrationBuilder.RenameTable(
                name: "departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "companies",
                newName: "Company");

            migrationBuilder.AlterColumn<int>(
                name: "employeeId",
                table: "expenses",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Department_CompanyId_Name",
                table: "Department",
                columns: new[] { "CompanyId", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bugetPlans_Department_DeparmentId",
                table: "bugetPlans",
                column: "DeparmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Company_CompanyId",
                table: "Department",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_Department_DepartmentId",
                table: "employees",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_Department_DepartmentId",
                table: "expenses",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bugetPlans_Department_DeparmentId",
                table: "bugetPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Company_CompanyId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_Department_DepartmentId",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_expenses_Department_DepartmentId",
                table: "expenses");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Department_CompanyId_Name",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "departments");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "companies");

            migrationBuilder.AlterColumn<int>(
                name: "employeeId",
                table: "expenses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_departments",
                table: "departments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companies",
                table: "companies",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_departments_CompanyId",
                table: "departments",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_bugetPlans_departments_DeparmentId",
                table: "bugetPlans",
                column: "DeparmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_departments_companies_CompanyId",
                table: "departments",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_departments_DepartmentId",
                table: "employees",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_departments_DepartmentId",
                table: "expenses",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
