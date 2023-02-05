using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateImplementationsTask51ImplementarGeracaoDeOficioParteI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Setor",
                table: "SequenciasOficios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "SequenciasOficios",
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
                values: new object[] { new DateTime(2022, 7, 22, 19, 26, 30, 625, DateTimeKind.Local).AddTicks(4529), new DateTime(2022, 7, 22, 19, 26, 30, 625, DateTimeKind.Local).AddTicks(4543) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 22, 19, 26, 30, 628, DateTimeKind.Local).AddTicks(5939), new DateTime(2022, 7, 22, 19, 26, 30, 628, DateTimeKind.Local).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 22, 19, 26, 30, 628, DateTimeKind.Local).AddTicks(4932), new DateTime(2022, 7, 22, 19, 26, 30, 628, DateTimeKind.Local).AddTicks(4966) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 22, 19, 26, 30, 628, DateTimeKind.Local).AddTicks(5984), new DateTime(2022, 7, 22, 19, 26, 30, 628, DateTimeKind.Local).AddTicks(5986) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 22, 19, 26, 30, 628, DateTimeKind.Local).AddTicks(5991), new DateTime(2022, 7, 22, 19, 26, 30, 628, DateTimeKind.Local).AddTicks(5993) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 22, 19, 26, 30, 628, DateTimeKind.Local).AddTicks(5976), new DateTime(2022, 7, 22, 19, 26, 30, 628, DateTimeKind.Local).AddTicks(5979) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 22, 19, 26, 30, 633, DateTimeKind.Local).AddTicks(3075), new DateTime(2022, 7, 22, 19, 26, 30, 633, DateTimeKind.Local).AddTicks(3077) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 22, 19, 26, 30, 633, DateTimeKind.Local).AddTicks(3069), new DateTime(2022, 7, 22, 19, 26, 30, 633, DateTimeKind.Local).AddTicks(3071) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 22, 19, 26, 30, 633, DateTimeKind.Local).AddTicks(3059), new DateTime(2022, 7, 22, 19, 26, 30, 633, DateTimeKind.Local).AddTicks(3062) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 22, 19, 26, 30, 633, DateTimeKind.Local).AddTicks(2035), new DateTime(2022, 7, 22, 19, 26, 30, 633, DateTimeKind.Local).AddTicks(2063) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 22, 19, 26, 30, 633, DateTimeKind.Local).AddTicks(2980), new DateTime(2022, 7, 22, 19, 26, 30, 633, DateTimeKind.Local).AddTicks(2987) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 22, 19, 26, 30, 630, DateTimeKind.Local).AddTicks(3932), new DateTime(2022, 7, 22, 19, 26, 30, 630, DateTimeKind.Local).AddTicks(3967) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 22, 19, 26, 30, 622, DateTimeKind.Local).AddTicks(4752), new DateTime(2022, 7, 22, 19, 26, 30, 623, DateTimeKind.Local).AddTicks(5051) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 22, 19, 26, 30, 623, DateTimeKind.Local).AddTicks(7255), new DateTime(2022, 7, 22, 19, 26, 30, 623, DateTimeKind.Local).AddTicks(7272) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 22, 19, 26, 30, 623, DateTimeKind.Local).AddTicks(7310), new DateTime(2022, 7, 22, 19, 26, 30, 623, DateTimeKind.Local).AddTicks(7312) });

            migrationBuilder.CreateIndex(
                name: "IX_SequenciasOficios_TenantId",
                table: "SequenciasOficios",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_SequenciasOficios_Tenants_TenantId",
                table: "SequenciasOficios",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SequenciasOficios_Tenants_TenantId",
                table: "SequenciasOficios");

            migrationBuilder.DropIndex(
                name: "IX_SequenciasOficios_TenantId",
                table: "SequenciasOficios");

            migrationBuilder.DropColumn(
                name: "Setor",
                table: "SequenciasOficios");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SequenciasOficios");

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
                values: new object[] { new DateTime(2022, 7, 20, 19, 4, 50, 612, DateTimeKind.Local).AddTicks(6820), new DateTime(2022, 7, 20, 19, 4, 50, 612, DateTimeKind.Local).AddTicks(6832) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 19, 4, 50, 614, DateTimeKind.Local).AddTicks(4122), new DateTime(2022, 7, 20, 19, 4, 50, 614, DateTimeKind.Local).AddTicks(4128) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 19, 4, 50, 614, DateTimeKind.Local).AddTicks(3235), new DateTime(2022, 7, 20, 19, 4, 50, 614, DateTimeKind.Local).AddTicks(3247) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 19, 4, 50, 614, DateTimeKind.Local).AddTicks(4162), new DateTime(2022, 7, 20, 19, 4, 50, 614, DateTimeKind.Local).AddTicks(4164) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 19, 4, 50, 614, DateTimeKind.Local).AddTicks(4168), new DateTime(2022, 7, 20, 19, 4, 50, 614, DateTimeKind.Local).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 19, 4, 50, 614, DateTimeKind.Local).AddTicks(4156), new DateTime(2022, 7, 20, 19, 4, 50, 614, DateTimeKind.Local).AddTicks(4158) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 19, 4, 50, 617, DateTimeKind.Local).AddTicks(5022), new DateTime(2022, 7, 20, 19, 4, 50, 617, DateTimeKind.Local).AddTicks(5024) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 19, 4, 50, 617, DateTimeKind.Local).AddTicks(5016), new DateTime(2022, 7, 20, 19, 4, 50, 617, DateTimeKind.Local).AddTicks(5018) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 19, 4, 50, 617, DateTimeKind.Local).AddTicks(5009), new DateTime(2022, 7, 20, 19, 4, 50, 617, DateTimeKind.Local).AddTicks(5011) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 19, 4, 50, 617, DateTimeKind.Local).AddTicks(4112), new DateTime(2022, 7, 20, 19, 4, 50, 617, DateTimeKind.Local).AddTicks(4125) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 19, 4, 50, 617, DateTimeKind.Local).AddTicks(4978), new DateTime(2022, 7, 20, 19, 4, 50, 617, DateTimeKind.Local).AddTicks(4983) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 19, 4, 50, 615, DateTimeKind.Local).AddTicks(7887), new DateTime(2022, 7, 20, 19, 4, 50, 615, DateTimeKind.Local).AddTicks(7899) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 19, 4, 50, 610, DateTimeKind.Local).AddTicks(3260), new DateTime(2022, 7, 20, 19, 4, 50, 611, DateTimeKind.Local).AddTicks(1003) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 19, 4, 50, 611, DateTimeKind.Local).AddTicks(2268), new DateTime(2022, 7, 20, 19, 4, 50, 611, DateTimeKind.Local).AddTicks(2289) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 19, 4, 50, 611, DateTimeKind.Local).AddTicks(2325), new DateTime(2022, 7, 20, 19, 4, 50, 611, DateTimeKind.Local).AddTicks(2328) });
        }
    }
}
