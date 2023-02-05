using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateMigrationsChangesInAlunoEjaAndAlunoEjaDisciplinas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoEjaDisciplinas_Disciplinas_DisciplinaId",
                table: "AlunoEjaDisciplinas");

            migrationBuilder.DropIndex(
                name: "IX_AlunoEjaDisciplinas_AlunoEjaId",
                table: "AlunoEjaDisciplinas");

            migrationBuilder.DropIndex(
                name: "IX_AlunoEjaDisciplinas_DisciplinaId",
                table: "AlunoEjaDisciplinas");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "AlunoEjaDisciplinas");

            migrationBuilder.AddColumn<int>(
                name: "Conceito",
                table: "AlunoEjaDisciplinas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Nome",
                table: "AlunoEjaDisciplinas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AlunoEjaDisciplinas_AlunoEjaId",
                table: "AlunoEjaDisciplinas",
                column: "AlunoEjaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlunoEjaDisciplinas_AlunoEjaId",
                table: "AlunoEjaDisciplinas");

            migrationBuilder.DropColumn(
                name: "Conceito",
                table: "AlunoEjaDisciplinas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AlunoEjaDisciplinas");

            migrationBuilder.AddColumn<Guid>(
                name: "DisciplinaId",
                table: "AlunoEjaDisciplinas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AlunoEjaDisciplinas_AlunoEjaId",
                table: "AlunoEjaDisciplinas",
                column: "AlunoEjaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlunoEjaDisciplinas_DisciplinaId",
                table: "AlunoEjaDisciplinas",
                column: "DisciplinaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoEjaDisciplinas_Disciplinas_DisciplinaId",
                table: "AlunoEjaDisciplinas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
