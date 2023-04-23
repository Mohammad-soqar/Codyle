using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodyleOffical.Migrations
{
    /// <inheritdoc />
    public partial class addEventNametoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "Attendences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventName",
                table: "Attendences");
        }
    }
}
