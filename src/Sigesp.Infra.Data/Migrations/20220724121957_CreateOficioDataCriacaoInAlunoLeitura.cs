using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateOficioDataCriacaoInAlunoLeitura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OficioDataCriacao",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                values: new object[] { new DateTime(2022, 7, 24, 9, 19, 56, 872, DateTimeKind.Local).AddTicks(9155), new DateTime(2022, 7, 24, 9, 19, 56, 872, DateTimeKind.Local).AddTicks(9167) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 19, 56, 874, DateTimeKind.Local).AddTicks(6654), new DateTime(2022, 7, 24, 9, 19, 56, 874, DateTimeKind.Local).AddTicks(6660) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 19, 56, 874, DateTimeKind.Local).AddTicks(5788), new DateTime(2022, 7, 24, 9, 19, 56, 874, DateTimeKind.Local).AddTicks(5800) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 19, 56, 874, DateTimeKind.Local).AddTicks(6692), new DateTime(2022, 7, 24, 9, 19, 56, 874, DateTimeKind.Local).AddTicks(6694) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 19, 56, 874, DateTimeKind.Local).AddTicks(6698), new DateTime(2022, 7, 24, 9, 19, 56, 874, DateTimeKind.Local).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 19, 56, 874, DateTimeKind.Local).AddTicks(6685), new DateTime(2022, 7, 24, 9, 19, 56, 874, DateTimeKind.Local).AddTicks(6687) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 19, 56, 877, DateTimeKind.Local).AddTicks(7520), new DateTime(2022, 7, 24, 9, 19, 56, 877, DateTimeKind.Local).AddTicks(7522) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 19, 56, 877, DateTimeKind.Local).AddTicks(7514), new DateTime(2022, 7, 24, 9, 19, 56, 877, DateTimeKind.Local).AddTicks(7516) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 19, 56, 877, DateTimeKind.Local).AddTicks(7507), new DateTime(2022, 7, 24, 9, 19, 56, 877, DateTimeKind.Local).AddTicks(7509) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 19, 56, 877, DateTimeKind.Local).AddTicks(6602), new DateTime(2022, 7, 24, 9, 19, 56, 877, DateTimeKind.Local).AddTicks(6615) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 19, 56, 877, DateTimeKind.Local).AddTicks(7469), new DateTime(2022, 7, 24, 9, 19, 56, 877, DateTimeKind.Local).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 19, 56, 876, DateTimeKind.Local).AddTicks(607), new DateTime(2022, 7, 24, 9, 19, 56, 876, DateTimeKind.Local).AddTicks(620) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 19, 56, 870, DateTimeKind.Local).AddTicks(5173), new DateTime(2022, 7, 24, 9, 19, 56, 871, DateTimeKind.Local).AddTicks(2972) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 19, 56, 871, DateTimeKind.Local).AddTicks(4248), new DateTime(2022, 7, 24, 9, 19, 56, 871, DateTimeKind.Local).AddTicks(4269) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 19, 56, 871, DateTimeKind.Local).AddTicks(4305), new DateTime(2022, 7, 24, 9, 19, 56, 871, DateTimeKind.Local).AddTicks(4307) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OficioDataCriacao",
                table: "AlunosLeituras");

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
                values: new object[] { new DateTime(2022, 7, 24, 9, 14, 9, 518, DateTimeKind.Local).AddTicks(2176), new DateTime(2022, 7, 24, 9, 14, 9, 518, DateTimeKind.Local).AddTicks(2217) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 14, 9, 520, DateTimeKind.Local).AddTicks(4740), new DateTime(2022, 7, 24, 9, 14, 9, 520, DateTimeKind.Local).AddTicks(4746) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 14, 9, 520, DateTimeKind.Local).AddTicks(3747), new DateTime(2022, 7, 24, 9, 14, 9, 520, DateTimeKind.Local).AddTicks(3775) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 14, 9, 520, DateTimeKind.Local).AddTicks(4780), new DateTime(2022, 7, 24, 9, 14, 9, 520, DateTimeKind.Local).AddTicks(4781) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 14, 9, 520, DateTimeKind.Local).AddTicks(4786), new DateTime(2022, 7, 24, 9, 14, 9, 520, DateTimeKind.Local).AddTicks(4788) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 14, 9, 520, DateTimeKind.Local).AddTicks(4772), new DateTime(2022, 7, 24, 9, 14, 9, 520, DateTimeKind.Local).AddTicks(4774) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 14, 9, 524, DateTimeKind.Local).AddTicks(3088), new DateTime(2022, 7, 24, 9, 14, 9, 524, DateTimeKind.Local).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 14, 9, 524, DateTimeKind.Local).AddTicks(3081), new DateTime(2022, 7, 24, 9, 14, 9, 524, DateTimeKind.Local).AddTicks(3084) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 14, 9, 524, DateTimeKind.Local).AddTicks(3074), new DateTime(2022, 7, 24, 9, 14, 9, 524, DateTimeKind.Local).AddTicks(3077) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 14, 9, 524, DateTimeKind.Local).AddTicks(2036), new DateTime(2022, 7, 24, 9, 14, 9, 524, DateTimeKind.Local).AddTicks(2066) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 14, 9, 524, DateTimeKind.Local).AddTicks(3040), new DateTime(2022, 7, 24, 9, 14, 9, 524, DateTimeKind.Local).AddTicks(3046) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 14, 9, 522, DateTimeKind.Local).AddTicks(1992), new DateTime(2022, 7, 24, 9, 14, 9, 522, DateTimeKind.Local).AddTicks(2027) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 14, 9, 515, DateTimeKind.Local).AddTicks(969), new DateTime(2022, 7, 24, 9, 14, 9, 516, DateTimeKind.Local).AddTicks(1433) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 14, 9, 516, DateTimeKind.Local).AddTicks(2809), new DateTime(2022, 7, 24, 9, 14, 9, 516, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 24, 9, 14, 9, 516, DateTimeKind.Local).AddTicks(2867), new DateTime(2022, 7, 24, 9, 14, 9, 516, DateTimeKind.Local).AddTicks(2869) });
        }
    }
}
