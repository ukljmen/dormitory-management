using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorReferenceToAnnouncements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "DirectMessages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "efab6633-a55a-4b6b-ab98-a6a6c378707e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b98cd30f-c852-43ca-ae2a-885ba9b4d439");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f833dc9c-9620-4e0a-b059-108daff58b7a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "a0a086ce-72e8-4b08-b404-f38843cf4634");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "41a54f58-6f56-4db3-a404-c90057fbad47");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_ManagerId",
                table: "Announcements",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Managers_ManagerId",
                table: "Announcements",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Managers_ManagerId",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_ManagerId",
                table: "Announcements");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "DirectMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
