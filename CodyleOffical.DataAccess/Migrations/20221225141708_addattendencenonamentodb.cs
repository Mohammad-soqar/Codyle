using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodyleOffical.Migrations
{
    /// <inheritdoc />
    public partial class addattendencenonamentodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendences_AspNetUsers_ApplicationUserId",
                table: "Attendences");

            migrationBuilder.DropIndex(
                name: "IX_Attendences_ApplicationUserId",
                table: "Attendences");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Attendences");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Attendences",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Attendences_ApplicationUserId",
                table: "Attendences",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendences_AspNetUsers_ApplicationUserId",
                table: "Attendences",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
