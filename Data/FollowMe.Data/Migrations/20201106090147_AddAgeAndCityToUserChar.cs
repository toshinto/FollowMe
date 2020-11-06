using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowMe.Data.Migrations
{
    public partial class AddAgeAndCityToUserChar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "UserCharacteristics",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "City",
                table: "UserCharacteristics",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "UserCharacteristics");

            migrationBuilder.DropColumn(
                name: "City",
                table: "UserCharacteristics");
        }
    }
}
