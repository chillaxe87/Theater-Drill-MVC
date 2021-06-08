using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Theater_Drill_MVC.Data.Migrations
{
    public partial class AddScheduleClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(type: "int", nullable: true),
                    AuditoriumID = table.Column<int>(type: "int", nullable: true),
                    ScreeningTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Schedule_Auditoriums_AuditoriumID",
                        column: x => x.AuditoriumID,
                        principalTable: "Auditoriums",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedule_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_AuditoriumID",
                table: "Schedule",
                column: "AuditoriumID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_MovieID",
                table: "Schedule",
                column: "MovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");
        }
    }
}
