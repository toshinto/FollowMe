using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowMe.Data.Migrations
{
    public partial class WorkOnDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserDescription",
                table: "UserCharacteristics");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserCharacteristics",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserCharacteristics");

            migrationBuilder.AddColumn<string>(
                name: "UserDescription",
                table: "UserCharacteristics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
