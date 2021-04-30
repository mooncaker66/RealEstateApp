using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyType = table.Column<int>(type: "int", nullable: false),
                    Community = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rooms = table.Column<int>(type: "int", nullable: false),
                    Beds = table.Column<int>(type: "int", nullable: false),
                    Baths = table.Column<int>(type: "int", nullable: false),
                    SquareFeet = table.Column<int>(type: "int", nullable: false),
                    HasAirCondition = table.Column<bool>(type: "bit", nullable: false),
                    HasHeating = table.Column<bool>(type: "bit", nullable: false),
                    HasLaudry = table.Column<bool>(type: "bit", nullable: false),
                    HasGym = table.Column<bool>(type: "bit", nullable: false),
                    HasParking = table.Column<bool>(type: "bit", nullable: false),
                    HasBasement = table.Column<bool>(type: "bit", nullable: false),
                    HasPool = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HouseImage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseID = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseImage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HouseImage_Houses_HouseID",
                        column: x => x.HouseID,
                        principalTable: "Houses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingType = table.Column<int>(type: "int", nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Listings_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listings_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmailAddress", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 100000, "zhixun@usf.edu", "Zhixuu", "Zhao", "123456789" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "ID", "Ages", "Baths", "Beds", "City", "Community", "HasAirCondition", "HasBasement", "HasGym", "HasHeating", "HasLaudry", "HasParking", "HasPool", "PropertyType", "Rooms", "SquareFeet", "State", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, "0 - 10 Years", 2, 3, "Ocala", "On Top of The World", true, false, true, true, true, true, true, 1, 0, 3000, "FL", "8650 SW 95th Unit F", "34481" },
                    { 2, "0 - 10 Years", 2, 3, "New Port Richey", "Colonial Hills", true, false, false, true, true, true, false, 2, 0, 1535, "FL", "5855 Mockingbird Dr", "34652" },
                    { 3, "0 - 10 Years", 2, 4, "Jacksonville", "Spring Road", true, false, false, false, true, true, false, 1, 0, 2879, "FL", "13933 Sound Overlook Dr N", "32224" },
                    { 4, "0 - 10 Years", 2, 4, "Avon Park", "Spring Road", true, false, false, false, false, false, false, 3, 0, 984, "FL", "759 NE Turtles Turn", "33825" },
                    { 5, "0 - 10 Years", 9, 7, "Atlanta", "Spring Road", true, true, true, true, true, true, true, 1, 0, 11000, "GA ", "3511 Roxboro Rd NE", "30326" }
                });

            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "ID", "Description", "EmployeeId", "HouseId", "ListingType", "Price" },
                values: new object[,]
                {
                    { 1, null, 100000, 1, 1, 100000m },
                    { 2, null, 100000, 2, 2, 17000m },
                    { 3, null, 100000, 3, 1, 410000m },
                    { 4, null, 100000, 4, 1, 8900m },
                    { 5, null, 100000, 5, 1, 3300000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseImage_HouseID",
                table: "HouseImage",
                column: "HouseID");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_EmployeeId",
                table: "Listings",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_HouseId",
                table: "Listings",
                column: "HouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseImage");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}
