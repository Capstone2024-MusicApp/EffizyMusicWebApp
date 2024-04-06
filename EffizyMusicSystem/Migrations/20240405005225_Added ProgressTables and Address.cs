using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EffizyMusicSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedProgressTablesandAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillLevel",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnrollmentStatus",
                table: "Enrollments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PayerID",
                table: "Enrollments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LessonsProgress",
                columns: table => new
                {
                    LessonProgressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollmentID = table.Column<int>(type: "int", nullable: false),
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    ProgressStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonsProgress", x => x.LessonProgressID);
                });

            migrationBuilder.CreateTable(
                name: "QuizesProgress",
                columns: table => new
                {
                    QuizProgressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollmentID = table.Column<int>(type: "int", nullable: false),
                    QuizID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizesProgress", x => x.QuizProgressID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_PaymentID",
                table: "Enrollments",
                column: "PaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Payments_PaymentID",
                table: "Enrollments",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Payments_PaymentID",
                table: "Enrollments");

            migrationBuilder.DropTable(
                name: "LessonsProgress");

            migrationBuilder.DropTable(
                name: "QuizesProgress");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_PaymentID",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "EnrollmentStatus",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "PayerID",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Enrollments");

            migrationBuilder.AddColumn<string>(
                name: "SkillLevel",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
