using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodyleOffical.Migrations
{
    /// <inheritdoc />
    public partial class AddToEventTWO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SponsorImageUrl1",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "SponsorImageUrl2",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "SponsorImageUrl3",
                table: "Events");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SponsorImageUrl1",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SponsorImageUrl2",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SponsorImageUrl3",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
