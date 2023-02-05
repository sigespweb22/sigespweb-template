using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateImplementacoesAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudantesDisciplinas");

            migrationBuilder.DropTable(
                name: "Leitores");

            migrationBuilder.DropTable(
                name: "Estudantes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPedidoEnturmacao",
                table: "Alunos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "CejaMatricula",
                table: "Alunos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CejaId",
                table: "Alunos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(35)",
                oldMaxLength: 35,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CejaDataMatricula",
                table: "Alunos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "LivroGeneroId",
                table: "Alunos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AlunosEja",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    DataIngresso = table.Column<DateTime>(nullable: true),
                    Curso = table.Column<int>(nullable: false, defaultValue: 0),
                    TurnoPeriodo = table.Column<int>(nullable: false, defaultValue: 0),
                    EjaOcorrenciaDesistencia = table.Column<int>(nullable: false, defaultValue: 0),
                    AlunoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosEja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunosEja_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosEncceja",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Curso = table.Column<int>(nullable: false, defaultValue: 0),
                    DataProva = table.Column<DateTime>(nullable: true),
                    InscricaoNumero = table.Column<string>(nullable: true),
                    NotaAreaI = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    NotaAreaII = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    NotaAreaIII = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    NotaAreaIV = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    NotaRedacao = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Media = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    HasCertificado = table.Column<bool>(nullable: false, defaultValue: false),
                    IsAprovado = table.Column<bool>(nullable: false, defaultValue: false),
                    AlunoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosEncceja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunosEncceja_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosEnem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    DataProva = table.Column<DateTime>(nullable: true),
                    InscricaoNumero = table.Column<string>(nullable: true),
                    LinguaEstrangeira = table.Column<int>(nullable: false, defaultValue: 0),
                    NotaCN = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    NotaCH = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    NotaLC = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    NotaMT = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    NotaRedacao = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Media = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    HasMediaMinima = table.Column<bool>(nullable: false, defaultValue: false),
                    AlunoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosEnem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunosEnem_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosLeitura",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    DataIngresso = table.Column<DateTime>(nullable: false),
                    LeituraOcorrenciaDesistencia = table.Column<int>(nullable: false, defaultValue: 0),
                    LeituraDataOcorrenciaDesistencia = table.Column<DateTime>(nullable: false),
                    AlunoId = table.Column<Guid>(nullable: false),
                    ProfessorId = table.Column<Guid>(nullable: false),
                    LivroGeneroId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosLeitura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunosLeitura_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosLeitura_LivrosGeneros_LivroGeneroId",
                        column: x => x.LivroGeneroId,
                        principalTable: "LivrosGeneros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosLeitura_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoEjaDisciplinas",
                columns: table => new
                {
                    AlunoEjaId = table.Column<Guid>(nullable: false),
                    DisciplinaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_AlunoEjaDisciplinas_AlunosEja_AlunoEjaId",
                        column: x => x.AlunoEjaId,
                        principalTable: "AlunosEja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoEjaDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoLeituraLivros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    LeituraLivroTipo = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    AlunoLeituraId = table.Column<Guid>(nullable: false),
                    LivroId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoLeituraLivros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunoLeituraLivros_AlunosLeitura_AlunoLeituraId",
                        column: x => x.AlunoLeituraId,
                        principalTable: "AlunosLeitura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoLeituraLivros_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_LivroGeneroId",
                table: "Alunos",
                column: "LivroGeneroId");

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

            migrationBuilder.CreateIndex(
                name: "IX_AlunoLeituraLivros_AlunoLeituraId",
                table: "AlunoLeituraLivros",
                column: "AlunoLeituraId",
                unique: true,
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoLeituraLivros_LivroId",
                table: "AlunoLeituraLivros",
                column: "LivroId",
                unique: true,
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosEja_AlunoId",
                table: "AlunosEja",
                column: "AlunoId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosEncceja_AlunoId",
                table: "AlunosEncceja",
                column: "AlunoId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosEnem_AlunoId",
                table: "AlunosEnem",
                column: "AlunoId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeitura_AlunoId",
                table: "AlunosLeitura",
                column: "AlunoId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeitura_LivroGeneroId",
                table: "AlunosLeitura",
                column: "LivroGeneroId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeitura_ProfessorId",
                table: "AlunosLeitura",
                column: "ProfessorId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_LivrosGeneros_LivroGeneroId",
                table: "Alunos",
                column: "LivroGeneroId",
                principalTable: "LivrosGeneros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_LivrosGeneros_LivroGeneroId",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "AlunoEjaDisciplinas");

            migrationBuilder.DropTable(
                name: "AlunoLeituraLivros");

            migrationBuilder.DropTable(
                name: "AlunosEncceja");

            migrationBuilder.DropTable(
                name: "AlunosEnem");

            migrationBuilder.DropTable(
                name: "AlunosEja");

            migrationBuilder.DropTable(
                name: "AlunosLeitura");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_LivroGeneroId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "LivroGeneroId",
                table: "Alunos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPedidoEnturmacao",
                table: "Alunos",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CejaMatricula",
                table: "Alunos",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CejaId",
                table: "Alunos",
                type: "character varying(35)",
                maxLength: 35,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CejaDataMatricula",
                table: "Alunos",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Estudantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Curso = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TurnoPeriodo = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudantes_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leitores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DataOcorrenciaDesistencia = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LivroGeneroId = table.Column<Guid>(type: "uuid", nullable: false),
                    OcorrenciaDesistencia = table.Column<int>(type: "integer", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leitores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leitores_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
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

            migrationBuilder.CreateTable(
                name: "EstudantesDisciplinas",
                columns: table => new
                {
                    DisciplinaId = table.Column<Guid>(type: "uuid", nullable: false),
                    EstudanteId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_EstudantesDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudantesDisciplinas_Estudantes_EstudanteId",
                        column: x => x.EstudanteId,
                        principalTable: "Estudantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudantes_AlunoId",
                table: "Estudantes",
                column: "AlunoId",
                unique: true,
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_EstudantesDisciplinas_DisciplinaId",
                table: "EstudantesDisciplinas",
                column: "DisciplinaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstudantesDisciplinas_EstudanteId",
                table: "EstudantesDisciplinas",
                column: "EstudanteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leitores_AlunoId",
                table: "Leitores",
                column: "AlunoId",
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
    }
}
