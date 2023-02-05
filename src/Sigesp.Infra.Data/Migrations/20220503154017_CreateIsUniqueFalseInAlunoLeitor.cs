using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateIsUniqueFalseInAlunoLeitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlunosLeitores_AlunoId",
                table: "AlunosLeitores");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeitores_AlunoId",
                table: "AlunosLeitores",
                column: "AlunoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlunosLeitores_AlunoId",
                table: "AlunosLeitores");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeitores_AlunoId",
                table: "AlunosLeitores",
                column: "AlunoId",
                unique: true);
        }
    }
}
