using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowMe.Data.Migrations
{
    public partial class AddSentByToPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SentById",
                table: "Photos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_SentById",
                table: "Photos",
                column: "SentById");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_SentById",
                table: "Photos",
                column: "SentById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_SentById",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_SentById",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "SentById",
                table: "Photos");
        }
    }
}
