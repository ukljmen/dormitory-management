using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixConservatorToProblems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Conservators_ConservatorId1",
                table: "Problems");

            migrationBuilder.DropIndex(
                name: "IX_Problems_ConservatorId1",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "ConservatorId1",
                table: "Problems");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6a14ff04-480b-4a11-8b0b-2947193cea32");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "014df9ef-11d0-4111-9d88-de790d2c4059");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "c365744a-d0f7-41f1-9a01-6db99e9850e3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "56a40865-46df-42f2-b599-6f999790fc99");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a4617930-09d8-4174-a0b6-fe9e661951f5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConservatorId1",
                table: "Problems",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ce9ccc71-c79b-4943-b27b-4a763ed0a692");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "67c09c01-5108-46f7-99d9-2f6e62c0a418");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "c86cfd6b-d260-49a2-b180-813c7763d3d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "6d5ba650-5e27-4b17-be1e-46f446ce9cb8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "5704a836-6e27-462f-a7c8-af7926927a96");

            migrationBuilder.CreateIndex(
                name: "IX_Problems_ConservatorId1",
                table: "Problems",
                column: "ConservatorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Conservators_ConservatorId1",
                table: "Problems",
                column: "ConservatorId1",
                principalTable: "Conservators",
                principalColumn: "Id");
        }
    }
}
