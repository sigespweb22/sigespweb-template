using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesCriticousInAlunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunosEja_Alunos_AlunoId",
                table: "AlunosEja");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunosEncceja_Alunos_AlunoId",
                table: "AlunosEncceja");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunosEnem_Alunos_AlunoId",
                table: "AlunosEnem");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunosLeitores_Alunos_AlunoId",
                table: "AlunosLeitores");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunosRedacaoDPU_Alunos_AlunoId",
                table: "AlunosRedacaoDPU");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosEja_Alunos_AlunoId",
                table: "AlunosEja",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosEncceja_Alunos_AlunoId",
                table: "AlunosEncceja",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosEnem_Alunos_AlunoId",
                table: "AlunosEnem",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosLeitores_Alunos_AlunoId",
                table: "AlunosLeitores",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosRedacaoDPU_Alunos_AlunoId",
                table: "AlunosRedacaoDPU",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunosEja_Alunos_AlunoId",
                table: "AlunosEja");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunosEncceja_Alunos_AlunoId",
                table: "AlunosEncceja");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunosEnem_Alunos_AlunoId",
                table: "AlunosEnem");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunosLeitores_Alunos_AlunoId",
                table: "AlunosLeitores");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunosRedacaoDPU_Alunos_AlunoId",
                table: "AlunosRedacaoDPU");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosEja_Alunos_AlunoId",
                table: "AlunosEja",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosEncceja_Alunos_AlunoId",
                table: "AlunosEncceja",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosEnem_Alunos_AlunoId",
                table: "AlunosEnem",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosLeitores_Alunos_AlunoId",
                table: "AlunosLeitores",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosRedacaoDPU_Alunos_AlunoId",
                table: "AlunosRedacaoDPU",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
