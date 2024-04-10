using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EffizyMusicSystem.Migrations
{
    /// <inheritdoc />
    public partial class OrderModuleLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Courses_CourseID",
                table: "Subscriptions");

            migrationBuilder.AddColumn<string>(
                name: "PayerID",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ModuleOrder",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LessonOrder",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProgressStatus",
                table: "Enrollments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses",
                table: "Enrollments",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students",
                table: "Enrollments",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Courses",
                table: "Subscriptions",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Courses",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "PayerID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ModuleOrder",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "LessonOrder",
                table: "Lessons");

            migrationBuilder.AlterColumn<string>(
                name: "ProgressStatus",
                table: "Enrollments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                table: "Enrollments",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentID",
                table: "Enrollments",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Courses_CourseID",
                table: "Subscriptions",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
