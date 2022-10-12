using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class changeTypeInRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_roles_RoleId",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_RoleId",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "employees");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2022, 10, 12, 14, 52, 1, 302, DateTimeKind.Utc).AddTicks(7017), new DateTime(2022, 10, 12, 14, 52, 1, 302, DateTimeKind.Utc).AddTicks(7019) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2022, 10, 12, 14, 52, 1, 302, DateTimeKind.Utc).AddTicks(7022), new DateTime(2022, 10, 12, 14, 52, 1, 302, DateTimeKind.Utc).AddTicks(7022) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2022, 10, 12, 14, 52, 1, 302, DateTimeKind.Utc).AddTicks(7023), new DateTime(2022, 10, 12, 14, 52, 1, 302, DateTimeKind.Utc).AddTicks(7023) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "employees",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2022, 10, 12, 13, 29, 1, 138, DateTimeKind.Utc).AddTicks(8930), new DateTime(2022, 10, 12, 13, 29, 1, 138, DateTimeKind.Utc).AddTicks(8933) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2022, 10, 12, 13, 29, 1, 138, DateTimeKind.Utc).AddTicks(8935), new DateTime(2022, 10, 12, 13, 29, 1, 138, DateTimeKind.Utc).AddTicks(8935) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2022, 10, 12, 13, 29, 1, 138, DateTimeKind.Utc).AddTicks(8936), new DateTime(2022, 10, 12, 13, 29, 1, 138, DateTimeKind.Utc).AddTicks(8936) });

            migrationBuilder.CreateIndex(
                name: "IX_employees_RoleId",
                table: "employees",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_roles_RoleId",
                table: "employees",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id");
        }
    }
}
