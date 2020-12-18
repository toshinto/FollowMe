using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowMe.Data.Migrations
{
    public partial class AddCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
