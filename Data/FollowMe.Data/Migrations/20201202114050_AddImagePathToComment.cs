using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowMe.Data.Migrations
{
    public partial class AddImagePathToComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Comments");
        }
    }
}
