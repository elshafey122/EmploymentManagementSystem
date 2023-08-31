using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementSystem.EF.Migrations
{
    public partial class changenametasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Employees_AssignTo_AssignFrom",
                table: "EmployeeTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTasks",
                table: "EmployeeTasks");

            migrationBuilder.RenameTable(
                name: "EmployeeTasks",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTasks_AssignTo_AssignFrom",
                table: "Tasks",
                newName: "IX_Tasks_AssignTo_AssignFrom");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_AssignTo_AssignFrom",
                table: "Tasks",
                columns: new[] { "AssignTo", "AssignFrom" },
                principalTable: "Employees",
                principalColumns: new[] { "Id", "ManagerId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_AssignTo_AssignFrom",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "EmployeeTasks");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AssignTo_AssignFrom",
                table: "EmployeeTasks",
                newName: "IX_EmployeeTasks_AssignTo_AssignFrom");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTasks",
                table: "EmployeeTasks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Employees_AssignTo_AssignFrom",
                table: "EmployeeTasks",
                columns: new[] { "AssignTo", "AssignFrom" },
                principalTable: "Employees",
                principalColumns: new[] { "Id", "ManagerId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
