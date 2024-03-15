using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EffizyMusicSystem.Migrations
{
    /// <inheritdoc />
    public partial class MarchTwelve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "UserTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_UserID",
                table: "UserTypes",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypes_Users_UserID",
                table: "UserTypes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTypes_Users_UserID",
                table: "UserTypes");

            migrationBuilder.DropIndex(
                name: "IX_UserTypes_UserID",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "UserTypes");
        }
    }
}
