using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowMe.Data.Migrations
{
    public partial class AddUserCharacteristicDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCharacteristic_AspNetUsers_UserId",
                table: "UserCharacteristic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCharacteristic",
                table: "UserCharacteristic");

            migrationBuilder.RenameTable(
                name: "UserCharacteristic",
                newName: "UserCharacteristics");

            migrationBuilder.RenameIndex(
                name: "IX_UserCharacteristic_UserId",
                table: "UserCharacteristics",
                newName: "IX_UserCharacteristics_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCharacteristic_IsDeleted",
                table: "UserCharacteristics",
                newName: "IX_UserCharacteristics_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCharacteristics",
                table: "UserCharacteristics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCharacteristics_AspNetUsers_UserId",
                table: "UserCharacteristics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCharacteristics_AspNetUsers_UserId",
                table: "UserCharacteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCharacteristics",
                table: "UserCharacteristics");

            migrationBuilder.RenameTable(
                name: "UserCharacteristics",
                newName: "UserCharacteristic");

            migrationBuilder.RenameIndex(
                name: "IX_UserCharacteristics_UserId",
                table: "UserCharacteristic",
                newName: "IX_UserCharacteristic_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCharacteristics_IsDeleted",
                table: "UserCharacteristic",
                newName: "IX_UserCharacteristic_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCharacteristic",
                table: "UserCharacteristic",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCharacteristic_AspNetUsers_UserId",
                table: "UserCharacteristic",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
