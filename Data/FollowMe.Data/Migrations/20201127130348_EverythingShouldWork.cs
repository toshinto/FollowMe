using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowMe.Data.Migrations
{
    public partial class EverythingShouldWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SentById",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SentById",
                table: "Comments",
                column: "SentById");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_SentById",
                table: "Comments",
                column: "SentById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_SentById",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SentById",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SentById",
                table: "Comments");
        }
    }
}
