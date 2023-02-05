using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeDetento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 4, 14, 39, 43, 302, DateTimeKind.Local).AddTicks(3117), new DateTime(2022, 1, 4, 14, 39, 43, 302, DateTimeKind.Local).AddTicks(2965), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2022, 1, 4, 14, 39, 43, 302, DateTimeKind.Local).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2022, 1, 4, 14, 39, 43, 302, DateTimeKind.Local).AddTicks(2922), new DateTime(2022, 1, 4, 14, 39, 43, 301, DateTimeKind.Local).AddTicks(8462), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2022, 1, 4, 14, 39, 43, 302, DateTimeKind.Local).AddTicks(2934) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 285, DateTimeKind.Local).AddTicks(6237), new DateTime(2022, 1, 4, 14, 39, 43, 285, DateTimeKind.Local).AddTicks(6258) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 284, DateTimeKind.Local).AddTicks(7270), new DateTime(2022, 1, 4, 14, 39, 43, 285, DateTimeKind.Local).AddTicks(5348) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 305, DateTimeKind.Local).AddTicks(128), new DateTime(2022, 1, 4, 14, 39, 43, 305, DateTimeKind.Local).AddTicks(111), new DateTime(2022, 1, 4, 14, 39, 43, 305, DateTimeKind.Local).AddTicks(131) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 304, DateTimeKind.Local).AddTicks(9758), new DateTime(2022, 1, 4, 14, 39, 43, 304, DateTimeKind.Local).AddTicks(9233), new DateTime(2022, 1, 4, 14, 39, 43, 304, DateTimeKind.Local).AddTicks(9770) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2022, 1, 4, 14, 39, 43, 291, DateTimeKind.Local).AddTicks(3704), true, "Maria de Lourdes", 7, new DateTime(2022, 1, 4, 14, 39, 43, 291, DateTimeKind.Local).AddTicks(3743) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2022, 1, 4, 14, 39, 43, 291, DateTimeKind.Local).AddTicks(3832), true, "Carlos Amarildo de Souza", 8, new DateTime(2022, 1, 4, 14, 39, 43, 291, DateTimeKind.Local).AddTicks(3836) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 294, DateTimeKind.Local).AddTicks(3899), new DateTime(2022, 1, 4, 14, 39, 43, 294, DateTimeKind.Local).AddTicks(3937) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 294, DateTimeKind.Local).AddTicks(4090), new DateTime(2022, 1, 4, 14, 39, 43, 294, DateTimeKind.Local).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 297, DateTimeKind.Local).AddTicks(125), new DateTime(2022, 1, 4, 14, 39, 43, 296, DateTimeKind.Local).AddTicks(8782), new DateTime(2022, 1, 4, 14, 39, 43, 296, DateTimeKind.Local).AddTicks(8461), new DateTime(2022, 1, 4, 14, 39, 43, 297, DateTimeKind.Local).AddTicks(138) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 297, DateTimeKind.Local).AddTicks(177), new DateTime(2022, 1, 4, 14, 39, 43, 297, DateTimeKind.Local).AddTicks(168) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(3481), new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(906), new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(2502), new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(3495) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(3890), new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(3777), new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(3860), new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(3894) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 4, 14, 31, 49, 613, DateTimeKind.Local).AddTicks(1922), new DateTime(2022, 1, 4, 14, 31, 49, 613, DateTimeKind.Local).AddTicks(1792), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2022, 1, 4, 14, 31, 49, 613, DateTimeKind.Local).AddTicks(1924) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2022, 1, 4, 14, 31, 49, 613, DateTimeKind.Local).AddTicks(1755), new DateTime(2022, 1, 4, 14, 31, 49, 612, DateTimeKind.Local).AddTicks(7622), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2022, 1, 4, 14, 31, 49, 613, DateTimeKind.Local).AddTicks(1763) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 31, 49, 598, DateTimeKind.Local).AddTicks(3635), new DateTime(2022, 1, 4, 14, 31, 49, 598, DateTimeKind.Local).AddTicks(3653) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 31, 49, 597, DateTimeKind.Local).AddTicks(4601), new DateTime(2022, 1, 4, 14, 31, 49, 598, DateTimeKind.Local).AddTicks(2769) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 31, 49, 616, DateTimeKind.Local).AddTicks(748), new DateTime(2022, 1, 4, 14, 31, 49, 616, DateTimeKind.Local).AddTicks(729), new DateTime(2022, 1, 4, 14, 31, 49, 616, DateTimeKind.Local).AddTicks(751) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 31, 49, 616, DateTimeKind.Local).AddTicks(386), new DateTime(2022, 1, 4, 14, 31, 49, 615, DateTimeKind.Local).AddTicks(9712), new DateTime(2022, 1, 4, 14, 31, 49, 616, DateTimeKind.Local).AddTicks(399) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2022, 1, 4, 14, 31, 49, 602, DateTimeKind.Local).AddTicks(8893), true, "Maria de Lourdes", 7, new DateTime(2022, 1, 4, 14, 31, 49, 602, DateTimeKind.Local).AddTicks(8916) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2022, 1, 4, 14, 31, 49, 602, DateTimeKind.Local).AddTicks(9003), true, "Carlos Amarildo de Souza", 8, new DateTime(2022, 1, 4, 14, 31, 49, 602, DateTimeKind.Local).AddTicks(9007) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 31, 49, 605, DateTimeKind.Local).AddTicks(7231), new DateTime(2022, 1, 4, 14, 31, 49, 605, DateTimeKind.Local).AddTicks(7255) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 31, 49, 605, DateTimeKind.Local).AddTicks(7363), new DateTime(2022, 1, 4, 14, 31, 49, 605, DateTimeKind.Local).AddTicks(7367) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 31, 49, 608, DateTimeKind.Local).AddTicks(2531), new DateTime(2022, 1, 4, 14, 31, 49, 608, DateTimeKind.Local).AddTicks(1240), new DateTime(2022, 1, 4, 14, 31, 49, 608, DateTimeKind.Local).AddTicks(938), new DateTime(2022, 1, 4, 14, 31, 49, 608, DateTimeKind.Local).AddTicks(2542) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 31, 49, 608, DateTimeKind.Local).AddTicks(2577), new DateTime(2022, 1, 4, 14, 31, 49, 608, DateTimeKind.Local).AddTicks(2571) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 31, 49, 618, DateTimeKind.Local).AddTicks(7011), new DateTime(2022, 1, 4, 14, 31, 49, 618, DateTimeKind.Local).AddTicks(4479), new DateTime(2022, 1, 4, 14, 31, 49, 618, DateTimeKind.Local).AddTicks(6057), new DateTime(2022, 1, 4, 14, 31, 49, 618, DateTimeKind.Local).AddTicks(7023) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 31, 49, 618, DateTimeKind.Local).AddTicks(7401), new DateTime(2022, 1, 4, 14, 31, 49, 618, DateTimeKind.Local).AddTicks(7296), new DateTime(2022, 1, 4, 14, 31, 49, 618, DateTimeKind.Local).AddTicks(7374), new DateTime(2022, 1, 4, 14, 31, 49, 618, DateTimeKind.Local).AddTicks(7405) });
        }
    }
}
