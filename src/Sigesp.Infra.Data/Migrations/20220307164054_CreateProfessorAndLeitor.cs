using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateProfessorAndLeitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leitores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Escolaridade = table.Column<int>(nullable: false),
                    CejaId = table.Column<string>(nullable: true),
                    CejaMatricula = table.Column<string>(maxLength: 100, nullable: true),
                    CejaDataMatricula = table.Column<DateTime>(nullable: false),
                    DataUltimoStatus = table.Column<DateTime>(nullable: false),
                    OcorrenciaIsDeleted = table.Column<int>(nullable: false, defaultValue: 0),
                    DataUltimoIsDeletedOcorrencia = table.Column<DateTime>(nullable: false),
                    IsEnturmado = table.Column<bool>(nullable: false),
                    DataPedidoEnturmacao = table.Column<DateTime>(nullable: false),
                    ProfessorId = table.Column<Guid>(nullable: false),
                    LivroGeneroId = table.Column<Guid>(nullable: false),
                    DetentoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leitores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leitores_Detentos_DetentoId",
                        column: x => x.DetentoId,
                        principalTable: "Detentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leitores_LivrosGeneros_LivroGeneroId",
                        column: x => x.LivroGeneroId,
                        principalTable: "LivrosGeneros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leitores_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leitores_DetentoId",
                table: "Leitores",
                column: "DetentoId",
                unique: true,
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_Leitores_LivroGeneroId",
                table: "Leitores",
                column: "LivroGeneroId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_Leitores_ProfessorId",
                table: "Leitores",
                column: "ProfessorId",
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leitores");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
