using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.Infrastructure.Data.Migrations
{
    public partial class RemoveSurnameOfUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 1, 21, 12, 9, 17, 993, DateTimeKind.Local).AddTicks(2546), new DateTime(2019, 1, 21, 12, 9, 17, 993, DateTimeKind.Local).AddTicks(2582) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Users",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Surname", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 1, 15, 14, 23, 42, 556, DateTimeKind.Local).AddTicks(8112), "root", new DateTime(2019, 1, 15, 14, 23, 42, 556, DateTimeKind.Local).AddTicks(8147) });
        }
    }
}
