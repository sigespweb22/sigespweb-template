using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesInAlunoLeituraMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoLeituraLivros_AlunosLeitura_AlunoLeituraId",
                table: "AlunoLeituraLivros");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunoLeituraLivros_Livros_LivroId",
                table: "AlunoLeituraLivros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunoLeituraLivros",
                table: "AlunoLeituraLivros");

            migrationBuilder.RenameTable(
                name: "AlunoLeituraLivros",
                newName: "AlunosLeituraLivros");

            migrationBuilder.RenameIndex(
                name: "IX_AlunoLeituraLivros_LivroId",
                table: "AlunosLeituraLivros",
                newName: "IX_AlunosLeituraLivros_LivroId");

            migrationBuilder.RenameIndex(
                name: "IX_AlunoLeituraLivros_AlunoLeituraId",
                table: "AlunosLeituraLivros",
                newName: "IX_AlunosLeituraLivros_AlunoLeituraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunosLeituraLivros",
                table: "AlunosLeituraLivros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosLeituraLivros_AlunosLeitura_AlunoLeituraId",
                table: "AlunosLeituraLivros",
                column: "AlunoLeituraId",
                principalTable: "AlunosLeitura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosLeituraLivros_Livros_LivroId",
                table: "AlunosLeituraLivros",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunosLeituraLivros_AlunosLeitura_AlunoLeituraId",
                table: "AlunosLeituraLivros");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunosLeituraLivros_Livros_LivroId",
                table: "AlunosLeituraLivros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunosLeituraLivros",
                table: "AlunosLeituraLivros");

            migrationBuilder.RenameTable(
                name: "AlunosLeituraLivros",
                newName: "AlunoLeituraLivros");

            migrationBuilder.RenameIndex(
                name: "IX_AlunosLeituraLivros_LivroId",
                table: "AlunoLeituraLivros",
                newName: "IX_AlunoLeituraLivros_LivroId");

            migrationBuilder.RenameIndex(
                name: "IX_AlunosLeituraLivros_AlunoLeituraId",
                table: "AlunoLeituraLivros",
                newName: "IX_AlunoLeituraLivros_AlunoLeituraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunoLeituraLivros",
                table: "AlunoLeituraLivros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoLeituraLivros_AlunosLeitura_AlunoLeituraId",
                table: "AlunoLeituraLivros",
                column: "AlunoLeituraId",
                principalTable: "AlunosLeitura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoLeituraLivros_Livros_LivroId",
                table: "AlunoLeituraLivros",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
