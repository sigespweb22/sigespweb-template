using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateContabilEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContabilEventoId",
                table: "Lancamentos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "OrigemTipo",
                table: "Lancamentos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ContabilEventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 150, nullable: true),
                    Especificacao = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContabilEventos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ContabilEventoId",
                table: "Lancamentos",
                column: "ContabilEventoId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_ContabilEventos_ContabilEventoId",
                table: "Lancamentos",
                column: "ContabilEventoId",
                principalTable: "ContabilEventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_ContabilEventos_ContabilEventoId",
                table: "Lancamentos");

            migrationBuilder.DropTable(
                name: "ContabilEventos");

            migrationBuilder.DropIndex(
                name: "IX_Lancamentos_ContabilEventoId",
                table: "Lancamentos");

            migrationBuilder.DropColumn(
                name: "ContabilEventoId",
                table: "Lancamentos");

            migrationBuilder.DropColumn(
                name: "OrigemTipo",
                table: "Lancamentos");
        }
    }
}
