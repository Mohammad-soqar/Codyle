using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodyleOffical.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMPlatforms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaunchDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guidelines = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoritewebUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoritewebUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoritewebUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maintenance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");

         
        }
    }
}
