using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateApp.Migrations
{
    public partial class gg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Employees_EmployeeId",
                table: "Listings");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Listings",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_EmployeeId",
                table: "Listings",
                newName: "IX_Listings_UserId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName", "Password" },
                values: new object[] { 1, "example@abc.com", "Jake", "Bull", "dslfjsldfj" });

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ID",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ID",
                keyValue: 2,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ID",
                keyValue: 3,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ID",
                keyValue: 4,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ID",
                keyValue: 5,
                column: "UserId",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Users_UserId",
                table: "Listings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Users_UserId",
                table: "Listings");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Listings",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_UserId",
                table: "Listings",
                newName: "IX_Listings_EmployeeId");

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ID",
                keyValue: 1,
                column: "EmployeeId",
                value: 100000);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ID",
                keyValue: 2,
                column: "EmployeeId",
                value: 100000);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ID",
                keyValue: 3,
                column: "EmployeeId",
                value: 100000);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ID",
                keyValue: 4,
                column: "EmployeeId",
                value: 100000);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ID",
                keyValue: 5,
                column: "EmployeeId",
                value: 100000);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Employees_EmployeeId",
                table: "Listings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
