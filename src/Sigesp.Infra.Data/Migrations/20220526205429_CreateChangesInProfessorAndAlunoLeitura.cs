using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesInProfessorAndAlunoLeitura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunosLeituras_Professores_ProfessorId",
                table: "AlunosLeituras");

            migrationBuilder.DropIndex(
                name: "IX_AlunosLeituras_ProfessorId",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "AlunosLeituras");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfessorId",
                table: "AlunosLeituras",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeituras_ProfessorId",
                table: "AlunosLeituras",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosLeituras_Professores_ProfessorId",
                table: "AlunosLeituras",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
