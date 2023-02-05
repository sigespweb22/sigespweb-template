using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateAlunoLeituraCronograma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeituraLivroTipo",
                table: "AlunosLeituras");

            migrationBuilder.AddColumn<int>(
                name: "LeituraTipo",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AlunosLeiturasCronogramas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    AnoReferencia = table.Column<DateTime>(nullable: false),
                    PeriodoInicio = table.Column<DateTime>(nullable: false),
                    PeriodoFim = table.Column<DateTime>(nullable: false),
                    PeriodoReferencia = table.Column<int>(nullable: false),
                    DiasPeriodo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosLeiturasCronogramas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosLeiturasCronogramas");

            migrationBuilder.DropColumn(
                name: "LeituraTipo",
                table: "AlunosLeituras");

            migrationBuilder.AddColumn<int>(
                name: "LeituraLivroTipo",
                table: "AlunosLeituras",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
