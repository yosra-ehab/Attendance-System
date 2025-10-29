using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attendance.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpAttendances_EmpAttendances_EmployeeAttendanceid",
                table: "EmpAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpAttendances_Employees_EmployeeId",
                table: "EmpAttendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpAttendances",
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

            migrationBuilder.RenameTable(
                name: "EmpAttendances",
                newName: "EmployeeAttendances");

            migrationBuilder.AlterColumn<DateTime>(
                name: "leavetime",
                table: "EmployeeAttendances",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAttendances",
                table: "EmployeeAttendances",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendances_EmployeeId",
                table: "EmployeeAttendances",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAttendances_Employees_EmployeeId",
                table: "EmployeeAttendances",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAttendances_Employees_EmployeeId",
                table: "EmployeeAttendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAttendances",
                table: "EmployeeAttendances");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAttendances_EmployeeId",
                table: "EmployeeAttendances");

            migrationBuilder.RenameTable(
                name: "EmployeeAttendances",
                newName: "EmpAttendances");

            migrationBuilder.AlterColumn<DateTime>(
                name: "leavetime",
                table: "EmpAttendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeAttendanceid",
                table: "EmpAttendances",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpAttendances",
                table: "EmpAttendances",
                column: "id");

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
    }
}
