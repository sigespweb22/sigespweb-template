using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesDataInTenantMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "FormularioLeituraDicasEscrita",
                keyColumn: "Id",
                keyValue: new Guid("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 10, 1, 10, 253, DateTimeKind.Local).AddTicks(1958), new DateTime(2022, 7, 16, 10, 1, 10, 253, DateTimeKind.Local).AddTicks(1988) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 10, 1, 10, 255, DateTimeKind.Local).AddTicks(1808), new DateTime(2022, 7, 16, 10, 1, 10, 255, DateTimeKind.Local).AddTicks(1815) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 10, 1, 10, 255, DateTimeKind.Local).AddTicks(807), new DateTime(2022, 7, 16, 10, 1, 10, 255, DateTimeKind.Local).AddTicks(838) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 10, 1, 10, 255, DateTimeKind.Local).AddTicks(1853), new DateTime(2022, 7, 16, 10, 1, 10, 255, DateTimeKind.Local).AddTicks(1855) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 10, 1, 10, 255, DateTimeKind.Local).AddTicks(1860), new DateTime(2022, 7, 16, 10, 1, 10, 255, DateTimeKind.Local).AddTicks(1862) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 10, 1, 10, 255, DateTimeKind.Local).AddTicks(1845), new DateTime(2022, 7, 16, 10, 1, 10, 255, DateTimeKind.Local).AddTicks(1847) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 10, 1, 10, 258, DateTimeKind.Local).AddTicks(8950), new DateTime(2022, 7, 16, 10, 1, 10, 258, DateTimeKind.Local).AddTicks(8952) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 10, 1, 10, 258, DateTimeKind.Local).AddTicks(8943), new DateTime(2022, 7, 16, 10, 1, 10, 258, DateTimeKind.Local).AddTicks(8945) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 10, 1, 10, 258, DateTimeKind.Local).AddTicks(8936), new DateTime(2022, 7, 16, 10, 1, 10, 258, DateTimeKind.Local).AddTicks(8938) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 10, 1, 10, 258, DateTimeKind.Local).AddTicks(7954), new DateTime(2022, 7, 16, 10, 1, 10, 258, DateTimeKind.Local).AddTicks(7973) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 10, 1, 10, 258, DateTimeKind.Local).AddTicks(8899), new DateTime(2022, 7, 16, 10, 1, 10, 258, DateTimeKind.Local).AddTicks(8905) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 10, 1, 10, 256, DateTimeKind.Local).AddTicks(9150), new DateTime(2022, 7, 16, 10, 1, 10, 256, DateTimeKind.Local).AddTicks(9176) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "Nome", "NomeExibicao", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 10, 1, 10, 249, DateTimeKind.Local).AddTicks(5768), "Tenância Presídio Regional de Criciúma", "PRESÍDIO REGIONAL CRICIÚMA", new DateTime(2022, 7, 16, 10, 1, 10, 250, DateTimeKind.Local).AddTicks(4451) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "Nome", "NomeExibicao", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 10, 1, 10, 250, DateTimeKind.Local).AddTicks(5907), "Tenância Master", "TODAS UNIDADES", new DateTime(2022, 7, 16, 10, 1, 10, 250, DateTimeKind.Local).AddTicks(5928) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 10, 1, 10, 250, DateTimeKind.Local).AddTicks(5976), new DateTime(2022, 7, 16, 10, 1, 10, 250, DateTimeKind.Local).AddTicks(5978) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "FormularioLeituraDicasEscrita",
                keyColumn: "Id",
                keyValue: new Guid("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 54, DateTimeKind.Local).AddTicks(8134), new DateTime(2022, 7, 16, 9, 48, 6, 54, DateTimeKind.Local).AddTicks(8147) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 56, DateTimeKind.Local).AddTicks(6793), new DateTime(2022, 7, 16, 9, 48, 6, 56, DateTimeKind.Local).AddTicks(6799) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 56, DateTimeKind.Local).AddTicks(5866), new DateTime(2022, 7, 16, 9, 48, 6, 56, DateTimeKind.Local).AddTicks(5880) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 56, DateTimeKind.Local).AddTicks(6834), new DateTime(2022, 7, 16, 9, 48, 6, 56, DateTimeKind.Local).AddTicks(6836) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 56, DateTimeKind.Local).AddTicks(6840), new DateTime(2022, 7, 16, 9, 48, 6, 56, DateTimeKind.Local).AddTicks(6842) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 56, DateTimeKind.Local).AddTicks(6826), new DateTime(2022, 7, 16, 9, 48, 6, 56, DateTimeKind.Local).AddTicks(6829) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 59, DateTimeKind.Local).AddTicks(8441), new DateTime(2022, 7, 16, 9, 48, 6, 59, DateTimeKind.Local).AddTicks(8443) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 59, DateTimeKind.Local).AddTicks(8434), new DateTime(2022, 7, 16, 9, 48, 6, 59, DateTimeKind.Local).AddTicks(8436) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 59, DateTimeKind.Local).AddTicks(8428), new DateTime(2022, 7, 16, 9, 48, 6, 59, DateTimeKind.Local).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 59, DateTimeKind.Local).AddTicks(7475), new DateTime(2022, 7, 16, 9, 48, 6, 59, DateTimeKind.Local).AddTicks(7487) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 59, DateTimeKind.Local).AddTicks(8397), new DateTime(2022, 7, 16, 9, 48, 6, 59, DateTimeKind.Local).AddTicks(8403) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 58, DateTimeKind.Local).AddTicks(923), new DateTime(2022, 7, 16, 9, 48, 6, 58, DateTimeKind.Local).AddTicks(935) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "Nome", "NomeExibicao", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 52, DateTimeKind.Local).AddTicks(3389), "Tenância Master", "TODAS UNIDADES", new DateTime(2022, 7, 16, 9, 48, 6, 53, DateTimeKind.Local).AddTicks(1242) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "Nome", "NomeExibicao", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 53, DateTimeKind.Local).AddTicks(2581), "Tenância Presídio Regional de Criciúma", "PRESÍDIO REGIONAL CRICIÚMA", new DateTime(2022, 7, 16, 9, 48, 6, 53, DateTimeKind.Local).AddTicks(2601) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 53, DateTimeKind.Local).AddTicks(2638), new DateTime(2022, 7, 16, 9, 48, 6, 53, DateTimeKind.Local).AddTicks(2641) });
        }
    }
}
