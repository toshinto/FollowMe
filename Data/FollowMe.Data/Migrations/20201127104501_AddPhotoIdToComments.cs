using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowMe.Data.Migrations
{
    public partial class AddPhotoIdToComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PhotoId",
                table: "Comments",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Photos_PhotoId",
                table: "Comments",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Photos_PhotoId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PhotoId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Comments");
        }
    }
}
