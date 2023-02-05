using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesInAlunoLeitura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlunosLeitura_AlunoId",
                table: "AlunosLeitura");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LeituraDataOcorrenciaDesistencia",
                table: "AlunosLeitura",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeitura_AlunoId",
                table: "AlunosLeitura",
                column: "AlunoId",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlunosLeitura_AlunoId",
                table: "AlunosLeitura");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LeituraDataOcorrenciaDesistencia",
                table: "AlunosLeitura",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeitura_AlunoId",
                table: "AlunosLeitura",
                column: "AlunoId",
                filter: "\"IsDeleted\"='0'");
        }
    }
}
