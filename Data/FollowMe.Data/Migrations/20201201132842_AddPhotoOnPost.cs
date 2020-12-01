using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowMe.Data.Migrations
{
    public partial class AddPhotoOnPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PhotoId",
                table: "Posts",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Photos_PhotoId",
                table: "Posts",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Photos_PhotoId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PhotoId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Posts");
        }
    }
}
