using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesToMultitenancyDicasEPerguntas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "FormularioLeituraPerguntasGrupos",
                nullable: false,
                defaultValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "FormularioLeituraDicasEscrita",
                nullable: false,
                defaultValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

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

            migrationBuilder.CreateIndex(
                name: "IX_FormularioLeituraPerguntasGrupos_TenantId",
                table: "FormularioLeituraPerguntasGrupos",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioLeituraDicasEscrita_TenantId",
                table: "FormularioLeituraDicasEscrita",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormularioLeituraDicasEscrita_Tenants_TenantId",
                table: "FormularioLeituraDicasEscrita",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FormularioLeituraPerguntasGrupos_Tenants_TenantId",
                table: "FormularioLeituraPerguntasGrupos",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormularioLeituraDicasEscrita_Tenants_TenantId",
                table: "FormularioLeituraDicasEscrita");

            migrationBuilder.DropForeignKey(
                name: "FK_FormularioLeituraPerguntasGrupos_Tenants_TenantId",
                table: "FormularioLeituraPerguntasGrupos");

            migrationBuilder.DropIndex(
                name: "IX_FormularioLeituraPerguntasGrupos_TenantId",
                table: "FormularioLeituraPerguntasGrupos");

            migrationBuilder.DropIndex(
                name: "IX_FormularioLeituraDicasEscrita_TenantId",
                table: "FormularioLeituraDicasEscrita");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "FormularioLeituraPerguntasGrupos");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "FormularioLeituraDicasEscrita");

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
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 11, DateTimeKind.Local).AddTicks(7360), new DateTime(2022, 9, 25, 14, 10, 29, 11, DateTimeKind.Local).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(540), new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(560) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 13, DateTimeKind.Local).AddTicks(9018), new DateTime(2022, 9, 25, 14, 10, 29, 13, DateTimeKind.Local).AddTicks(9050) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(607), new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(610) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(616), new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(618) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(599), new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(602) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7714), new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7716) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7708), new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7710) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7700), new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7703) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(6653), new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(6680) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7657), new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7670) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 15, DateTimeKind.Local).AddTicks(7644), new DateTime(2022, 9, 25, 14, 10, 29, 15, DateTimeKind.Local).AddTicks(7674) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 8, DateTimeKind.Local).AddTicks(6587), new DateTime(2022, 9, 25, 14, 10, 29, 9, DateTimeKind.Local).AddTicks(4959) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 9, DateTimeKind.Local).AddTicks(6315), new DateTime(2022, 9, 25, 14, 10, 29, 9, DateTimeKind.Local).AddTicks(6334) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 9, DateTimeKind.Local).AddTicks(6372), new DateTime(2022, 9, 25, 14, 10, 29, 9, DateTimeKind.Local).AddTicks(6374) });
        }
    }
}
