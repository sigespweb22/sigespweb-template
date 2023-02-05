﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateFieldsNewsInTenantParteII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OficioLeituraVocativo",
                table: "Tenants");

            migrationBuilder.AddColumn<string>(
                name: "OficioLeituraVocativo1",
                table: "Tenants",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OficioLeituraVocativo2",
                table: "Tenants",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OficioLeituraVocativo3",
                table: "Tenants",
                maxLength: 500,
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
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 939, DateTimeKind.Local).AddTicks(5945), new DateTime(2022, 7, 27, 19, 31, 42, 939, DateTimeKind.Local).AddTicks(5958) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4163), new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4169) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(3255), new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(3267) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4204), new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4205) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4210), new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4212) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4197), new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4199) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5708), new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5710) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5702), new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5704) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5696), new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5698) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(4804), new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(4818) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5657), new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5663) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 942, DateTimeKind.Local).AddTicks(7365), new DateTime(2022, 7, 27, 19, 31, 42, 942, DateTimeKind.Local).AddTicks(7375) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 937, DateTimeKind.Local).AddTicks(2300), new DateTime(2022, 7, 27, 19, 31, 42, 937, DateTimeKind.Local).AddTicks(9965) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 938, DateTimeKind.Local).AddTicks(1244), new DateTime(2022, 7, 27, 19, 31, 42, 938, DateTimeKind.Local).AddTicks(1263) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 938, DateTimeKind.Local).AddTicks(1301), new DateTime(2022, 7, 27, 19, 31, 42, 938, DateTimeKind.Local).AddTicks(1303) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OficioLeituraVocativo1",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "OficioLeituraVocativo2",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "OficioLeituraVocativo3",
                table: "Tenants");

            migrationBuilder.AddColumn<string>(
                name: "OficioLeituraVocativo",
                table: "Tenants",
                type: "character varying(500)",
                maxLength: 500,
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
                values: new object[] { new DateTime(2022, 7, 27, 19, 1, 30, 56, DateTimeKind.Local).AddTicks(9844), new DateTime(2022, 7, 27, 19, 1, 30, 56, DateTimeKind.Local).AddTicks(9857) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 1, 30, 62, DateTimeKind.Local).AddTicks(1852), new DateTime(2022, 7, 27, 19, 1, 30, 62, DateTimeKind.Local).AddTicks(1877) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 1, 30, 61, DateTimeKind.Local).AddTicks(8473), new DateTime(2022, 7, 27, 19, 1, 30, 61, DateTimeKind.Local).AddTicks(8644) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 1, 30, 62, DateTimeKind.Local).AddTicks(1922), new DateTime(2022, 7, 27, 19, 1, 30, 62, DateTimeKind.Local).AddTicks(1924) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 1, 30, 62, DateTimeKind.Local).AddTicks(1929), new DateTime(2022, 7, 27, 19, 1, 30, 62, DateTimeKind.Local).AddTicks(1931) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 1, 30, 62, DateTimeKind.Local).AddTicks(1913), new DateTime(2022, 7, 27, 19, 1, 30, 62, DateTimeKind.Local).AddTicks(1916) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 1, 30, 65, DateTimeKind.Local).AddTicks(6274), new DateTime(2022, 7, 27, 19, 1, 30, 65, DateTimeKind.Local).AddTicks(6276) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 1, 30, 65, DateTimeKind.Local).AddTicks(6268), new DateTime(2022, 7, 27, 19, 1, 30, 65, DateTimeKind.Local).AddTicks(6270) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 1, 30, 65, DateTimeKind.Local).AddTicks(6261), new DateTime(2022, 7, 27, 19, 1, 30, 65, DateTimeKind.Local).AddTicks(6263) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 1, 30, 65, DateTimeKind.Local).AddTicks(5192), new DateTime(2022, 7, 27, 19, 1, 30, 65, DateTimeKind.Local).AddTicks(5204) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 1, 30, 65, DateTimeKind.Local).AddTicks(6226), new DateTime(2022, 7, 27, 19, 1, 30, 65, DateTimeKind.Local).AddTicks(6232) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 1, 30, 63, DateTimeKind.Local).AddTicks(8428), new DateTime(2022, 7, 27, 19, 1, 30, 63, DateTimeKind.Local).AddTicks(8451) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 1, 30, 54, DateTimeKind.Local).AddTicks(3492), new DateTime(2022, 7, 27, 19, 1, 30, 55, DateTimeKind.Local).AddTicks(2004) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 1, 30, 55, DateTimeKind.Local).AddTicks(3388), new DateTime(2022, 7, 27, 19, 1, 30, 55, DateTimeKind.Local).AddTicks(3405) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 1, 30, 55, DateTimeKind.Local).AddTicks(3440), new DateTime(2022, 7, 27, 19, 1, 30, 55, DateTimeKind.Local).AddTicks(3443) });
        }
    }
}
