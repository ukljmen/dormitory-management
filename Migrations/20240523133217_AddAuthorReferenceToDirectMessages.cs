using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorReferenceToDirectMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                value: "d4edacf2-7f8d-40d1-bc2a-f664e25e5393");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5912627f-8446-4fb5-bbe6-ecbbcdeba819");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "79bc0940-4103-4c97-8ef1-abcf8f74db6c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "618dd7ab-7262-425a-8696-3c3a6b31cafd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d4b03f93-115b-46f3-ba41-f1093aeac6f4");

            migrationBuilder.CreateIndex(
                name: "IX_DirectMessages_ManagerId",
                table: "DirectMessages",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectMessages_Managers_ManagerId",
                table: "DirectMessages",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectMessages_Managers_ManagerId",
                table: "DirectMessages");

            migrationBuilder.DropIndex(
                name: "IX_DirectMessages_ManagerId",
                table: "DirectMessages");

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
        }
    }
}
