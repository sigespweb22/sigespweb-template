using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateIncludeEntityAuditInAlunoEjaDisciplina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AlunoEjaDisciplinas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "AlunoEjaDisciplinas",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AlunoEjaDisciplinas",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AlunoEjaDisciplinas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AlunoEjaDisciplinas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "AlunoEjaDisciplinas",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AlunoEjaDisciplinas");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AlunoEjaDisciplinas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AlunoEjaDisciplinas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AlunoEjaDisciplinas");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AlunoEjaDisciplinas");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AlunoEjaDisciplinas");
        }
    }
}
