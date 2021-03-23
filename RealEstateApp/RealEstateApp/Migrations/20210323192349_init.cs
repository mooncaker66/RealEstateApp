using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearBuilt = table.Column<int>(type: "int", nullable: false),
                    Beds = table.Column<int>(type: "int", nullable: false),
                    Baths = table.Column<int>(type: "int", nullable: false),
                    SquareFeet = table.Column<int>(type: "int", nullable: false),
                    HasParking = table.Column<bool>(type: "bit", nullable: false),
                    HasBasement = table.Column<bool>(type: "bit", nullable: false),
                    HasPool = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "ID", "Baths", "Beds", "City", "HasBasement", "HasParking", "HasPool", "PropertyType", "SquareFeet", "State", "Street", "YearBuilt", "ZipCode" },
                values: new object[] { 1, 2, 3, "tampa", false, true, true, "condo", 3000, "FL", "1234 low St", 1996, "33510" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}
