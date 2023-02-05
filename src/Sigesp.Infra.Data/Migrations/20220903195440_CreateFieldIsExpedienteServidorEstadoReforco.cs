using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateFieldIsExpedienteServidorEstadoReforco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExpediente",
                table: "ServidoresEstadoReforcos",
                nullable: false,
                defaultValue: false);

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
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 517, DateTimeKind.Local).AddTicks(7429), new DateTime(2022, 9, 3, 16, 54, 39, 517, DateTimeKind.Local).AddTicks(7445) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6100), new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6107) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(5180), new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(5196) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6144), new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6146) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6151), new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6152) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6137), new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6139) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2184), new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2187) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2178), new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2171), new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2173) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(1211), new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(1232) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2138), new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2144) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 521, DateTimeKind.Local).AddTicks(3238), new DateTime(2022, 9, 3, 16, 54, 39, 521, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 515, DateTimeKind.Local).AddTicks(1681), new DateTime(2022, 9, 3, 16, 54, 39, 515, DateTimeKind.Local).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 516, DateTimeKind.Local).AddTicks(1002), new DateTime(2022, 9, 3, 16, 54, 39, 516, DateTimeKind.Local).AddTicks(1020) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 516, DateTimeKind.Local).AddTicks(1060), new DateTime(2022, 9, 3, 16, 54, 39, 516, DateTimeKind.Local).AddTicks(1062) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExpediente",
                table: "ServidoresEstadoReforcos");

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
                values: new object[] { new DateTime(2022, 9, 1, 19, 51, 31, 399, DateTimeKind.Local).AddTicks(3128), new DateTime(2022, 9, 1, 19, 51, 31, 399, DateTimeKind.Local).AddTicks(3158) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 1, 19, 51, 31, 401, DateTimeKind.Local).AddTicks(2825), new DateTime(2022, 9, 1, 19, 51, 31, 401, DateTimeKind.Local).AddTicks(2831) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 1, 19, 51, 31, 401, DateTimeKind.Local).AddTicks(1903), new DateTime(2022, 9, 1, 19, 51, 31, 401, DateTimeKind.Local).AddTicks(1923) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 1, 19, 51, 31, 401, DateTimeKind.Local).AddTicks(2865), new DateTime(2022, 9, 1, 19, 51, 31, 401, DateTimeKind.Local).AddTicks(2867) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 1, 19, 51, 31, 401, DateTimeKind.Local).AddTicks(2871), new DateTime(2022, 9, 1, 19, 51, 31, 401, DateTimeKind.Local).AddTicks(2873) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 1, 19, 51, 31, 401, DateTimeKind.Local).AddTicks(2858), new DateTime(2022, 9, 1, 19, 51, 31, 401, DateTimeKind.Local).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 1, 19, 51, 31, 405, DateTimeKind.Local).AddTicks(6525), new DateTime(2022, 9, 1, 19, 51, 31, 405, DateTimeKind.Local).AddTicks(6527) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 1, 19, 51, 31, 405, DateTimeKind.Local).AddTicks(6518), new DateTime(2022, 9, 1, 19, 51, 31, 405, DateTimeKind.Local).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 1, 19, 51, 31, 405, DateTimeKind.Local).AddTicks(6510), new DateTime(2022, 9, 1, 19, 51, 31, 405, DateTimeKind.Local).AddTicks(6513) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 1, 19, 51, 31, 405, DateTimeKind.Local).AddTicks(5497), new DateTime(2022, 9, 1, 19, 51, 31, 405, DateTimeKind.Local).AddTicks(5528) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 1, 19, 51, 31, 405, DateTimeKind.Local).AddTicks(6455), new DateTime(2022, 9, 1, 19, 51, 31, 405, DateTimeKind.Local).AddTicks(6461) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 1, 19, 51, 31, 403, DateTimeKind.Local).AddTicks(472), new DateTime(2022, 9, 1, 19, 51, 31, 403, DateTimeKind.Local).AddTicks(511) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 1, 19, 51, 31, 396, DateTimeKind.Local).AddTicks(4712), new DateTime(2022, 9, 1, 19, 51, 31, 397, DateTimeKind.Local).AddTicks(2452) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 1, 19, 51, 31, 397, DateTimeKind.Local).AddTicks(3710), new DateTime(2022, 9, 1, 19, 51, 31, 397, DateTimeKind.Local).AddTicks(3731) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 1, 19, 51, 31, 397, DateTimeKind.Local).AddTicks(3770), new DateTime(2022, 9, 1, 19, 51, 31, 397, DateTimeKind.Local).AddTicks(3772) });
        }
    }
}
