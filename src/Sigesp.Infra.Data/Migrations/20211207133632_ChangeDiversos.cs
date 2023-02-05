using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class ChangeDiversos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Remuneracao",
                table: "Colaboradores",
                type: "decimal(7,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicio",
                table: "Colaboradores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 10, 36, 31, 695, DateTimeKind.Local).AddTicks(9570), new DateTime(2021, 12, 7, 10, 36, 31, 695, DateTimeKind.Local).AddTicks(9390), new DateTime(2021, 12, 7, 10, 36, 31, 695, DateTimeKind.Local).AddTicks(9575) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 10, 36, 31, 695, DateTimeKind.Local).AddTicks(9336), new DateTime(2021, 12, 7, 10, 36, 31, 695, DateTimeKind.Local).AddTicks(3618), new DateTime(2021, 12, 7, 10, 36, 31, 695, DateTimeKind.Local).AddTicks(9350) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 10, 36, 31, 700, DateTimeKind.Local).AddTicks(1521), new DateTime(2021, 12, 7, 10, 36, 31, 700, DateTimeKind.Local).AddTicks(1500), new DateTime(2021, 12, 7, 10, 36, 31, 700, DateTimeKind.Local).AddTicks(1526) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 10, 36, 31, 700, DateTimeKind.Local).AddTicks(1021), new DateTime(2021, 12, 7, 10, 36, 31, 700, DateTimeKind.Local).AddTicks(261), new DateTime(2021, 12, 7, 10, 36, 31, 700, DateTimeKind.Local).AddTicks(1037) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 10, 36, 31, 679, DateTimeKind.Local).AddTicks(6902), "Maria de Lourdes", new DateTime(2021, 12, 7, 10, 36, 31, 680, DateTimeKind.Local).AddTicks(7565) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 10, 36, 31, 680, DateTimeKind.Local).AddTicks(8501), "Carlos Amarildo de Souza", new DateTime(2021, 12, 7, 10, 36, 31, 680, DateTimeKind.Local).AddTicks(8525) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 10, 36, 31, 686, DateTimeKind.Local).AddTicks(5106), new DateTime(2021, 12, 7, 10, 36, 31, 686, DateTimeKind.Local).AddTicks(5143) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 10, 36, 31, 686, DateTimeKind.Local).AddTicks(5305), new DateTime(2021, 12, 7, 10, 36, 31, 686, DateTimeKind.Local).AddTicks(5311) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 10, 36, 31, 690, DateTimeKind.Local).AddTicks(4202), new DateTime(2021, 12, 7, 10, 36, 31, 690, DateTimeKind.Local).AddTicks(2397), new DateTime(2021, 12, 7, 10, 36, 31, 690, DateTimeKind.Local).AddTicks(1990), new DateTime(2021, 12, 7, 10, 36, 31, 690, DateTimeKind.Local).AddTicks(4217) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 7, 10, 36, 31, 690, DateTimeKind.Local).AddTicks(4262), new DateTime(2021, 12, 7, 10, 36, 31, 690, DateTimeKind.Local).AddTicks(4252) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 10, 36, 31, 703, DateTimeKind.Local).AddTicks(6400), new DateTime(2021, 12, 7, 10, 36, 31, 703, DateTimeKind.Local).AddTicks(1986), new DateTime(2021, 12, 7, 10, 36, 31, 703, DateTimeKind.Local).AddTicks(4886), new DateTime(2021, 12, 7, 10, 36, 31, 703, DateTimeKind.Local).AddTicks(6419) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 10, 36, 31, 703, DateTimeKind.Local).AddTicks(6951), new DateTime(2021, 12, 7, 10, 36, 31, 703, DateTimeKind.Local).AddTicks(6815), new DateTime(2021, 12, 7, 10, 36, 31, 703, DateTimeKind.Local).AddTicks(6872), new DateTime(2021, 12, 7, 10, 36, 31, 703, DateTimeKind.Local).AddTicks(6956) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataInicio",
                table: "Colaboradores");

            migrationBuilder.AlterColumn<decimal>(
                name: "Remuneracao",
                table: "Colaboradores",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,3)");

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
    }
}
