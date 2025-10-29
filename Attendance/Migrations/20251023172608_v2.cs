using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attendance.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
