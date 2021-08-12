using Microsoft.EntityFrameworkCore.Migrations;

namespace NobatOnline.Migrations
{
    public partial class ChengeAppuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "AppUser",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AppUser",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "CodeMeli",
                table: "AppUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AppUser",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeMeli",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AppUser");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AppUser",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "AppUser",
                newName: "IsActive");
        }
    }
}
