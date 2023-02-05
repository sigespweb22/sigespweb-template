using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeInDetentosFieldsSaidaTemporaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RetornoSaidaTemporaria",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "SaidaTemporaria",
                table: "Detentos");

            migrationBuilder.AddColumn<DateTime>(
                name: "SaidaTemporariaRetornoPrevisto",
                table: "Detentos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SaidaTemporariaSaidaPrevista",
                table: "Detentos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaidaTemporariaRetornoPrevisto",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "SaidaTemporariaSaidaPrevista",
                table: "Detentos");

            migrationBuilder.AddColumn<DateTime>(
                name: "RetornoSaidaTemporaria",
                table: "Detentos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SaidaTemporaria",
                table: "Detentos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
