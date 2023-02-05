using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeDetentosFieldsSaidaTemporaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaidaTemporariaRetornoPrevisto",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "SaidaTemporariaSaidaPrevista",
                table: "Detentos");

            migrationBuilder.AddColumn<DateTime[]>(
                name: "STPrevista",
                table: "Detentos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime[]>(
                name: "STRetornoPrevisto",
                table: "Detentos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "STPrevista",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "STRetornoPrevisto",
                table: "Detentos");

            migrationBuilder.AddColumn<DateTime>(
                name: "SaidaTemporariaRetornoPrevisto",
                table: "Detentos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SaidaTemporariaSaidaPrevista",
                table: "Detentos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
