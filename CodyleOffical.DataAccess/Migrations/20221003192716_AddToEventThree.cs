using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodyleOffical.Migrations
{
    /// <inheritdoc />
    public partial class AddToEventThree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationCompanyId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ApplicationCompanyId",
                table: "Events",
                column: "ApplicationCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_ApplicationCompanies_ApplicationCompanyId",
                table: "Events",
                column: "ApplicationCompanyId",
                principalTable: "ApplicationCompanies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_ApplicationCompanies_ApplicationCompanyId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ApplicationCompanyId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ApplicationCompanyId",
                table: "Events");
        }
    }
}
