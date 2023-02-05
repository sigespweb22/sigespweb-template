using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class ChangeDetentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Detentos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pec",
                table: "Detentos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeFamiliar",
                table: "Detentos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Detentos",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 19, 36, 20, 638, DateTimeKind.Local).AddTicks(2675), new DateTime(2021, 12, 6, 19, 36, 20, 638, DateTimeKind.Local).AddTicks(2473), new DateTime(2021, 12, 6, 19, 36, 20, 638, DateTimeKind.Local).AddTicks(2678) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 19, 36, 20, 638, DateTimeKind.Local).AddTicks(2420), new DateTime(2021, 12, 6, 19, 36, 20, 637, DateTimeKind.Local).AddTicks(8200), new DateTime(2021, 12, 6, 19, 36, 20, 638, DateTimeKind.Local).AddTicks(2433) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 19, 36, 20, 641, DateTimeKind.Local).AddTicks(905), new DateTime(2021, 12, 6, 19, 36, 20, 641, DateTimeKind.Local).AddTicks(883), new DateTime(2021, 12, 6, 19, 36, 20, 641, DateTimeKind.Local).AddTicks(909) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 19, 36, 20, 641, DateTimeKind.Local).AddTicks(540), new DateTime(2021, 12, 6, 19, 36, 20, 640, DateTimeKind.Local).AddTicks(9998), new DateTime(2021, 12, 6, 19, 36, 20, 641, DateTimeKind.Local).AddTicks(552) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 19, 36, 20, 623, DateTimeKind.Local).AddTicks(8470), "Maria de Lourdes", new DateTime(2021, 12, 6, 19, 36, 20, 624, DateTimeKind.Local).AddTicks(8390) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 19, 36, 20, 624, DateTimeKind.Local).AddTicks(9077), "Carlos Amarildo de Souza", new DateTime(2021, 12, 6, 19, 36, 20, 624, DateTimeKind.Local).AddTicks(9097) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 19, 36, 20, 628, DateTimeKind.Local).AddTicks(1176), new DateTime(2021, 12, 6, 19, 36, 20, 628, DateTimeKind.Local).AddTicks(1211) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 19, 36, 20, 628, DateTimeKind.Local).AddTicks(1345), new DateTime(2021, 12, 6, 19, 36, 20, 628, DateTimeKind.Local).AddTicks(1348) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 19, 36, 20, 633, DateTimeKind.Local).AddTicks(429), new DateTime(2021, 12, 6, 19, 36, 20, 632, DateTimeKind.Local).AddTicks(8449), new DateTime(2021, 12, 6, 19, 36, 20, 632, DateTimeKind.Local).AddTicks(8065), new DateTime(2021, 12, 6, 19, 36, 20, 633, DateTimeKind.Local).AddTicks(443) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 6, 19, 36, 20, 633, DateTimeKind.Local).AddTicks(501), new DateTime(2021, 12, 6, 19, 36, 20, 633, DateTimeKind.Local).AddTicks(492) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 19, 36, 20, 643, DateTimeKind.Local).AddTicks(3170), new DateTime(2021, 12, 6, 19, 36, 20, 643, DateTimeKind.Local).AddTicks(555), new DateTime(2021, 12, 6, 19, 36, 20, 643, DateTimeKind.Local).AddTicks(2134), new DateTime(2021, 12, 6, 19, 36, 20, 643, DateTimeKind.Local).AddTicks(3182) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 19, 36, 20, 643, DateTimeKind.Local).AddTicks(3580), new DateTime(2021, 12, 6, 19, 36, 20, 643, DateTimeKind.Local).AddTicks(3462), new DateTime(2021, 12, 6, 19, 36, 20, 643, DateTimeKind.Local).AddTicks(3510), new DateTime(2021, 12, 6, 19, 36, 20, 643, DateTimeKind.Local).AddTicks(3583) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Detentos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pec",
                table: "Detentos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeFamiliar",
                table: "Detentos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Detentos",
                type: "character varying(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 16, 1, 41, 336, DateTimeKind.Local).AddTicks(1903), new DateTime(2021, 12, 6, 16, 1, 41, 336, DateTimeKind.Local).AddTicks(1723), new DateTime(2021, 12, 6, 16, 1, 41, 336, DateTimeKind.Local).AddTicks(1906) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 16, 1, 41, 336, DateTimeKind.Local).AddTicks(1672), new DateTime(2021, 12, 6, 16, 1, 41, 335, DateTimeKind.Local).AddTicks(6456), new DateTime(2021, 12, 6, 16, 1, 41, 336, DateTimeKind.Local).AddTicks(1681) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 16, 1, 41, 340, DateTimeKind.Local).AddTicks(5764), new DateTime(2021, 12, 6, 16, 1, 41, 340, DateTimeKind.Local).AddTicks(5740), new DateTime(2021, 12, 6, 16, 1, 41, 340, DateTimeKind.Local).AddTicks(5769) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 16, 1, 41, 340, DateTimeKind.Local).AddTicks(5311), new DateTime(2021, 12, 6, 16, 1, 41, 340, DateTimeKind.Local).AddTicks(4626), new DateTime(2021, 12, 6, 16, 1, 41, 340, DateTimeKind.Local).AddTicks(5326) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 16, 1, 41, 321, DateTimeKind.Local).AddTicks(8887), new DateTime(2021, 12, 6, 16, 1, 41, 322, DateTimeKind.Local).AddTicks(9013) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 16, 1, 41, 322, DateTimeKind.Local).AddTicks(9874), new DateTime(2021, 12, 6, 16, 1, 41, 322, DateTimeKind.Local).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 16, 1, 41, 326, DateTimeKind.Local).AddTicks(8407), new DateTime(2021, 12, 6, 16, 1, 41, 326, DateTimeKind.Local).AddTicks(8439) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 16, 1, 41, 326, DateTimeKind.Local).AddTicks(8594), new DateTime(2021, 12, 6, 16, 1, 41, 326, DateTimeKind.Local).AddTicks(8597) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 16, 1, 41, 330, DateTimeKind.Local).AddTicks(7007), new DateTime(2021, 12, 6, 16, 1, 41, 330, DateTimeKind.Local).AddTicks(5009), new DateTime(2021, 12, 6, 16, 1, 41, 330, DateTimeKind.Local).AddTicks(4603), new DateTime(2021, 12, 6, 16, 1, 41, 330, DateTimeKind.Local).AddTicks(7036) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 6, 16, 1, 41, 330, DateTimeKind.Local).AddTicks(7111), new DateTime(2021, 12, 6, 16, 1, 41, 330, DateTimeKind.Local).AddTicks(7096) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 16, 1, 41, 343, DateTimeKind.Local).AddTicks(2914), new DateTime(2021, 12, 6, 16, 1, 41, 342, DateTimeKind.Local).AddTicks(9681), new DateTime(2021, 12, 6, 16, 1, 41, 343, DateTimeKind.Local).AddTicks(1538), new DateTime(2021, 12, 6, 16, 1, 41, 343, DateTimeKind.Local).AddTicks(2929) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 16, 1, 41, 343, DateTimeKind.Local).AddTicks(3416), new DateTime(2021, 12, 6, 16, 1, 41, 343, DateTimeKind.Local).AddTicks(3281), new DateTime(2021, 12, 6, 16, 1, 41, 343, DateTimeKind.Local).AddTicks(3340), new DateTime(2021, 12, 6, 16, 1, 41, 343, DateTimeKind.Local).AddTicks(3420) });
        }
    }
}
