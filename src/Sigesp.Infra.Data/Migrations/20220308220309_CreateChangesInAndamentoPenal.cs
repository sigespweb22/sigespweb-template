using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesInAndamentoPenal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAutorizacao",
                table: "AndamentoPenal");

            migrationBuilder.DropColumn(
                name: "STEndereco",
                table: "AndamentoPenal");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "AndamentoPenal",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1500)",
                oldMaxLength: 1500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Historico",
                table: "AndamentoPenal",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pec",
                table: "AndamentoPenal");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "AndamentoPenal",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Historico",
                table: "AndamentoPenal",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAutorizacao",
                table: "AndamentoPenal",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "STEndereco",
                table: "AndamentoPenal",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
