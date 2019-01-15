using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.Infrastructure.Data.Migrations
{
    public partial class RefactoryEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Users_UserId",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Boards_UserId",
                table: "Boards");

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "Boards",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 1, 15, 12, 22, 15, 613, DateTimeKind.Local).AddTicks(9793), new DateTime(2019, 1, 15, 12, 22, 15, 613, DateTimeKind.Local).AddTicks(9860) });

            migrationBuilder.CreateIndex(
                name: "IX_Boards_UserEntityId",
                table: "Boards",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Users_UserEntityId",
                table: "Boards",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Users_UserEntityId",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Boards_UserEntityId",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Boards");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 1, 11, 11, 53, 42, 379, DateTimeKind.Local).AddTicks(3330), new DateTime(2019, 1, 11, 11, 53, 42, 379, DateTimeKind.Local).AddTicks(3363) });

            migrationBuilder.CreateIndex(
                name: "IX_Boards_UserId",
                table: "Boards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Users_UserId",
                table: "Boards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
