using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateTemaAtualFieldInContaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TemaAtual",
                table: "ContaUsuarios",
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
                values: new object[] { new DateTime(2022, 9, 25, 9, 55, 57, 853, DateTimeKind.Local).AddTicks(1991), new DateTime(2022, 9, 25, 9, 55, 57, 853, DateTimeKind.Local).AddTicks(2017) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 55, 57, 855, DateTimeKind.Local).AddTicks(4644), new DateTime(2022, 9, 25, 9, 55, 57, 855, DateTimeKind.Local).AddTicks(4662) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 55, 57, 855, DateTimeKind.Local).AddTicks(2706), new DateTime(2022, 9, 25, 9, 55, 57, 855, DateTimeKind.Local).AddTicks(2735) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 55, 57, 855, DateTimeKind.Local).AddTicks(4700), new DateTime(2022, 9, 25, 9, 55, 57, 855, DateTimeKind.Local).AddTicks(4702) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 55, 57, 855, DateTimeKind.Local).AddTicks(4706), new DateTime(2022, 9, 25, 9, 55, 57, 855, DateTimeKind.Local).AddTicks(4708) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 55, 57, 855, DateTimeKind.Local).AddTicks(4692), new DateTime(2022, 9, 25, 9, 55, 57, 855, DateTimeKind.Local).AddTicks(4694) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 55, 57, 859, DateTimeKind.Local).AddTicks(5024), new DateTime(2022, 9, 25, 9, 55, 57, 859, DateTimeKind.Local).AddTicks(5026) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 55, 57, 859, DateTimeKind.Local).AddTicks(5009), new DateTime(2022, 9, 25, 9, 55, 57, 859, DateTimeKind.Local).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 55, 57, 859, DateTimeKind.Local).AddTicks(5002), new DateTime(2022, 9, 25, 9, 55, 57, 859, DateTimeKind.Local).AddTicks(5004) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 55, 57, 859, DateTimeKind.Local).AddTicks(3987), new DateTime(2022, 9, 25, 9, 55, 57, 859, DateTimeKind.Local).AddTicks(4034) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 55, 57, 859, DateTimeKind.Local).AddTicks(4963), new DateTime(2022, 9, 25, 9, 55, 57, 859, DateTimeKind.Local).AddTicks(4970) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 55, 57, 857, DateTimeKind.Local).AddTicks(530), new DateTime(2022, 9, 25, 9, 55, 57, 857, DateTimeKind.Local).AddTicks(551) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 55, 57, 849, DateTimeKind.Local).AddTicks(8507), new DateTime(2022, 9, 25, 9, 55, 57, 851, DateTimeKind.Local).AddTicks(1871) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 55, 57, 851, DateTimeKind.Local).AddTicks(3335), new DateTime(2022, 9, 25, 9, 55, 57, 851, DateTimeKind.Local).AddTicks(3356) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 55, 57, 851, DateTimeKind.Local).AddTicks(3389), new DateTime(2022, 9, 25, 9, 55, 57, 851, DateTimeKind.Local).AddTicks(3391) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemaAtual",
                table: "ContaUsuarios");

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
                values: new object[] { new DateTime(2022, 9, 18, 16, 46, 10, 295, DateTimeKind.Local).AddTicks(2888), new DateTime(2022, 9, 18, 16, 46, 10, 295, DateTimeKind.Local).AddTicks(2910) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 46, 10, 297, DateTimeKind.Local).AddTicks(8291), new DateTime(2022, 9, 18, 16, 46, 10, 297, DateTimeKind.Local).AddTicks(8309) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 46, 10, 297, DateTimeKind.Local).AddTicks(6666), new DateTime(2022, 9, 18, 16, 46, 10, 297, DateTimeKind.Local).AddTicks(6706) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 46, 10, 297, DateTimeKind.Local).AddTicks(8344), new DateTime(2022, 9, 18, 16, 46, 10, 297, DateTimeKind.Local).AddTicks(8346) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 46, 10, 297, DateTimeKind.Local).AddTicks(8351), new DateTime(2022, 9, 18, 16, 46, 10, 297, DateTimeKind.Local).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 46, 10, 297, DateTimeKind.Local).AddTicks(8337), new DateTime(2022, 9, 18, 16, 46, 10, 297, DateTimeKind.Local).AddTicks(8339) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 46, 10, 301, DateTimeKind.Local).AddTicks(7775), new DateTime(2022, 9, 18, 16, 46, 10, 301, DateTimeKind.Local).AddTicks(7777) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 46, 10, 301, DateTimeKind.Local).AddTicks(7767), new DateTime(2022, 9, 18, 16, 46, 10, 301, DateTimeKind.Local).AddTicks(7769) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 46, 10, 301, DateTimeKind.Local).AddTicks(7760), new DateTime(2022, 9, 18, 16, 46, 10, 301, DateTimeKind.Local).AddTicks(7762) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 46, 10, 301, DateTimeKind.Local).AddTicks(6757), new DateTime(2022, 9, 18, 16, 46, 10, 301, DateTimeKind.Local).AddTicks(6779) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 46, 10, 301, DateTimeKind.Local).AddTicks(7726), new DateTime(2022, 9, 18, 16, 46, 10, 301, DateTimeKind.Local).AddTicks(7732) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 46, 10, 299, DateTimeKind.Local).AddTicks(8861), new DateTime(2022, 9, 18, 16, 46, 10, 299, DateTimeKind.Local).AddTicks(8889) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 46, 10, 292, DateTimeKind.Local).AddTicks(6086), new DateTime(2022, 9, 18, 16, 46, 10, 293, DateTimeKind.Local).AddTicks(3808) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 46, 10, 293, DateTimeKind.Local).AddTicks(5115), new DateTime(2022, 9, 18, 16, 46, 10, 293, DateTimeKind.Local).AddTicks(5134) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 46, 10, 293, DateTimeKind.Local).AddTicks(5172), new DateTime(2022, 9, 18, 16, 46, 10, 293, DateTimeKind.Local).AddTicks(5175) });
        }
    }
}
