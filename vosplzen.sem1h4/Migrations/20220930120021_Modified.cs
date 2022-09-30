using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vosplzen.sem1h4.Migrations
{
    public partial class Modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modified",
                table: "AspNetUsers");
        }
    }
}
