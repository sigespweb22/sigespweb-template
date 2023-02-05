using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesInSERRParteII : Migration
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
                values: new object[] { new DateTime(2022, 8, 6, 18, 39, 5, 868, DateTimeKind.Local).AddTicks(2856), new DateTime(2022, 8, 6, 18, 39, 5, 868, DateTimeKind.Local).AddTicks(2871) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 18, 39, 5, 870, DateTimeKind.Local).AddTicks(1422), new DateTime(2022, 8, 6, 18, 39, 5, 870, DateTimeKind.Local).AddTicks(1429) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 18, 39, 5, 870, DateTimeKind.Local).AddTicks(533), new DateTime(2022, 8, 6, 18, 39, 5, 870, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 18, 39, 5, 870, DateTimeKind.Local).AddTicks(1462), new DateTime(2022, 8, 6, 18, 39, 5, 870, DateTimeKind.Local).AddTicks(1464) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 18, 39, 5, 870, DateTimeKind.Local).AddTicks(1468), new DateTime(2022, 8, 6, 18, 39, 5, 870, DateTimeKind.Local).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 18, 39, 5, 870, DateTimeKind.Local).AddTicks(1455), new DateTime(2022, 8, 6, 18, 39, 5, 870, DateTimeKind.Local).AddTicks(1457) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 18, 39, 5, 873, DateTimeKind.Local).AddTicks(8397), new DateTime(2022, 8, 6, 18, 39, 5, 873, DateTimeKind.Local).AddTicks(8400) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 18, 39, 5, 873, DateTimeKind.Local).AddTicks(8391), new DateTime(2022, 8, 6, 18, 39, 5, 873, DateTimeKind.Local).AddTicks(8393) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 18, 39, 5, 873, DateTimeKind.Local).AddTicks(8384), new DateTime(2022, 8, 6, 18, 39, 5, 873, DateTimeKind.Local).AddTicks(8387) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 18, 39, 5, 873, DateTimeKind.Local).AddTicks(7418), new DateTime(2022, 8, 6, 18, 39, 5, 873, DateTimeKind.Local).AddTicks(7441) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 18, 39, 5, 873, DateTimeKind.Local).AddTicks(8329), new DateTime(2022, 8, 6, 18, 39, 5, 873, DateTimeKind.Local).AddTicks(8336) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 18, 39, 5, 871, DateTimeKind.Local).AddTicks(9203), new DateTime(2022, 8, 6, 18, 39, 5, 871, DateTimeKind.Local).AddTicks(9230) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 18, 39, 5, 865, DateTimeKind.Local).AddTicks(5878), new DateTime(2022, 8, 6, 18, 39, 5, 866, DateTimeKind.Local).AddTicks(5031) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 18, 39, 5, 866, DateTimeKind.Local).AddTicks(6351), new DateTime(2022, 8, 6, 18, 39, 5, 866, DateTimeKind.Local).AddTicks(6373) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 18, 39, 5, 866, DateTimeKind.Local).AddTicks(6412), new DateTime(2022, 8, 6, 18, 39, 5, 866, DateTimeKind.Local).AddTicks(6415) });
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
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 662, DateTimeKind.Local).AddTicks(715), new DateTime(2022, 8, 2, 15, 51, 49, 662, DateTimeKind.Local).AddTicks(727) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9098), new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9104) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(8185), new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(8198) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9139), new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9141) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9145), new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9147) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9132), new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9134) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2388), new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2390) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2381), new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2383) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2373), new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2375) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(1307), new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(1326) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2319), new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2324) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 665, DateTimeKind.Local).AddTicks(3108), new DateTime(2022, 8, 2, 15, 51, 49, 665, DateTimeKind.Local).AddTicks(3123) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 659, DateTimeKind.Local).AddTicks(5009), new DateTime(2022, 8, 2, 15, 51, 49, 660, DateTimeKind.Local).AddTicks(2911) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 660, DateTimeKind.Local).AddTicks(4374), new DateTime(2022, 8, 2, 15, 51, 49, 660, DateTimeKind.Local).AddTicks(4394) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 660, DateTimeKind.Local).AddTicks(4432), new DateTime(2022, 8, 2, 15, 51, 49, 660, DateTimeKind.Local).AddTicks(4435) });
        }
    }
}
