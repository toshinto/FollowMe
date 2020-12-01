using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowMe.Data.Migrations
{
    public partial class AddOneToOneRelationShipPhotoAndUserChar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoId",
                table: "UserCharacteristics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCharacteristics_PhotoId",
                table: "UserCharacteristics",
                column: "PhotoId",
                unique: true,
                filter: "[PhotoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCharacteristics_Photos_PhotoId",
                table: "UserCharacteristics",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCharacteristics_Photos_PhotoId",
                table: "UserCharacteristics");

            migrationBuilder.DropIndex(
                name: "IX_UserCharacteristics_PhotoId",
                table: "UserCharacteristics");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "UserCharacteristics");
        }
    }
}
