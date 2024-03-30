using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EffizyMusicSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddingInitialTablestoEfizzyDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desception",
                table: "Courses",
                newName: "CourseDescription");

            migrationBuilder.RenameColumn(
                name: "CourseModel",
                table: "Courses",
                newName: "CourseMode");

            migrationBuilder.AddColumn<string>(
                name: "InstrumentType",
                table: "Instruments",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstrumentType",
                table: "Instruments");

            migrationBuilder.RenameColumn(
                name: "CourseMode",
                table: "Courses",
                newName: "CourseModel");

            migrationBuilder.RenameColumn(
                name: "CourseDescription",
                table: "Courses",
                newName: "Desception");
        }
    }
}
