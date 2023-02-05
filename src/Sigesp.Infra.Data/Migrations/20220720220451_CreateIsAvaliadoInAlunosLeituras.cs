using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateIsAvaliadoInAlunosLeituras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Detentos_MatriculaFamiliar",
                table: "Detentos");

            migrationBuilder.AlterColumn<int>(
                name: "Cep",
                table: "Detentos",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvaliado",
                table: "AlunosLeituras",
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

            migrationBuilder.CreateIndex(
                name: "IX_Detentos_MatriculaFamiliar",
                table: "Detentos",
                column: "MatriculaFamiliar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Detentos_MatriculaFamiliar",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "IsAvaliado",
                table: "AlunosLeituras");

            migrationBuilder.AlterColumn<int>(
                name: "Cep",
                table: "Detentos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

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
                values: new object[] { new DateTime(2022, 7, 16, 11, 8, 36, 572, DateTimeKind.Local).AddTicks(6455), new DateTime(2022, 7, 16, 11, 8, 36, 572, DateTimeKind.Local).AddTicks(6479) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 11, 8, 36, 574, DateTimeKind.Local).AddTicks(4610), new DateTime(2022, 7, 16, 11, 8, 36, 574, DateTimeKind.Local).AddTicks(4617) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 11, 8, 36, 574, DateTimeKind.Local).AddTicks(3706), new DateTime(2022, 7, 16, 11, 8, 36, 574, DateTimeKind.Local).AddTicks(3721) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 11, 8, 36, 574, DateTimeKind.Local).AddTicks(4651), new DateTime(2022, 7, 16, 11, 8, 36, 574, DateTimeKind.Local).AddTicks(4653) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 11, 8, 36, 574, DateTimeKind.Local).AddTicks(4656), new DateTime(2022, 7, 16, 11, 8, 36, 574, DateTimeKind.Local).AddTicks(4658) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 11, 8, 36, 574, DateTimeKind.Local).AddTicks(4644), new DateTime(2022, 7, 16, 11, 8, 36, 574, DateTimeKind.Local).AddTicks(4646) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 11, 8, 36, 577, DateTimeKind.Local).AddTicks(5181), new DateTime(2022, 7, 16, 11, 8, 36, 577, DateTimeKind.Local).AddTicks(5183) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 11, 8, 36, 577, DateTimeKind.Local).AddTicks(5175), new DateTime(2022, 7, 16, 11, 8, 36, 577, DateTimeKind.Local).AddTicks(5177) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 11, 8, 36, 577, DateTimeKind.Local).AddTicks(5167), new DateTime(2022, 7, 16, 11, 8, 36, 577, DateTimeKind.Local).AddTicks(5170) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 11, 8, 36, 577, DateTimeKind.Local).AddTicks(4249), new DateTime(2022, 7, 16, 11, 8, 36, 577, DateTimeKind.Local).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 11, 8, 36, 577, DateTimeKind.Local).AddTicks(5139), new DateTime(2022, 7, 16, 11, 8, 36, 577, DateTimeKind.Local).AddTicks(5144) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 11, 8, 36, 575, DateTimeKind.Local).AddTicks(8164), new DateTime(2022, 7, 16, 11, 8, 36, 575, DateTimeKind.Local).AddTicks(8174) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 11, 8, 36, 570, DateTimeKind.Local).AddTicks(218), new DateTime(2022, 7, 16, 11, 8, 36, 570, DateTimeKind.Local).AddTicks(8069) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 11, 8, 36, 570, DateTimeKind.Local).AddTicks(9388), new DateTime(2022, 7, 16, 11, 8, 36, 570, DateTimeKind.Local).AddTicks(9407) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 11, 8, 36, 570, DateTimeKind.Local).AddTicks(9446), new DateTime(2022, 7, 16, 11, 8, 36, 570, DateTimeKind.Local).AddTicks(9449) });

            migrationBuilder.CreateIndex(
                name: "IX_Detentos_MatriculaFamiliar",
                table: "Detentos",
                column: "MatriculaFamiliar",
                unique: true);
        }
    }
}
