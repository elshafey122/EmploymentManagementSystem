using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementSystem.EF.Migrations
{
    public partial class addmanagerroleandassignnotmapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departements_DeptId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DeptId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d53e1a0-ea5b-4ca2-9123-db71a6ead1e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce402695-c46b-4969-8ef9-bbc9f93b6237");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f1ed9ec-7292-4bec-9eb4-4cb4d39e427f", "1", "admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be632407-3c8c-44dc-b231-d01d883c4483", "2", "user", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5fd7c6f-ac74-47b5-9951-0c38ee2e8436", "3", "manager", "Manager" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f1ed9ec-7292-4bec-9eb4-4cb4d39e427f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be632407-3c8c-44dc-b231-d01d883c4483");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5fd7c6f-ac74-47b5-9951-0c38ee2e8436");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d53e1a0-ea5b-4ca2-9123-db71a6ead1e9", "1", "admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce402695-c46b-4969-8ef9-bbc9f93b6237", "2", "user", "User" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeptId",
                table: "Employees",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departements_DeptId",
                table: "Employees",
                column: "DeptId",
                principalTable: "Departements",
                principalColumn: "Id");
        }
    }
}
