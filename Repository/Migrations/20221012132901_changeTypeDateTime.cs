using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class changeTypeDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
