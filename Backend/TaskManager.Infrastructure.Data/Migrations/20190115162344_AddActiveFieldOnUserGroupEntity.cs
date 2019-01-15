using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.Infrastructure.Data.Migrations
{
    public partial class AddActiveFieldOnUserGroupEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "UserGroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 1, 15, 14, 23, 42, 556, DateTimeKind.Local).AddTicks(8112), new DateTime(2019, 1, 15, 14, 23, 42, 556, DateTimeKind.Local).AddTicks(8147) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "UserGroups");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 1, 15, 12, 22, 15, 613, DateTimeKind.Local).AddTicks(9793), new DateTime(2019, 1, 15, 12, 22, 15, 613, DateTimeKind.Local).AddTicks(9860) });
        }
    }
}
