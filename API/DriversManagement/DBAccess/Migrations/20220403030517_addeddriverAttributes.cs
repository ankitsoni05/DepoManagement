using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DBAccess.Migrations
{
    public partial class addeddriverAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "driverPays",
                columns: table => new
                {
                    payId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    payDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    overTimeAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    driverId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driverPays", x => x.payId);
                    table.ForeignKey(
                        name: "FK_driverPays_drivers_driverId",
                        column: x => x.driverId,
                        principalTable: "drivers",
                        principalColumn: "driverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_driverPays_driverId",
                table: "driverPays",
                column: "driverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "driverPays");
        }
    }
}
