using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesInForeignKeyInAlunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_LivrosGeneros_LivroGeneroId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_LivroGeneroId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "LivroGeneroId",
                table: "Alunos");

            migrationBuilder.AddColumn<Guid>(
                name: "AlunoGeneroId",
                table: "Alunos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_AlunoGeneroId",
                table: "Alunos",
                column: "AlunoGeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_LivrosGeneros_AlunoGeneroId",
                table: "Alunos",
                column: "AlunoGeneroId",
                principalTable: "LivrosGeneros",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_LivrosGeneros_AlunoGeneroId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_AlunoGeneroId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "AlunoGeneroId",
                table: "Alunos");

            migrationBuilder.AddColumn<Guid>(
                name: "LivroGeneroId",
                table: "Alunos",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_LivroGeneroId",
                table: "Alunos",
                column: "LivroGeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_LivrosGeneros_LivroGeneroId",
                table: "Alunos",
                column: "LivroGeneroId",
                principalTable: "LivrosGeneros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
