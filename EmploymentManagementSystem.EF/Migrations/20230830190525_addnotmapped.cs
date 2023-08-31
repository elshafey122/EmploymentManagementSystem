using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementSystem.EF.Migrations
{
    public partial class addnotmapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departements_DepartementId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartementId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05634ede-99ea-46fb-8676-58c504d04583");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe7577d7-e4e4-401b-9859-fb8015c1f7e8");

            migrationBuilder.DropColumn(
                name: "DepartementId",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7845c6db-1979-44bd-bd9b-6c8ab0713c64", "1", "admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2c594d9-7240-4961-88f0-1a71d9f1010c", "2", "user", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7845c6db-1979-44bd-bd9b-6c8ab0713c64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2c594d9-7240-4961-88f0-1a71d9f1010c");

            migrationBuilder.AddColumn<int>(
                name: "DepartementId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05634ede-99ea-46fb-8676-58c504d04583", "2", "user", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fe7577d7-e4e4-401b-9859-fb8015c1f7e8", "1", "admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartementId",
                table: "Employees",
                column: "DepartementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departements_DepartementId",
                table: "Employees",
                column: "DepartementId",
                principalTable: "Departements",
                principalColumn: "Id");
        }
    }
}
