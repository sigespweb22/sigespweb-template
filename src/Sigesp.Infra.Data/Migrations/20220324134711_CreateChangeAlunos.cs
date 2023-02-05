using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeAlunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Detentos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cep",
                table: "Detentos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Detentos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Detentos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Detentos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Idade",
                table: "Detentos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Detentos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Detentos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Detentos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AlunosRedacaoDPU",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    InscricaoNumero = table.Column<string>(nullable: true),
                    DataLimiteEntregaRedacao = table.Column<DateTime>(nullable: true),
                    Etapa = table.Column<int>(nullable: false),
                    IsPrivadoLiberdade = table.Column<bool>(nullable: false, defaultValue: true),
                    RedacaoImagem = table.Column<string>(nullable: true),
                    Media = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    NotaCriatividade = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    NotaConteudo = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    NotaClareza = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    NotaPertinencia = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    CertificadoImagem = table.Column<string>(nullable: true),
                    ResultadoColocacao = table.Column<int>(nullable: false, defaultValue: 0),
                    AlunoId = table.Column<Guid>(nullable: false),
                    ProfessorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosRedacaoDPU", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunosRedacaoDPU_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosRedacaoDPU_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosRedacaoDPU_AlunoId",
                table: "AlunosRedacaoDPU",
                column: "AlunoId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosRedacaoDPU_ProfessorId",
                table: "AlunosRedacaoDPU",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosRedacaoDPU");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Detentos");
        }
    }
}
