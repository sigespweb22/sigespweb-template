using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesInProfessorMapApplicationUserIdIsRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Professores",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
                values: new object[] { new DateTime(2022, 6, 28, 16, 25, 58, 397, DateTimeKind.Local).AddTicks(1768), new DateTime(2022, 6, 28, 16, 25, 58, 397, DateTimeKind.Local).AddTicks(1780) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 16, 25, 58, 398, DateTimeKind.Local).AddTicks(9257), new DateTime(2022, 6, 28, 16, 25, 58, 398, DateTimeKind.Local).AddTicks(9263) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 16, 25, 58, 398, DateTimeKind.Local).AddTicks(8380), new DateTime(2022, 6, 28, 16, 25, 58, 398, DateTimeKind.Local).AddTicks(8392) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 16, 25, 58, 398, DateTimeKind.Local).AddTicks(9308), new DateTime(2022, 6, 28, 16, 25, 58, 398, DateTimeKind.Local).AddTicks(9309) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 16, 25, 58, 398, DateTimeKind.Local).AddTicks(9314), new DateTime(2022, 6, 28, 16, 25, 58, 398, DateTimeKind.Local).AddTicks(9316) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 16, 25, 58, 398, DateTimeKind.Local).AddTicks(9300), new DateTime(2022, 6, 28, 16, 25, 58, 398, DateTimeKind.Local).AddTicks(9303) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 16, 25, 58, 401, DateTimeKind.Local).AddTicks(9704), new DateTime(2022, 6, 28, 16, 25, 58, 401, DateTimeKind.Local).AddTicks(9706) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 16, 25, 58, 401, DateTimeKind.Local).AddTicks(9697), new DateTime(2022, 6, 28, 16, 25, 58, 401, DateTimeKind.Local).AddTicks(9699) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 16, 25, 58, 401, DateTimeKind.Local).AddTicks(9690), new DateTime(2022, 6, 28, 16, 25, 58, 401, DateTimeKind.Local).AddTicks(9692) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 16, 25, 58, 401, DateTimeKind.Local).AddTicks(8786), new DateTime(2022, 6, 28, 16, 25, 58, 401, DateTimeKind.Local).AddTicks(8801) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 16, 25, 58, 401, DateTimeKind.Local).AddTicks(9657), new DateTime(2022, 6, 28, 16, 25, 58, 401, DateTimeKind.Local).AddTicks(9663) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 16, 25, 58, 400, DateTimeKind.Local).AddTicks(2628), new DateTime(2022, 6, 28, 16, 25, 58, 400, DateTimeKind.Local).AddTicks(2638) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 16, 25, 58, 394, DateTimeKind.Local).AddTicks(8550), new DateTime(2022, 6, 28, 16, 25, 58, 395, DateTimeKind.Local).AddTicks(6108) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 16, 25, 58, 395, DateTimeKind.Local).AddTicks(7184), new DateTime(2022, 6, 28, 16, 25, 58, 395, DateTimeKind.Local).AddTicks(7205) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 16, 25, 58, 395, DateTimeKind.Local).AddTicks(7252), new DateTime(2022, 6, 28, 16, 25, 58, 395, DateTimeKind.Local).AddTicks(7255) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Professores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

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
                values: new object[] { new DateTime(2022, 6, 28, 15, 57, 17, 357, DateTimeKind.Local).AddTicks(9384), new DateTime(2022, 6, 28, 15, 57, 17, 357, DateTimeKind.Local).AddTicks(9396) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 15, 57, 17, 359, DateTimeKind.Local).AddTicks(6877), new DateTime(2022, 6, 28, 15, 57, 17, 359, DateTimeKind.Local).AddTicks(6884) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 15, 57, 17, 359, DateTimeKind.Local).AddTicks(5936), new DateTime(2022, 6, 28, 15, 57, 17, 359, DateTimeKind.Local).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 15, 57, 17, 359, DateTimeKind.Local).AddTicks(6927), new DateTime(2022, 6, 28, 15, 57, 17, 359, DateTimeKind.Local).AddTicks(6929) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 15, 57, 17, 359, DateTimeKind.Local).AddTicks(6933), new DateTime(2022, 6, 28, 15, 57, 17, 359, DateTimeKind.Local).AddTicks(6935) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 15, 57, 17, 359, DateTimeKind.Local).AddTicks(6919), new DateTime(2022, 6, 28, 15, 57, 17, 359, DateTimeKind.Local).AddTicks(6921) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 15, 57, 17, 362, DateTimeKind.Local).AddTicks(7089), new DateTime(2022, 6, 28, 15, 57, 17, 362, DateTimeKind.Local).AddTicks(7091) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 15, 57, 17, 362, DateTimeKind.Local).AddTicks(7083), new DateTime(2022, 6, 28, 15, 57, 17, 362, DateTimeKind.Local).AddTicks(7085) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 15, 57, 17, 362, DateTimeKind.Local).AddTicks(7076), new DateTime(2022, 6, 28, 15, 57, 17, 362, DateTimeKind.Local).AddTicks(7078) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 15, 57, 17, 362, DateTimeKind.Local).AddTicks(6075), new DateTime(2022, 6, 28, 15, 57, 17, 362, DateTimeKind.Local).AddTicks(6087) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 15, 57, 17, 362, DateTimeKind.Local).AddTicks(7043), new DateTime(2022, 6, 28, 15, 57, 17, 362, DateTimeKind.Local).AddTicks(7050) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 15, 57, 17, 361, DateTimeKind.Local).AddTicks(243), new DateTime(2022, 6, 28, 15, 57, 17, 361, DateTimeKind.Local).AddTicks(254) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 15, 57, 17, 355, DateTimeKind.Local).AddTicks(5983), new DateTime(2022, 6, 28, 15, 57, 17, 356, DateTimeKind.Local).AddTicks(3569) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 15, 57, 17, 356, DateTimeKind.Local).AddTicks(4628), new DateTime(2022, 6, 28, 15, 57, 17, 356, DateTimeKind.Local).AddTicks(4647) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 15, 57, 17, 356, DateTimeKind.Local).AddTicks(4678), new DateTime(2022, 6, 28, 15, 57, 17, 356, DateTimeKind.Local).AddTicks(4681) });
        }
    }
}
