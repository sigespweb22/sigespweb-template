using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesMicellaneous : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 28, 11, 26, 29, 539, DateTimeKind.Local).AddTicks(6326), new DateTime(2021, 12, 28, 11, 26, 29, 539, DateTimeKind.Local).AddTicks(6153), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2021, 12, 28, 11, 26, 29, 539, DateTimeKind.Local).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 28, 11, 26, 29, 539, DateTimeKind.Local).AddTicks(6102), new DateTime(2021, 12, 28, 11, 26, 29, 539, DateTimeKind.Local).AddTicks(733), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2021, 12, 28, 11, 26, 29, 539, DateTimeKind.Local).AddTicks(6113) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 28, 11, 26, 29, 516, DateTimeKind.Local).AddTicks(8532), new DateTime(2021, 12, 28, 11, 26, 29, 516, DateTimeKind.Local).AddTicks(8586) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 28, 11, 26, 29, 515, DateTimeKind.Local).AddTicks(4685), new DateTime(2021, 12, 28, 11, 26, 29, 516, DateTimeKind.Local).AddTicks(6716) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 28, 11, 26, 29, 543, DateTimeKind.Local).AddTicks(125), new DateTime(2021, 12, 28, 11, 26, 29, 543, DateTimeKind.Local).AddTicks(102), new DateTime(2021, 12, 28, 11, 26, 29, 543, DateTimeKind.Local).AddTicks(129) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 28, 11, 26, 29, 542, DateTimeKind.Local).AddTicks(9682), new DateTime(2021, 12, 28, 11, 26, 29, 542, DateTimeKind.Local).AddTicks(9023), new DateTime(2021, 12, 28, 11, 26, 29, 542, DateTimeKind.Local).AddTicks(9698) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 28, 11, 26, 29, 525, DateTimeKind.Local).AddTicks(3634), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 28, 11, 26, 29, 525, DateTimeKind.Local).AddTicks(3676) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 28, 11, 26, 29, 525, DateTimeKind.Local).AddTicks(3796), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 28, 11, 26, 29, 525, DateTimeKind.Local).AddTicks(3800) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 28, 11, 26, 29, 529, DateTimeKind.Local).AddTicks(1595), new DateTime(2021, 12, 28, 11, 26, 29, 529, DateTimeKind.Local).AddTicks(1628) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 28, 11, 26, 29, 529, DateTimeKind.Local).AddTicks(1788), new DateTime(2021, 12, 28, 11, 26, 29, 529, DateTimeKind.Local).AddTicks(1791) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 28, 11, 26, 29, 533, DateTimeKind.Local).AddTicks(734), new DateTime(2021, 12, 28, 11, 26, 29, 532, DateTimeKind.Local).AddTicks(9035), new DateTime(2021, 12, 28, 11, 26, 29, 532, DateTimeKind.Local).AddTicks(8509), new DateTime(2021, 12, 28, 11, 26, 29, 533, DateTimeKind.Local).AddTicks(747) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 28, 11, 26, 29, 533, DateTimeKind.Local).AddTicks(801), new DateTime(2021, 12, 28, 11, 26, 29, 533, DateTimeKind.Local).AddTicks(790) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 28, 11, 26, 29, 545, DateTimeKind.Local).AddTicks(6132), new DateTime(2021, 12, 28, 11, 26, 29, 545, DateTimeKind.Local).AddTicks(2987), new DateTime(2021, 12, 28, 11, 26, 29, 545, DateTimeKind.Local).AddTicks(4927), new DateTime(2021, 12, 28, 11, 26, 29, 545, DateTimeKind.Local).AddTicks(6145) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 28, 11, 26, 29, 545, DateTimeKind.Local).AddTicks(6620), new DateTime(2021, 12, 28, 11, 26, 29, 545, DateTimeKind.Local).AddTicks(6493), new DateTime(2021, 12, 28, 11, 26, 29, 545, DateTimeKind.Local).AddTicks(6580), new DateTime(2021, 12, 28, 11, 26, 29, 545, DateTimeKind.Local).AddTicks(6624) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 27, 16, 13, 58, 899, DateTimeKind.Local).AddTicks(2788), new DateTime(2021, 12, 27, 16, 13, 58, 899, DateTimeKind.Local).AddTicks(2637), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2021, 12, 27, 16, 13, 58, 899, DateTimeKind.Local).AddTicks(2791) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 27, 16, 13, 58, 899, DateTimeKind.Local).AddTicks(2598), new DateTime(2021, 12, 27, 16, 13, 58, 898, DateTimeKind.Local).AddTicks(8086), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2021, 12, 27, 16, 13, 58, 899, DateTimeKind.Local).AddTicks(2606) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 13, 58, 882, DateTimeKind.Local).AddTicks(3299), new DateTime(2021, 12, 27, 16, 13, 58, 882, DateTimeKind.Local).AddTicks(3318) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 13, 58, 881, DateTimeKind.Local).AddTicks(3002), new DateTime(2021, 12, 27, 16, 13, 58, 882, DateTimeKind.Local).AddTicks(2371) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 13, 58, 902, DateTimeKind.Local).AddTicks(1602), new DateTime(2021, 12, 27, 16, 13, 58, 902, DateTimeKind.Local).AddTicks(1585), new DateTime(2021, 12, 27, 16, 13, 58, 902, DateTimeKind.Local).AddTicks(1605) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 13, 58, 902, DateTimeKind.Local).AddTicks(1169), new DateTime(2021, 12, 27, 16, 13, 58, 902, DateTimeKind.Local).AddTicks(648), new DateTime(2021, 12, 27, 16, 13, 58, 902, DateTimeKind.Local).AddTicks(1181) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 27, 16, 13, 58, 887, DateTimeKind.Local).AddTicks(3267), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 27, 16, 13, 58, 887, DateTimeKind.Local).AddTicks(3299) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 27, 16, 13, 58, 887, DateTimeKind.Local).AddTicks(3394), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 27, 16, 13, 58, 887, DateTimeKind.Local).AddTicks(3398) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 13, 58, 890, DateTimeKind.Local).AddTicks(4478), new DateTime(2021, 12, 27, 16, 13, 58, 890, DateTimeKind.Local).AddTicks(4508) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 13, 58, 890, DateTimeKind.Local).AddTicks(4635), new DateTime(2021, 12, 27, 16, 13, 58, 890, DateTimeKind.Local).AddTicks(4638) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 13, 58, 893, DateTimeKind.Local).AddTicks(5738), new DateTime(2021, 12, 27, 16, 13, 58, 893, DateTimeKind.Local).AddTicks(4079), new DateTime(2021, 12, 27, 16, 13, 58, 893, DateTimeKind.Local).AddTicks(3707), new DateTime(2021, 12, 27, 16, 13, 58, 893, DateTimeKind.Local).AddTicks(5752) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 13, 58, 893, DateTimeKind.Local).AddTicks(5804), new DateTime(2021, 12, 27, 16, 13, 58, 893, DateTimeKind.Local).AddTicks(5787) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 13, 58, 904, DateTimeKind.Local).AddTicks(4218), new DateTime(2021, 12, 27, 16, 13, 58, 904, DateTimeKind.Local).AddTicks(1665), new DateTime(2021, 12, 27, 16, 13, 58, 904, DateTimeKind.Local).AddTicks(3260), new DateTime(2021, 12, 27, 16, 13, 58, 904, DateTimeKind.Local).AddTicks(4229) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 13, 58, 904, DateTimeKind.Local).AddTicks(4618), new DateTime(2021, 12, 27, 16, 13, 58, 904, DateTimeKind.Local).AddTicks(4508), new DateTime(2021, 12, 27, 16, 13, 58, 904, DateTimeKind.Local).AddTicks(4588), new DateTime(2021, 12, 27, 16, 13, 58, 904, DateTimeKind.Local).AddTicks(4621) });
        }
    }
}
