using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesAlunosLeituras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AlunoLeituraCronogramaId",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeituras_AlunoLeituraCronogramaId",
                table: "AlunosLeituras",
                column: "AlunoLeituraCronogramaId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosLeituras_AlunosLeiturasCronogramas_AlunoLeituraCronog~",
                table: "AlunosLeituras",
                column: "AlunoLeituraCronogramaId",
                principalTable: "AlunosLeiturasCronogramas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunosLeituras_AlunosLeiturasCronogramas_AlunoLeituraCronog~",
                table: "AlunosLeituras");

            migrationBuilder.DropIndex(
                name: "IX_AlunosLeituras_AlunoLeituraCronogramaId",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "AlunoLeituraCronogramaId",
                table: "AlunosLeituras");
        }
    }
}
