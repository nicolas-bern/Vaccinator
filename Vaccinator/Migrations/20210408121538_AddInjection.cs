using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vaccinator.Migrations
{
    public partial class AddInjection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Injection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonneId = table.Column<int>(type: "INTEGER", nullable: true),
                    VaccinId = table.Column<int>(type: "INTEGER", nullable: true),
                    Lot = table.Column<int>(type: "INTEGER", nullable: false),
                    DateAdministration = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Injection_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Injection_Vaccin_VaccinId",
                        column: x => x.VaccinId,
                        principalTable: "Vaccin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Injection_PersonneId",
                table: "Injection",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Injection_VaccinId",
                table: "Injection",
                column: "VaccinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Injection");
        }
    }
}
