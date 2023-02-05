using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesInMapsEntitiesLivros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_LivrosAutores_LivroAutorId",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_LivrosGeneros_LivroGeneroId",
                table: "Livros");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_LivrosAutores_LivroAutorId",
                table: "Livros",
                column: "LivroAutorId",
                principalTable: "LivrosAutores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_LivrosGeneros_LivroGeneroId",
                table: "Livros",
                column: "LivroGeneroId",
                principalTable: "LivrosGeneros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_LivrosAutores_LivroAutorId",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_LivrosGeneros_LivroGeneroId",
                table: "Livros");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_LivrosAutores_LivroAutorId",
                table: "Livros",
                column: "LivroAutorId",
                principalTable: "LivrosAutores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_LivrosGeneros_LivroGeneroId",
                table: "Livros",
                column: "LivroGeneroId",
                principalTable: "LivrosGeneros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
