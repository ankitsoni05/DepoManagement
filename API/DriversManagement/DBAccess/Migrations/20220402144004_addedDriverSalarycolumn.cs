using Microsoft.EntityFrameworkCore.Migrations;

namespace DBAccess.Migrations
{
    public partial class addedDriverSalarycolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "driverSalary",
                table: "drivers",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "driverSalary",
                table: "drivers");
        }
    }
}
