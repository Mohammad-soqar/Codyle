using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodyleOffical.Migrations
{
    /// <inheritdoc />
    public partial class addspeaker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_ApplicationCompanies_ApplicationCompanyId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropIndex(
                name: "IX_Events_ApplicationCompanyId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Facebook",
                table: "Speakers",
                newName: "GitHub");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Events",
                newName: "Thumbnail");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Events",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Events",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLikes",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ScheduleUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "ApplicationCompanies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserEvent",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    FollowersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserEvent", x => new { x.EventsId, x.FollowersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserEvent_AspNetUsers_FollowersId",
                        column: x => x.FollowersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserEvent_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationCompanies_EventId",
                table: "ApplicationCompanies",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserEvent_FollowersId",
                table: "ApplicationUserEvent",
                column: "FollowersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationCompanies_Events_EventId",
                table: "ApplicationCompanies",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationCompanies_Events_EventId",
                table: "ApplicationCompanies");

            migrationBuilder.DropTable(
                name: "ApplicationUserEvent");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationCompanies_EventId",
                table: "ApplicationCompanies");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "NumberOfLikes",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ScheduleUrl",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "ApplicationCompanies");

            migrationBuilder.RenameColumn(
                name: "GitHub",
                table: "Speakers",
                newName: "Facebook");

            migrationBuilder.RenameColumn(
                name: "Thumbnail",
                table: "Events",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Events",
                newName: "Date");

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
                });

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
    }
}
