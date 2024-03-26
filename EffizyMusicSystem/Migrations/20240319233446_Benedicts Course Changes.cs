using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EffizyMusicSystem.Migrations
{
    /// <inheritdoc />
    public partial class BenedictsCourseChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseMode",
                table: "Courses",
                newName: "SkillLevel");

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "Courses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EstimatedTime",
                table: "Courses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "EstimatedTime",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "SkillLevel",
                table: "Courses",
                newName: "CourseMode");
        }
    }
}
