using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateColaboradorPontoColaboradorPontoApontamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColaboradorPonto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    PeriodoReferencia = table.Column<string>(nullable: true),
                    PeriodoDataInicio = table.Column<DateTime>(nullable: false),
                    PeriodoDataFim = table.Column<DateTime>(nullable: false),
                    ColaboradorId = table.Column<Guid>(nullable: false),
                    EdiId = table.Column<Guid>(nullable: false),
                    EmpresaConvenioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorPonto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColaboradorPonto_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColaboradorPonto_Edis_EdiId",
                        column: x => x.EdiId,
                        principalTable: "Edis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColaboradorPonto_EmpresasConvenios_EmpresaConvenioId",
                        column: x => x.EmpresaConvenioId,
                        principalTable: "EmpresasConvenios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColaboradorPontoApontamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    ColaboradorPontoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorPontoApontamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColaboradorPontoApontamento_ColaboradorPonto_ColaboradorPon~",
                        column: x => x.ColaboradorPontoId,
                        principalTable: "ColaboradorPonto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorPonto_ColaboradorId",
                table: "ColaboradorPonto",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorPonto_EdiId",
                table: "ColaboradorPonto",
                column: "EdiId");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorPonto_EmpresaConvenioId",
                table: "ColaboradorPonto",
                column: "EmpresaConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorPontoApontamento_ColaboradorPontoId",
                table: "ColaboradorPontoApontamento",
                column: "ColaboradorPontoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColaboradorPontoApontamento");

            migrationBuilder.DropTable(
                name: "ColaboradorPonto");
        }
    }
}
