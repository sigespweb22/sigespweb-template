using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesColaboradoresTask01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_DetentoId",
                table: "Colaboradores");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDemissao",
                table: "Colaboradores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DemissaoObservacao",
                table: "Colaboradores",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DemissaoOcorrencia",
                table: "Colaboradores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_DetentoId",
                table: "Colaboradores",
                column: "DetentoId",
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_DetentoId",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "DataDemissao",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "DemissaoObservacao",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "DemissaoOcorrencia",
                table: "Colaboradores");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_DetentoId",
                table: "Colaboradores",
                column: "DetentoId",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }
    }
}
