using Microsoft.EntityFrameworkCore.Migrations;

namespace Theater_Drill_MVC.Data.Migrations
{
    public partial class AddSeatsToAuditorium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Columns",
                table: "Auditoriums",
                newName: "SeatNumberInRow");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeatNumberInRow",
                table: "Auditoriums",
                newName: "Columns");
        }
    }
}
