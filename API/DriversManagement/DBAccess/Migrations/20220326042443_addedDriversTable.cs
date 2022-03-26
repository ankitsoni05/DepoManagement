using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DBAccess.Migrations
{
    public partial class addedDriversTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depos_Divisions_DivisionId",
                table: "Depos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Divisions",
                table: "Divisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Depos",
                table: "Depos");

            migrationBuilder.RenameTable(
                name: "Divisions",
                newName: "divisions");

            migrationBuilder.RenameTable(
                name: "Depos",
                newName: "depos");

            migrationBuilder.RenameIndex(
                name: "IX_Depos_DivisionId",
                table: "depos",
                newName: "IX_depos_DivisionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_divisions",
                table: "divisions",
                column: "DivisionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_depos",
                table: "depos",
                column: "DepoId");

            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    driverId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstName = table.Column<string>(type: "text", nullable: true),
                    lastName = table.Column<string>(type: "text", nullable: true),
                    dateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dateOfJoining = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    contactNumber = table.Column<string>(type: "text", nullable: true),
                    emailId = table.Column<string>(type: "text", nullable: true),
                    aadharNumber = table.Column<string>(type: "text", nullable: true),
                    panNumber = table.Column<string>(type: "text", nullable: true),
                    drivingLicenceNumber = table.Column<string>(type: "text", nullable: true),
                    DepoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drivers", x => x.driverId);
                    table.ForeignKey(
                        name: "FK_drivers_depos_DepoId",
                        column: x => x.DepoId,
                        principalTable: "depos",
                        principalColumn: "DepoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_drivers_DepoId",
                table: "drivers",
                column: "DepoId");

            migrationBuilder.AddForeignKey(
                name: "FK_depos_divisions_DivisionId",
                table: "depos",
                column: "DivisionId",
                principalTable: "divisions",
                principalColumn: "DivisionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_depos_divisions_DivisionId",
                table: "depos");

            migrationBuilder.DropTable(
                name: "drivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_divisions",
                table: "divisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_depos",
                table: "depos");

            migrationBuilder.RenameTable(
                name: "divisions",
                newName: "Divisions");

            migrationBuilder.RenameTable(
                name: "depos",
                newName: "Depos");

            migrationBuilder.RenameIndex(
                name: "IX_depos_DivisionId",
                table: "Depos",
                newName: "IX_Depos_DivisionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Divisions",
                table: "Divisions",
                column: "DivisionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Depos",
                table: "Depos",
                column: "DepoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depos_Divisions_DivisionId",
                table: "Depos",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "DivisionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
