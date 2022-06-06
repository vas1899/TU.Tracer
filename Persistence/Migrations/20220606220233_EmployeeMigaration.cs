using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class EmployeeMigaration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkdayEmployees",
                columns: table => new
                {
                    WorkdayId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkdayEmployees", x => new { x.EmployeeId, x.WorkdayId });
                    table.ForeignKey(
                        name: "FK_WorkdayEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkdayEmployees_Workdays_WorkdayId",
                        column: x => x.WorkdayId,
                        principalTable: "Workdays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkdayEmployees_WorkdayId",
                table: "WorkdayEmployees",
                column: "WorkdayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkdayEmployees");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
