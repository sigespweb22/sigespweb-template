using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateNewFieldInAlunoEja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int[]>(
                name: "Disciplinas",
                table: "AlunosEja",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fase",
                table: "AlunosEja",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disciplinas",
                table: "AlunosEja");

            migrationBuilder.DropColumn(
                name: "Fase",
                table: "AlunosEja");
        }
    }
}
