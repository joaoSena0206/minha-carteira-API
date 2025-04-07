using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_Username",
                table: "Categories");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_Username",
                table: "Categories",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_Username",
                table: "Categories");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_Username",
                table: "Categories",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
