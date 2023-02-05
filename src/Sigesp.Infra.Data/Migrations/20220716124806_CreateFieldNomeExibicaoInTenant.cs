using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateFieldNomeExibicaoInTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeExibicao",
                table: "Tenants",
                nullable: true);

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
                columns: new[] { "CreatedAt", "NomeExibicao", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 52, DateTimeKind.Local).AddTicks(3389), "TODAS UNIDADES", new DateTime(2022, 7, 16, 9, 48, 6, 53, DateTimeKind.Local).AddTicks(1242) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "NomeExibicao", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 53, DateTimeKind.Local).AddTicks(2581), "PRESÍDIO REGIONAL CRICIÚMA", new DateTime(2022, 7, 16, 9, 48, 6, 53, DateTimeKind.Local).AddTicks(2601) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "NomeExibicao", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 9, 48, 6, 53, DateTimeKind.Local).AddTicks(2638), "PENITENCIÁRIA SUL", new DateTime(2022, 7, 16, 9, 48, 6, 53, DateTimeKind.Local).AddTicks(2641) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeExibicao",
                table: "Tenants");

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
                values: new object[] { new DateTime(2022, 7, 13, 19, 12, 8, 1, DateTimeKind.Local).AddTicks(8057), new DateTime(2022, 7, 13, 19, 12, 8, 1, DateTimeKind.Local).AddTicks(8078) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 13, 19, 12, 8, 3, DateTimeKind.Local).AddTicks(9738), new DateTime(2022, 7, 13, 19, 12, 8, 3, DateTimeKind.Local).AddTicks(9744) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 13, 19, 12, 8, 3, DateTimeKind.Local).AddTicks(8741), new DateTime(2022, 7, 13, 19, 12, 8, 3, DateTimeKind.Local).AddTicks(8772) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 13, 19, 12, 8, 3, DateTimeKind.Local).AddTicks(9794), new DateTime(2022, 7, 13, 19, 12, 8, 3, DateTimeKind.Local).AddTicks(9796) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 13, 19, 12, 8, 3, DateTimeKind.Local).AddTicks(9800), new DateTime(2022, 7, 13, 19, 12, 8, 3, DateTimeKind.Local).AddTicks(9802) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 13, 19, 12, 8, 3, DateTimeKind.Local).AddTicks(9786), new DateTime(2022, 7, 13, 19, 12, 8, 3, DateTimeKind.Local).AddTicks(9789) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 13, 19, 12, 8, 7, DateTimeKind.Local).AddTicks(5162), new DateTime(2022, 7, 13, 19, 12, 8, 7, DateTimeKind.Local).AddTicks(5164) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 13, 19, 12, 8, 7, DateTimeKind.Local).AddTicks(5155), new DateTime(2022, 7, 13, 19, 12, 8, 7, DateTimeKind.Local).AddTicks(5157) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 13, 19, 12, 8, 7, DateTimeKind.Local).AddTicks(5148), new DateTime(2022, 7, 13, 19, 12, 8, 7, DateTimeKind.Local).AddTicks(5151) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 13, 19, 12, 8, 7, DateTimeKind.Local).AddTicks(4143), new DateTime(2022, 7, 13, 19, 12, 8, 7, DateTimeKind.Local).AddTicks(4168) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 13, 19, 12, 8, 7, DateTimeKind.Local).AddTicks(5111), new DateTime(2022, 7, 13, 19, 12, 8, 7, DateTimeKind.Local).AddTicks(5117) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 13, 19, 12, 8, 5, DateTimeKind.Local).AddTicks(5588), new DateTime(2022, 7, 13, 19, 12, 8, 5, DateTimeKind.Local).AddTicks(5609) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 13, 19, 12, 7, 999, DateTimeKind.Local).AddTicks(2043), new DateTime(2022, 7, 13, 19, 12, 8, 0, DateTimeKind.Local).AddTicks(266) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 13, 19, 12, 8, 0, DateTimeKind.Local).AddTicks(1407), new DateTime(2022, 7, 13, 19, 12, 8, 0, DateTimeKind.Local).AddTicks(1427) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 13, 19, 12, 8, 0, DateTimeKind.Local).AddTicks(1463), new DateTime(2022, 7, 13, 19, 12, 8, 0, DateTimeKind.Local).AddTicks(1465) });
        }
    }
}
