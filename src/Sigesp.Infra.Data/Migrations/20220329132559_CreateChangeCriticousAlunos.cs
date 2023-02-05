using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeCriticousAlunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunosLeitura_Alunos_AlunoId",
                table: "AlunosLeitura");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunosLeitura_LivrosGeneros_LivroGeneroId",
                table: "AlunosLeitura");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunosLeitura_Professores_ProfessorId",
                table: "AlunosLeitura");

            migrationBuilder.DropTable(
                name: "AlunosLeituraLivros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunosLeitura",
                table: "AlunosLeitura");

            migrationBuilder.DropIndex(
                name: "IX_AlunosLeitura_AlunoId",
                table: "AlunosLeitura");

            migrationBuilder.DropIndex(
                name: "IX_AlunosLeitura_LivroGeneroId",
                table: "AlunosLeitura");

            migrationBuilder.DropIndex(
                name: "IX_AlunosLeitura_ProfessorId",
                table: "AlunosLeitura");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "AlunosLeitura");

            migrationBuilder.DropColumn(
                name: "DataIngresso",
                table: "AlunosLeitura");

            migrationBuilder.DropColumn(
                name: "LeituraDataOcorrenciaDesistencia",
                table: "AlunosLeitura");

            migrationBuilder.DropColumn(
                name: "LeituraOcorrenciaDesistencia",
                table: "AlunosLeitura");

            migrationBuilder.DropColumn(
                name: "LivroGeneroId",
                table: "AlunosLeitura");

            migrationBuilder.RenameTable(
                name: "AlunosLeitura",
                newName: "AlunosLeituras");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessorId",
                table: "AlunosLeituras",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "AlunoLeitorId",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFim",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicio",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LeituraLivroTipo",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "LivroId",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunosLeituras",
                table: "AlunosLeituras",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AlunosLeitores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    DataIngresso = table.Column<DateTime>(nullable: false),
                    OcorrenciaDesistencia = table.Column<int>(nullable: false, defaultValue: 0),
                    DataOcorrenciaDesistencia = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    AlunoId = table.Column<Guid>(nullable: false),
                    ProfessorId = table.Column<Guid>(nullable: false),
                    LivroGeneroId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosLeitores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunosLeitores_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosLeitores_LivrosGeneros_LivroGeneroId",
                        column: x => x.LivroGeneroId,
                        principalTable: "LivrosGeneros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosLeitores_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeituras_AlunoLeitorId",
                table: "AlunosLeituras",
                column: "AlunoLeitorId",
                unique: true,
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeituras_LivroId",
                table: "AlunosLeituras",
                column: "LivroId",
                unique: true,
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeituras_ProfessorId",
                table: "AlunosLeituras",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeitores_AlunoId",
                table: "AlunosLeitores",
                column: "AlunoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeitores_LivroGeneroId",
                table: "AlunosLeitores",
                column: "LivroGeneroId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeitores_ProfessorId",
                table: "AlunosLeitores",
                column: "ProfessorId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosLeituras_AlunosLeitores_AlunoLeitorId",
                table: "AlunosLeituras",
                column: "AlunoLeitorId",
                principalTable: "AlunosLeitores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosLeituras_Livros_LivroId",
                table: "AlunosLeituras",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosLeituras_Professores_ProfessorId",
                table: "AlunosLeituras",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunosLeituras_AlunosLeitores_AlunoLeitorId",
                table: "AlunosLeituras");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunosLeituras_Livros_LivroId",
                table: "AlunosLeituras");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunosLeituras_Professores_ProfessorId",
                table: "AlunosLeituras");

            migrationBuilder.DropTable(
                name: "AlunosLeitores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunosLeituras",
                table: "AlunosLeituras");

            migrationBuilder.DropIndex(
                name: "IX_AlunosLeituras_AlunoLeitorId",
                table: "AlunosLeituras");

            migrationBuilder.DropIndex(
                name: "IX_AlunosLeituras_LivroId",
                table: "AlunosLeituras");

            migrationBuilder.DropIndex(
                name: "IX_AlunosLeituras_ProfessorId",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "AlunoLeitorId",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "DataFim",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "DataInicio",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "LeituraLivroTipo",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "AlunosLeituras");

            migrationBuilder.RenameTable(
                name: "AlunosLeituras",
                newName: "AlunosLeitura");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessorId",
                table: "AlunosLeitura",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AlunoId",
                table: "AlunosLeitura",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataIngresso",
                table: "AlunosLeitura",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LeituraDataOcorrenciaDesistencia",
                table: "AlunosLeitura",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LeituraOcorrenciaDesistencia",
                table: "AlunosLeitura",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "LivroGeneroId",
                table: "AlunosLeitura",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunosLeitura",
                table: "AlunosLeitura",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AlunosLeituraLivros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AlunoLeituraId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DataFim = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LeituraLivroTipo = table.Column<int>(type: "integer", nullable: false),
                    LivroId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosLeituraLivros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunosLeituraLivros_AlunosLeitura_AlunoLeituraId",
                        column: x => x.AlunoLeituraId,
                        principalTable: "AlunosLeitura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosLeituraLivros_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeitura_AlunoId",
                table: "AlunosLeitura",
                column: "AlunoId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeituraLivros_AlunoLeituraId",
                table: "AlunosLeituraLivros",
                column: "AlunoLeituraId",
                unique: true,
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeituraLivros_LivroId",
                table: "AlunosLeituraLivros",
                column: "LivroId",
                unique: true,
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosLeitura_Alunos_AlunoId",
                table: "AlunosLeitura",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosLeitura_LivrosGeneros_LivroGeneroId",
                table: "AlunosLeitura",
                column: "LivroGeneroId",
                principalTable: "LivrosGeneros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosLeitura_Professores_ProfessorId",
                table: "AlunosLeitura",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
