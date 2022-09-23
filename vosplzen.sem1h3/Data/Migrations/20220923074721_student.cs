using Microsoft.EntityFrameworkCore.Migrations;

namespace vosplzen.sem1h3.Data.Migrations
{
    public partial class student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "AIT2002");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "AspNetUsers");
        }
    }
}
