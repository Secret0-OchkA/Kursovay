using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Context.Migrations
{
    public partial class addUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_roles_RoleId",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "employees");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "employees",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    createDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modifyDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 12, 16, 7, 44, 535, DateTimeKind.Unspecified).AddTicks(5786), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 12, 16, 7, 44, 535, DateTimeKind.Unspecified).AddTicks(5810), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 12, 16, 7, 44, 535, DateTimeKind.Unspecified).AddTicks(5817), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 12, 16, 7, 44, 535, DateTimeKind.Unspecified).AddTicks(5818), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 12, 16, 7, 44, 535, DateTimeKind.Unspecified).AddTicks(5820), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 12, 16, 7, 44, 535, DateTimeKind.Unspecified).AddTicks(5821), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_employees_UserId",
                table: "employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_RoleId",
                table: "users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_roles_RoleId",
                table: "employees",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_users_UserId",
                table: "employees",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_roles_RoleId",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_users_UserId",
                table: "employees");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropIndex(
                name: "IX_employees_UserId",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "employees");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "employees",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 12, 13, 57, 46, 353, DateTimeKind.Unspecified).AddTicks(1000), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 12, 13, 57, 46, 353, DateTimeKind.Unspecified).AddTicks(1023), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 12, 13, 57, 46, 353, DateTimeKind.Unspecified).AddTicks(1026), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 12, 13, 57, 46, 353, DateTimeKind.Unspecified).AddTicks(1027), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 12, 13, 57, 46, 353, DateTimeKind.Unspecified).AddTicks(1028), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 12, 13, 57, 46, 353, DateTimeKind.Unspecified).AddTicks(1029), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_employees_roles_RoleId",
                table: "employees",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
