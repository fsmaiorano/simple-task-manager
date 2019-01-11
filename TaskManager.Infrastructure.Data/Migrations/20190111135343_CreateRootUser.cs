using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.Infrastructure.Data.Migrations
{
    public partial class CreateRootUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedAt", "Email", "Name", "Password", "Surname", "UpdatedAt", "UrlPhoto" },
                values: new object[] { 1, true, new DateTime(2019, 1, 11, 11, 53, 42, 379, DateTimeKind.Local).AddTicks(3330), "root@root.com", "root", "123", "root", new DateTime(2019, 1, 11, 11, 53, 42, 379, DateTimeKind.Local).AddTicks(3363), "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
