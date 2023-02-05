using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateNewFieldsInAlunoLeitura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoConceito",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AvaliacaoConceitoJustificativa",
                table: "AlunosLeituras",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoCriterio1",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoCriterio2",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoCriterio3",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoCriterio4",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoCriterio5",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoCriterio6",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoCriterio7",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AvaliacaoObservacao",
                table: "AlunosLeituras",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdSequencial",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int[]>(
                name: "AtividadesEducacionais",
                table: "Alunos",
                nullable: true,
                oldClrType: typeof(int[]),
                oldType: "integer[]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvaliacaoConceito",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "AvaliacaoConceitoJustificativa",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "AvaliacaoCriterio1",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "AvaliacaoCriterio2",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "AvaliacaoCriterio3",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "AvaliacaoCriterio4",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "AvaliacaoCriterio5",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "AvaliacaoCriterio6",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "AvaliacaoCriterio7",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "AvaliacaoObservacao",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "IdSequencial",
                table: "AlunosLeituras");

            migrationBuilder.AlterColumn<int[]>(
                name: "AtividadesEducacionais",
                table: "Alunos",
                type: "integer[]",
                nullable: false,
                oldClrType: typeof(int[]),
                oldNullable: true);
        }
    }
}
