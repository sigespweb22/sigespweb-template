using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesInFormularioLeituraDicaEscritaMap : Migration
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
                values: new object[] { new DateTime(2022, 10, 15, 17, 17, 9, 348, DateTimeKind.Local).AddTicks(9988), new DateTime(2022, 10, 15, 17, 17, 9, 349, DateTimeKind.Local).AddTicks(4) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 15, 17, 17, 9, 350, DateTimeKind.Local).AddTicks(8863), new DateTime(2022, 10, 15, 17, 17, 9, 350, DateTimeKind.Local).AddTicks(8869) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 15, 17, 17, 9, 350, DateTimeKind.Local).AddTicks(7975), new DateTime(2022, 10, 15, 17, 17, 9, 350, DateTimeKind.Local).AddTicks(7990) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 15, 17, 17, 9, 350, DateTimeKind.Local).AddTicks(8901), new DateTime(2022, 10, 15, 17, 17, 9, 350, DateTimeKind.Local).AddTicks(8903) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 15, 17, 17, 9, 350, DateTimeKind.Local).AddTicks(8908), new DateTime(2022, 10, 15, 17, 17, 9, 350, DateTimeKind.Local).AddTicks(8910) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 15, 17, 17, 9, 350, DateTimeKind.Local).AddTicks(8894), new DateTime(2022, 10, 15, 17, 17, 9, 350, DateTimeKind.Local).AddTicks(8896) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 15, 17, 17, 9, 354, DateTimeKind.Local).AddTicks(6999), new DateTime(2022, 10, 15, 17, 17, 9, 354, DateTimeKind.Local).AddTicks(7001) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 15, 17, 17, 9, 354, DateTimeKind.Local).AddTicks(6991), new DateTime(2022, 10, 15, 17, 17, 9, 354, DateTimeKind.Local).AddTicks(6993) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 15, 17, 17, 9, 354, DateTimeKind.Local).AddTicks(6985), new DateTime(2022, 10, 15, 17, 17, 9, 354, DateTimeKind.Local).AddTicks(6987) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 15, 17, 17, 9, 354, DateTimeKind.Local).AddTicks(5995), new DateTime(2022, 10, 15, 17, 17, 9, 354, DateTimeKind.Local).AddTicks(6008) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 15, 17, 17, 9, 354, DateTimeKind.Local).AddTicks(6948), new DateTime(2022, 10, 15, 17, 17, 9, 354, DateTimeKind.Local).AddTicks(6955) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 15, 17, 17, 9, 352, DateTimeKind.Local).AddTicks(9098), new DateTime(2022, 10, 15, 17, 17, 9, 352, DateTimeKind.Local).AddTicks(9114) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 15, 17, 17, 9, 345, DateTimeKind.Local).AddTicks(8484), new DateTime(2022, 10, 15, 17, 17, 9, 346, DateTimeKind.Local).AddTicks(6778) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 15, 17, 17, 9, 346, DateTimeKind.Local).AddTicks(8078), new DateTime(2022, 10, 15, 17, 17, 9, 346, DateTimeKind.Local).AddTicks(8099) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 15, 17, 17, 9, 346, DateTimeKind.Local).AddTicks(8136), new DateTime(2022, 10, 15, 17, 17, 9, 346, DateTimeKind.Local).AddTicks(8139) });
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
                values: new object[] { new DateTime(2022, 10, 1, 15, 14, 19, 371, DateTimeKind.Local).AddTicks(531), new DateTime(2022, 10, 1, 15, 14, 19, 371, DateTimeKind.Local).AddTicks(547) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 1, 15, 14, 19, 372, DateTimeKind.Local).AddTicks(7622), new DateTime(2022, 10, 1, 15, 14, 19, 372, DateTimeKind.Local).AddTicks(7628) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 1, 15, 14, 19, 372, DateTimeKind.Local).AddTicks(6766), new DateTime(2022, 10, 1, 15, 14, 19, 372, DateTimeKind.Local).AddTicks(6778) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 1, 15, 14, 19, 372, DateTimeKind.Local).AddTicks(7660), new DateTime(2022, 10, 1, 15, 14, 19, 372, DateTimeKind.Local).AddTicks(7663) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 1, 15, 14, 19, 372, DateTimeKind.Local).AddTicks(7667), new DateTime(2022, 10, 1, 15, 14, 19, 372, DateTimeKind.Local).AddTicks(7669) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 1, 15, 14, 19, 372, DateTimeKind.Local).AddTicks(7654), new DateTime(2022, 10, 1, 15, 14, 19, 372, DateTimeKind.Local).AddTicks(7656) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 1, 15, 14, 19, 376, DateTimeKind.Local).AddTicks(2632), new DateTime(2022, 10, 1, 15, 14, 19, 376, DateTimeKind.Local).AddTicks(2634) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 1, 15, 14, 19, 376, DateTimeKind.Local).AddTicks(2626), new DateTime(2022, 10, 1, 15, 14, 19, 376, DateTimeKind.Local).AddTicks(2627) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 1, 15, 14, 19, 376, DateTimeKind.Local).AddTicks(2619), new DateTime(2022, 10, 1, 15, 14, 19, 376, DateTimeKind.Local).AddTicks(2621) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 1, 15, 14, 19, 376, DateTimeKind.Local).AddTicks(1664), new DateTime(2022, 10, 1, 15, 14, 19, 376, DateTimeKind.Local).AddTicks(1676) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 1, 15, 14, 19, 376, DateTimeKind.Local).AddTicks(2587), new DateTime(2022, 10, 1, 15, 14, 19, 376, DateTimeKind.Local).AddTicks(2593) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 1, 15, 14, 19, 374, DateTimeKind.Local).AddTicks(6139), new DateTime(2022, 10, 1, 15, 14, 19, 374, DateTimeKind.Local).AddTicks(6151) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 1, 15, 14, 19, 368, DateTimeKind.Local).AddTicks(1467), new DateTime(2022, 10, 1, 15, 14, 19, 368, DateTimeKind.Local).AddTicks(8707) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 1, 15, 14, 19, 368, DateTimeKind.Local).AddTicks(9956), new DateTime(2022, 10, 1, 15, 14, 19, 368, DateTimeKind.Local).AddTicks(9973) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 10, 1, 15, 14, 19, 369, DateTimeKind.Local).AddTicks(8), new DateTime(2022, 10, 1, 15, 14, 19, 369, DateTimeKind.Local).AddTicks(11) });
        }
    }
}
