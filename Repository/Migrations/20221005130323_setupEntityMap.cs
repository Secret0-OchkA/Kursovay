using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class setupEntityMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companies_users_UserId",
                table: "companies");

            migrationBuilder.DropForeignKey(
                name: "FK_departments_bugetPlans_BugetPlanId",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "FK_expenses_users_employeeId",
                table: "expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_users_departments_DepartmentId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_RoleId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_departments_BugetPlanId",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_companies_UserId",
                table: "companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "bugetPlans");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "employees");

            migrationBuilder.RenameIndex(
                name: "IX_users_RoleId",
                table: "employees",
                newName: "IX_employees_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_users_DepartmentId",
                table: "employees",
                newName: "IX_employees_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_bugetPlans_DeparmentId",
                table: "bugetPlans",
                column: "DeparmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_bugetPlans_departments_DeparmentId",
                table: "bugetPlans",
                column: "DeparmentId",
                principalTable: "departments",
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
                name: "FK_employees_roles_RoleId",
                table: "employees",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_employees_employeeId",
                table: "expenses",
                column: "employeeId",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bugetPlans_departments_DeparmentId",
                table: "bugetPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_departments_DepartmentId",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_roles_RoleId",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_expenses_employees_employeeId",
                table: "expenses");

            migrationBuilder.DropIndex(
                name: "IX_bugetPlans_DeparmentId",
                table: "bugetPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "users");

            migrationBuilder.RenameIndex(
                name: "IX_employees_RoleId",
                table: "users",
                newName: "IX_users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_employees_DepartmentId",
                table: "users",
                newName: "IX_users_DepartmentId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "expenses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "companies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "bugetPlans",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_departments_BugetPlanId",
                table: "departments",
                column: "BugetPlanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_companies_UserId",
                table: "companies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_companies_users_UserId",
                table: "companies",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_departments_bugetPlans_BugetPlanId",
                table: "departments",
                column: "BugetPlanId",
                principalTable: "bugetPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_users_employeeId",
                table: "expenses",
                column: "employeeId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_departments_DepartmentId",
                table: "users",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_RoleId",
                table: "users",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
