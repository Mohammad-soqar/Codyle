using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodyleOffical.Migrations
{
    /// <inheritdoc />
    public partial class addeventedits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnlineEvent",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "SpeakerLinkedIn",
                table: "Events",
                newName: "YouTubeLink");

            migrationBuilder.RenameColumn(
                name: "Speaker",
                table: "Events",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Finished",
                table: "Events",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "EventLiveLink",
                table: "Events",
                newName: "Duration");

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Behance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalWebsite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Speakers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_EventId",
                table: "Speakers",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.RenameColumn(
                name: "YouTubeLink",
                table: "Events",
                newName: "SpeakerLinkedIn");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Events",
                newName: "Speaker");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Events",
                newName: "Finished");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Events",
                newName: "EventLiveLink");

            migrationBuilder.AddColumn<bool>(
                name: "OnlineEvent",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
