using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowMe.Data.Migrations
{
    public partial class AddUserCharacteristic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCharacteristic",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    CoverImageUrl = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 15, nullable: true),
                    LastName = table.Column<string>(maxLength: 15, nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: true),
                    Weight = table.Column<int>(nullable: true),
                    EyeColor = table.Column<int>(nullable: false),
                    WeddingStatus = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    WhatAreYouSearchingFor = table.Column<int>(nullable: false),
                    HairColor = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCharacteristic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCharacteristic_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCharacteristic_IsDeleted",
                table: "UserCharacteristic",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserCharacteristic_UserId",
                table: "UserCharacteristic",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCharacteristic");
        }
    }
}
