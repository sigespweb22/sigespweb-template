using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesInAlunoLeituraMap2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlunosLeituras_AlunoLeitorId",
                table: "AlunosLeituras");

            migrationBuilder.DropIndex(
                name: "IX_AlunosLeituras_LivroId",
                table: "AlunosLeituras");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeituras_AlunoLeitorId",
                table: "AlunosLeituras",
                column: "AlunoLeitorId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeituras_LivroId",
                table: "AlunosLeituras",
                column: "LivroId",
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlunosLeituras_AlunoLeitorId",
                table: "AlunosLeituras");

            migrationBuilder.DropIndex(
                name: "IX_AlunosLeituras_LivroId",
                table: "AlunosLeituras");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeituras_AlunoLeitorId",
                table: "AlunosLeituras",
                column: "AlunoLeitorId",
                unique: true,
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeituras_LivroId",
                table: "AlunosLeituras",
                column: "LivroId",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }
    }
}
