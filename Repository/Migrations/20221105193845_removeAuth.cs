using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Context.Migrations
{
    public partial class removeAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_users_UserId",
                table: "employees");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropIndex(
                name: "IX_employees_UserId",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "employees");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "employees",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "employees");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    createDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modifyDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    createDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modifyDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "Name", "createDate", "modifyDate" },
                values: new object[,]
                {
                    { 1, "owner", new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9220), new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9222) },
                    { 2, "accountant", new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9223), new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9223) },
                    { 3, "user", new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9224), new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9224) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_UserId",
                table: "employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_RoleId",
                table: "users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_users_UserId",
                table: "employees",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
