using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EffizyMusicSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixedIDinLessonModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Modules_ModuleID1",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Courses_CourseID1",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_CourseID1",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_ModuleID1",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CourseID1",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ModuleID1",
                table: "Lessons");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Modules",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ModuleID",
                table: "Lessons",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourseID",
                table: "Modules",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ModuleID",
                table: "Lessons",
                column: "ModuleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Modules_ModuleID",
                table: "Lessons",
                column: "ModuleID",
                principalTable: "Modules",
                principalColumn: "ModuleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Courses_CourseID",
                table: "Modules",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Modules_ModuleID",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Courses_CourseID",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_CourseID",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_ModuleID",
                table: "Lessons");

            migrationBuilder.AlterColumn<string>(
                name: "CourseID",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CourseID1",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ModuleID",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ModuleID1",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourseID1",
                table: "Modules",
                column: "CourseID1");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ModuleID1",
                table: "Lessons",
                column: "ModuleID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Modules_ModuleID1",
                table: "Lessons",
                column: "ModuleID1",
                principalTable: "Modules",
                principalColumn: "ModuleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Courses_CourseID1",
                table: "Modules",
                column: "CourseID1",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
