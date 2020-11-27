using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowMe.Data.Migrations
{
    public partial class RemoveInversPropertiesOfAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SentById",
                table: "Photos",
                type: "nvarchar(450)",
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
    }
}
