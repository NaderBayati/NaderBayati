using Microsoft.EntityFrameworkCore.Migrations;

namespace NobatOnline.Migrations
{
    public partial class beautynameadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BeautyName",
                table: "Beauties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeautyName",
                table: "Beauties");
        }
    }
}
