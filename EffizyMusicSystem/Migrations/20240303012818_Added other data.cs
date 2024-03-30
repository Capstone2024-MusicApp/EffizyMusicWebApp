using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EffizyMusicSystem.Migrations
{
    /// <inheritdoc />
    public partial class Addedotherdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Instructor_InstructorID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Instrument_InstrumentID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Module_ModuleID1",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Module_Course_CourseID1",
                table: "Module");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Module",
                table: "Module");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instrument",
                table: "Instrument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Module",
                newName: "Modules");

            migrationBuilder.RenameTable(
                name: "Instrument",
                newName: "Instruments");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "Instructors");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Module_CourseID1",
                table: "Modules",
                newName: "IX_Modules_CourseID1");

            migrationBuilder.RenameIndex(
                name: "IX_Course_InstrumentID",
                table: "Courses",
                newName: "IX_Courses_InstrumentID");

            migrationBuilder.RenameIndex(
                name: "IX_Course_InstructorID",
                table: "Courses",
                newName: "IX_Courses_InstructorID");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorID",
                table: "Instructors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "HighestMusicQualification",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReferenceEmail",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReferencePhone",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearsOfExperience",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modules",
                table: "Modules",
                column: "ModuleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instruments",
                table: "Instruments",
                column: "InstrumentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "InstructorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorID",
                table: "Courses",
                column: "InstructorID",
                principalTable: "Instructors",
                principalColumn: "InstructorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instruments_InstrumentID",
                table: "Courses",
                column: "InstrumentID",
                principalTable: "Instruments",
                principalColumn: "InstrumentID",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instruments_InstrumentID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Modules_ModuleID1",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Courses_CourseID1",
                table: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modules",
                table: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instruments",
                table: "Instruments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "HighestMusicQualification",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "ReferenceEmail",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "ReferencePhone",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "YearsOfExperience",
                table: "Instructors");

            migrationBuilder.RenameTable(
                name: "Modules",
                newName: "Module");

            migrationBuilder.RenameTable(
                name: "Instruments",
                newName: "Instrument");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "Instructor");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_CourseID1",
                table: "Module",
                newName: "IX_Module_CourseID1");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_InstrumentID",
                table: "Course",
                newName: "IX_Course_InstrumentID");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_InstructorID",
                table: "Course",
                newName: "IX_Course_InstructorID");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorID",
                table: "Instructor",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 1)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Module",
                table: "Module",
                column: "ModuleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instrument",
                table: "Instrument",
                column: "InstrumentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor",
                column: "InstructorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Instructor_InstructorID",
                table: "Course",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "InstructorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Instrument_InstrumentID",
                table: "Course",
                column: "InstrumentID",
                principalTable: "Instrument",
                principalColumn: "InstrumentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Module_ModuleID1",
                table: "Lessons",
                column: "ModuleID1",
                principalTable: "Module",
                principalColumn: "ModuleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Module_Course_CourseID1",
                table: "Module",
                column: "CourseID1",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
