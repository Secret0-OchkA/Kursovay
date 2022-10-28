using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class addMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9220), new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9222) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9223), new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9223) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9224), new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9224) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
