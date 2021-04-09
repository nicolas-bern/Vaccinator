using Microsoft.EntityFrameworkCore.Migrations;

namespace Vaccinator.Migrations
{
    public partial class AjoutCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Injection_Personnes_PersonneId",
                table: "Injection");

            migrationBuilder.DropForeignKey(
                name: "FK_Injection_Vaccin_VaccinId",
                table: "Injection");

            migrationBuilder.AlterColumn<int>(
                name: "VaccinId",
                table: "Injection",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonneId",
                table: "Injection",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Injection_Personnes_PersonneId",
                table: "Injection",
                column: "PersonneId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Injection_Vaccin_VaccinId",
                table: "Injection",
                column: "VaccinId",
                principalTable: "Vaccin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Injection_Personnes_PersonneId",
                table: "Injection");

            migrationBuilder.DropForeignKey(
                name: "FK_Injection_Vaccin_VaccinId",
                table: "Injection");

            migrationBuilder.AlterColumn<int>(
                name: "VaccinId",
                table: "Injection",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PersonneId",
                table: "Injection",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Injection_Personnes_PersonneId",
                table: "Injection",
                column: "PersonneId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Injection_Vaccin_VaccinId",
                table: "Injection",
                column: "VaccinId",
                principalTable: "Vaccin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
