using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attendance.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmpAttendances_Attendanceid",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Attendanceid",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Attendanceid",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeAttendanceid",
                table: "EmpAttendances",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "EmpAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmpAttendances_EmployeeAttendanceid",
                table: "EmpAttendances",
                column: "EmployeeAttendanceid");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAttendances_EmployeeId",
                table: "EmpAttendances",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpAttendances_EmpAttendances_EmployeeAttendanceid",
                table: "EmpAttendances",
                column: "EmployeeAttendanceid",
                principalTable: "EmpAttendances",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpAttendances_Employees_EmployeeId",
                table: "EmpAttendances",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpAttendances_EmpAttendances_EmployeeAttendanceid",
                table: "EmpAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpAttendances_Employees_EmployeeId",
                table: "EmpAttendances");

            migrationBuilder.DropIndex(
                name: "IX_EmpAttendances_EmployeeAttendanceid",
                table: "EmpAttendances");

            migrationBuilder.DropIndex(
                name: "IX_EmpAttendances_EmployeeId",
                table: "EmpAttendances");

            migrationBuilder.DropColumn(
                name: "EmployeeAttendanceid",
                table: "EmpAttendances");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmpAttendances");

            migrationBuilder.AddColumn<int>(
                name: "Attendanceid",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Attendanceid",
                table: "Employees",
                column: "Attendanceid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmpAttendances_Attendanceid",
                table: "Employees",
                column: "Attendanceid",
                principalTable: "EmpAttendances",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
