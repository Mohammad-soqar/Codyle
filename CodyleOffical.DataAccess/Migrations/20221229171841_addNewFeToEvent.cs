using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodyleOffical.Migrations
{
    /// <inheritdoc />
    public partial class addNewFeToEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price5",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Finished",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slides",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finished",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Slides",
                table: "Events");

            migrationBuilder.AddColumn<double>(
                name: "Price5",
                table: "Events",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
