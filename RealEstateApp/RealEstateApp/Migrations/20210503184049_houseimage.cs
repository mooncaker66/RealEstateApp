using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateApp.Migrations
{
    public partial class houseimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseImage_Houses_HouseID",
                table: "HouseImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseImage",
                table: "HouseImage");

            migrationBuilder.RenameTable(
                name: "HouseImage",
                newName: "HouseImages");

            migrationBuilder.RenameIndex(
                name: "IX_HouseImage_HouseID",
                table: "HouseImages",
                newName: "IX_HouseImages_HouseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseImages",
                table: "HouseImages",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseImages_Houses_HouseID",
                table: "HouseImages",
                column: "HouseID",
                principalTable: "Houses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseImages_Houses_HouseID",
                table: "HouseImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseImages",
                table: "HouseImages");

            migrationBuilder.RenameTable(
                name: "HouseImages",
                newName: "HouseImage");

            migrationBuilder.RenameIndex(
                name: "IX_HouseImages_HouseID",
                table: "HouseImage",
                newName: "IX_HouseImage_HouseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseImage",
                table: "HouseImage",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseImage_Houses_HouseID",
                table: "HouseImage",
                column: "HouseID",
                principalTable: "Houses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
