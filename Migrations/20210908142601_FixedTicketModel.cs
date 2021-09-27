using Microsoft.EntityFrameworkCore.Migrations;

namespace NobatOnline.Migrations
{
    public partial class FixedTicketModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Tickets",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "DayName",
                table: "Tickets",
                newName: "SplitTime");

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Tickets",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "SplitTime",
                table: "Tickets",
                newName: "DayName");
        }
    }
}
