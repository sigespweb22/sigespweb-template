using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateMoreChangesColaboradoresTask01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDemissao",
                table: "Colaboradores");

            migrationBuilder.AddColumn<DateTime>(
                name: "DemissaoData",
                table: "Colaboradores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DemissaoData",
                table: "Colaboradores");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDemissao",
                table: "Colaboradores",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
