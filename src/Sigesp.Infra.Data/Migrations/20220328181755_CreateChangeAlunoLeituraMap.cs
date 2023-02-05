using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeAlunoLeituraMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlunosLeitura_AlunoId",
                table: "AlunosLeitura");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeitura_AlunoId",
                table: "AlunosLeitura",
                column: "AlunoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlunosLeitura_AlunoId",
                table: "AlunosLeitura");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeitura_AlunoId",
                table: "AlunosLeitura",
                column: "AlunoId",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }
    }
}
