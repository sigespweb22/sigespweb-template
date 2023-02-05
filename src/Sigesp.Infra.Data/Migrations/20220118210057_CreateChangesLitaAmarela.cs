using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesLitaAmarela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RevisaoIpenObservacao",
                table: "ListaAmarela");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataSaidaPrevista",
                table: "ListaAmarela",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataSaidaPrevista",
                table: "ListaAmarela");

            migrationBuilder.AddColumn<string>(
                name: "RevisaoIpenObservacao",
                table: "ListaAmarela",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
