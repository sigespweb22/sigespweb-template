using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeDetentoMap4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Detentos_MatriculaFamiliar",
                table: "Detentos");

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

            migrationBuilder.CreateIndex(
                name: "IX_Detentos_MatriculaFamiliar",
                table: "Detentos",
                column: "MatriculaFamiliar",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Detentos_MatriculaFamiliar",
                table: "Detentos");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 27, 16, 11, 18, 985, DateTimeKind.Local).AddTicks(4289), new DateTime(2021, 12, 27, 16, 11, 18, 985, DateTimeKind.Local).AddTicks(4123), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2021, 12, 27, 16, 11, 18, 985, DateTimeKind.Local).AddTicks(4292) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 27, 16, 11, 18, 985, DateTimeKind.Local).AddTicks(4085), new DateTime(2021, 12, 27, 16, 11, 18, 984, DateTimeKind.Local).AddTicks(9737), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2021, 12, 27, 16, 11, 18, 985, DateTimeKind.Local).AddTicks(4092) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 11, 18, 969, DateTimeKind.Local).AddTicks(1817), new DateTime(2021, 12, 27, 16, 11, 18, 969, DateTimeKind.Local).AddTicks(1836) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 11, 18, 968, DateTimeKind.Local).AddTicks(1750), new DateTime(2021, 12, 27, 16, 11, 18, 969, DateTimeKind.Local).AddTicks(926) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 11, 18, 988, DateTimeKind.Local).AddTicks(2104), new DateTime(2021, 12, 27, 16, 11, 18, 988, DateTimeKind.Local).AddTicks(2084), new DateTime(2021, 12, 27, 16, 11, 18, 988, DateTimeKind.Local).AddTicks(2108) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 11, 18, 988, DateTimeKind.Local).AddTicks(1737), new DateTime(2021, 12, 27, 16, 11, 18, 988, DateTimeKind.Local).AddTicks(1195), new DateTime(2021, 12, 27, 16, 11, 18, 988, DateTimeKind.Local).AddTicks(1751) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 27, 16, 11, 18, 973, DateTimeKind.Local).AddTicks(7384), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 27, 16, 11, 18, 973, DateTimeKind.Local).AddTicks(7414) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 27, 16, 11, 18, 973, DateTimeKind.Local).AddTicks(7505), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 27, 16, 11, 18, 973, DateTimeKind.Local).AddTicks(7509) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 11, 18, 977, DateTimeKind.Local).AddTicks(1130), new DateTime(2021, 12, 27, 16, 11, 18, 977, DateTimeKind.Local).AddTicks(1161) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 11, 18, 977, DateTimeKind.Local).AddTicks(1294), new DateTime(2021, 12, 27, 16, 11, 18, 977, DateTimeKind.Local).AddTicks(1297) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 11, 18, 979, DateTimeKind.Local).AddTicks(9753), new DateTime(2021, 12, 27, 16, 11, 18, 979, DateTimeKind.Local).AddTicks(8412), new DateTime(2021, 12, 27, 16, 11, 18, 979, DateTimeKind.Local).AddTicks(8082), new DateTime(2021, 12, 27, 16, 11, 18, 979, DateTimeKind.Local).AddTicks(9764) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 11, 18, 979, DateTimeKind.Local).AddTicks(9806), new DateTime(2021, 12, 27, 16, 11, 18, 979, DateTimeKind.Local).AddTicks(9797) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 11, 18, 990, DateTimeKind.Local).AddTicks(4581), new DateTime(2021, 12, 27, 16, 11, 18, 990, DateTimeKind.Local).AddTicks(2000), new DateTime(2021, 12, 27, 16, 11, 18, 990, DateTimeKind.Local).AddTicks(3593), new DateTime(2021, 12, 27, 16, 11, 18, 990, DateTimeKind.Local).AddTicks(4595) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 16, 11, 18, 990, DateTimeKind.Local).AddTicks(5035), new DateTime(2021, 12, 27, 16, 11, 18, 990, DateTimeKind.Local).AddTicks(4886), new DateTime(2021, 12, 27, 16, 11, 18, 990, DateTimeKind.Local).AddTicks(5000), new DateTime(2021, 12, 27, 16, 11, 18, 990, DateTimeKind.Local).AddTicks(5039) });

            migrationBuilder.CreateIndex(
                name: "IX_Detentos_MatriculaFamiliar",
                table: "Detentos",
                column: "MatriculaFamiliar");
        }
    }
}
