using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateFormularioLeituraParteI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormularioLeituraDicasEscrita",
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
                    table.PrimaryKey("PK_FormularioLeituraDicasEscrita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormularioLeituraPerguntasGrupos",
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
                    table.PrimaryKey("PK_FormularioLeituraPerguntasGrupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormularioLeituraDicasEscritaDicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Dica = table.Column<string>(maxLength: 255, nullable: false),
                    Ordem = table.Column<int>(nullable: false),
                    FormularioLeituraDicaEscritaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioLeituraDicasEscritaDicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormularioLeituraDicasEscritaDicas_FormularioLeituraDicasEs~",
                        column: x => x.FormularioLeituraDicaEscritaId,
                        principalTable: "FormularioLeituraDicasEscrita",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormularioLeituraPerguntas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Pergunta = table.Column<string>(maxLength: 255, nullable: false),
                    Ordem = table.Column<int>(nullable: false),
                    FormularioLeituraPerguntaGrupoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioLeituraPerguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormularioLeituraPerguntas_FormularioLeituraPerguntasGrupos~",
                        column: x => x.FormularioLeituraPerguntaGrupoId,
                        principalTable: "FormularioLeituraPerguntasGrupos",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "1e526008-75f7-4a01-9942-d178f2b38888",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.InsertData(
                table: "FormularioLeituraDicasEscrita",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "Nome", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b"), new DateTime(2022, 6, 26, 16, 17, 9, 664, DateTimeKind.Local).AddTicks(768), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), false, "SENÃO E SE NÃO", new DateTime(2022, 6, 26, 16, 17, 9, 664, DateTimeKind.Local).AddTicks(798), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") });

            migrationBuilder.InsertData(
                table: "FormularioLeituraPerguntasGrupos",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "Nome", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"), new DateTime(2022, 6, 26, 16, 17, 9, 667, DateTimeKind.Local).AddTicks(5246), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), false, "PERGUNTAS PARA CRONOGRAMA MAI/JUN", new DateTime(2022, 6, 26, 16, 17, 9, 667, DateTimeKind.Local).AddTicks(5258), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 26, 16, 17, 9, 660, DateTimeKind.Local).AddTicks(6983), new DateTime(2022, 6, 26, 16, 17, 9, 661, DateTimeKind.Local).AddTicks(6468) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 26, 16, 17, 9, 661, DateTimeKind.Local).AddTicks(8309), new DateTime(2022, 6, 26, 16, 17, 9, 661, DateTimeKind.Local).AddTicks(8326) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 26, 16, 17, 9, 661, DateTimeKind.Local).AddTicks(8519), new DateTime(2022, 6, 26, 16, 17, 9, 661, DateTimeKind.Local).AddTicks(8521) });

            migrationBuilder.InsertData(
                table: "FormularioLeituraDicasEscritaDicas",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Dica", "FormularioLeituraDicaEscritaId", "IsDeleted", "Ordem", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"), new DateTime(2022, 6, 26, 16, 17, 9, 666, DateTimeKind.Local).AddTicks(157), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "A palavra “SENÃO” é uma conjunção opositiva, podendo ser substituída por “DO CONTRÁRIO”.", new Guid("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b"), false, 1, new DateTime(2022, 6, 26, 16, 17, 9, 666, DateTimeKind.Local).AddTicks(178), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") },
                    { new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"), new DateTime(2022, 6, 26, 16, 17, 9, 666, DateTimeKind.Local).AddTicks(1081), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "Ex.:Eu estava muito ocupado, SENÃO (do contrário) teria ido à sua festa. Palavra “SE NÃO”indica uma negação,", new Guid("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b"), false, 2, new DateTime(2022, 6, 26, 16, 17, 9, 666, DateTimeKind.Local).AddTicks(1087), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") },
                    { new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"), new DateTime(2022, 6, 26, 16, 17, 9, 666, DateTimeKind.Local).AddTicks(1128), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "podendo ser substituída por “CASO NÃO”", new Guid("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b"), false, 3, new DateTime(2022, 6, 26, 16, 17, 9, 666, DateTimeKind.Local).AddTicks(1130), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") },
                    { new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"), new DateTime(2022, 6, 26, 16, 17, 9, 666, DateTimeKind.Local).AddTicks(1135), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "A expressão “SE NÃO” indica uma negação, podendo ser substituída por “CASO NÃO”.", new Guid("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b"), false, 4, new DateTime(2022, 6, 26, 16, 17, 9, 666, DateTimeKind.Local).AddTicks(1137), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") },
                    { new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"), new DateTime(2022, 6, 26, 16, 17, 9, 666, DateTimeKind.Local).AddTicks(1141), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "Ex.:SE NÃO (caso não) fosse pela chuva, o passeio teria sido ótimo.", new Guid("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b"), false, 5, new DateTime(2022, 6, 26, 16, 17, 9, 666, DateTimeKind.Local).AddTicks(1143), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") }
                });

            migrationBuilder.InsertData(
                table: "FormularioLeituraPerguntas",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FormularioLeituraPerguntaGrupoId", "IsDeleted", "Ordem", "Pergunta", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"), new DateTime(2022, 6, 26, 16, 17, 9, 669, DateTimeKind.Local).AddTicks(1675), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"), false, 1, "Quais são os personagens da história?", new DateTime(2022, 6, 26, 16, 17, 9, 669, DateTimeKind.Local).AddTicks(1689), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") },
                    { new Guid("e94b5df4-379c-482d-99e0-10e35760d580"), new DateTime(2022, 6, 26, 16, 17, 9, 669, DateTimeKind.Local).AddTicks(2603), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"), false, 2, "Em que tempo ocorreu a história do livro?", new DateTime(2022, 6, 26, 16, 17, 9, 669, DateTimeKind.Local).AddTicks(2609), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") },
                    { new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"), new DateTime(2022, 6, 26, 16, 17, 9, 669, DateTimeKind.Local).AddTicks(2634), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"), false, 3, "Você alteraria o final da história? Por quê?", new DateTime(2022, 6, 26, 16, 17, 9, 669, DateTimeKind.Local).AddTicks(2636), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") },
                    { new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"), new DateTime(2022, 6, 26, 16, 17, 9, 669, DateTimeKind.Local).AddTicks(2641), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"), false, 4, "Crie uma frase utilizando adequadamente as palavras : SENÃO e SE NÃO.", new DateTime(2022, 6, 26, 16, 17, 9, 669, DateTimeKind.Local).AddTicks(2642), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") },
                    { new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"), new DateTime(2022, 6, 26, 16, 17, 9, 669, DateTimeKind.Local).AddTicks(2647), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"), false, 5, "Reescreva a frase corretamente: “Na sala a menas meninas ou menos meninos?", new DateTime(2022, 6, 26, 16, 17, 9, 669, DateTimeKind.Local).AddTicks(2649), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormularioLeituraDicasEscritaDicas_FormularioLeituraDicaEsc~",
                table: "FormularioLeituraDicasEscritaDicas",
                column: "FormularioLeituraDicaEscritaId");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioLeituraPerguntas_FormularioLeituraPerguntaGrupoId",
                table: "FormularioLeituraPerguntas",
                column: "FormularioLeituraPerguntaGrupoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormularioLeituraDicasEscritaDicas");

            migrationBuilder.DropTable(
                name: "FormularioLeituraPerguntas");

            migrationBuilder.DropTable(
                name: "FormularioLeituraDicasEscrita");

            migrationBuilder.DropTable(
                name: "FormularioLeituraPerguntasGrupos");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "1e526008-75f7-4a01-9942-d178f2b38888",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 21, 10, 13, 40, 446, DateTimeKind.Local).AddTicks(288), new DateTime(2022, 6, 21, 10, 13, 40, 446, DateTimeKind.Local).AddTicks(8344) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 21, 10, 13, 40, 446, DateTimeKind.Local).AddTicks(9456), new DateTime(2022, 6, 21, 10, 13, 40, 446, DateTimeKind.Local).AddTicks(9475) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 21, 10, 13, 40, 446, DateTimeKind.Local).AddTicks(9506), new DateTime(2022, 6, 21, 10, 13, 40, 446, DateTimeKind.Local).AddTicks(9508) });
        }
    }
}
