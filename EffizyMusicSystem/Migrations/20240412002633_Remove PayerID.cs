using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EffizyMusicSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemovePayerID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayerID",
                table: "Enrollments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PayerID",
                table: "Enrollments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
