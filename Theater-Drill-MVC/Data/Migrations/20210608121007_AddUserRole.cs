using Microsoft.EntityFrameworkCore.Migrations;

namespace Theater_Drill_MVC.Data.Migrations
{
    public partial class AddUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Auditoriums_AuditoriumID",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Movies_MovieID",
                table: "Schedule");

            migrationBuilder.RenameColumn(
                name: "AuditoriumID",
                table: "Schedule",
                newName: "AuditoriumId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_AuditoriumID",
                table: "Schedule",
                newName: "IX_Schedule_AuditoriumId");

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuditoriumId",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Auditoriums_AuditoriumId",
                table: "Schedule",
                column: "AuditoriumId",
                principalTable: "Auditoriums",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Movies_MovieID",
                table: "Schedule",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Auditoriums_AuditoriumId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Movies_MovieID",
                table: "Schedule");

            migrationBuilder.RenameColumn(
                name: "AuditoriumId",
                table: "Schedule",
                newName: "AuditoriumID");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_AuditoriumId",
                table: "Schedule",
                newName: "IX_Schedule_AuditoriumID");

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "Schedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AuditoriumID",
                table: "Schedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Auditoriums_AuditoriumID",
                table: "Schedule",
                column: "AuditoriumID",
                principalTable: "Auditoriums",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Movies_MovieID",
                table: "Schedule",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
