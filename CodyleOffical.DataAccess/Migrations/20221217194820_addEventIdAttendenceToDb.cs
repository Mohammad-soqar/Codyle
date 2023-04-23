using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodyleOffical.Migrations
{
    /// <inheritdoc />
    public partial class addEventIdAttendenceToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Attendences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attendences_EventId",
                table: "Attendences",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendences_Events_EventId",
                table: "Attendences",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendences_Events_EventId",
                table: "Attendences");

            migrationBuilder.DropIndex(
                name: "IX_Attendences_EventId",
                table: "Attendences");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Attendences");
        }
    }
}
