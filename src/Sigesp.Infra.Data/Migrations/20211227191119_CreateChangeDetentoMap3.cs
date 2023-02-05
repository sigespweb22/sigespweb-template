using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeDetentoMap3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Detentos_Ipen",
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
                name: "IX_Detentos_Ipen",
                table: "Detentos",
                column: "Ipen",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Detentos_Ipen",
                table: "Detentos");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 27, 15, 49, 57, 480, DateTimeKind.Local).AddTicks(9819), new DateTime(2021, 12, 27, 15, 49, 57, 480, DateTimeKind.Local).AddTicks(9645), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2021, 12, 27, 15, 49, 57, 480, DateTimeKind.Local).AddTicks(9823) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 27, 15, 49, 57, 480, DateTimeKind.Local).AddTicks(9599), new DateTime(2021, 12, 27, 15, 49, 57, 480, DateTimeKind.Local).AddTicks(4384), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2021, 12, 27, 15, 49, 57, 480, DateTimeKind.Local).AddTicks(9609) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 15, 49, 57, 461, DateTimeKind.Local).AddTicks(5854), new DateTime(2021, 12, 27, 15, 49, 57, 461, DateTimeKind.Local).AddTicks(5878) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 15, 49, 57, 460, DateTimeKind.Local).AddTicks(3626), new DateTime(2021, 12, 27, 15, 49, 57, 461, DateTimeKind.Local).AddTicks(4754) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 15, 49, 57, 484, DateTimeKind.Local).AddTicks(3878), new DateTime(2021, 12, 27, 15, 49, 57, 484, DateTimeKind.Local).AddTicks(3856), new DateTime(2021, 12, 27, 15, 49, 57, 484, DateTimeKind.Local).AddTicks(3881) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 15, 49, 57, 484, DateTimeKind.Local).AddTicks(3293), new DateTime(2021, 12, 27, 15, 49, 57, 484, DateTimeKind.Local).AddTicks(2616), new DateTime(2021, 12, 27, 15, 49, 57, 484, DateTimeKind.Local).AddTicks(3310) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 27, 15, 49, 57, 467, DateTimeKind.Local).AddTicks(93), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 27, 15, 49, 57, 467, DateTimeKind.Local).AddTicks(127) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 27, 15, 49, 57, 467, DateTimeKind.Local).AddTicks(241), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 27, 15, 49, 57, 467, DateTimeKind.Local).AddTicks(245) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 15, 49, 57, 470, DateTimeKind.Local).AddTicks(7274), new DateTime(2021, 12, 27, 15, 49, 57, 470, DateTimeKind.Local).AddTicks(7307) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 15, 49, 57, 470, DateTimeKind.Local).AddTicks(7460), new DateTime(2021, 12, 27, 15, 49, 57, 470, DateTimeKind.Local).AddTicks(7463) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 15, 49, 57, 474, DateTimeKind.Local).AddTicks(4672), new DateTime(2021, 12, 27, 15, 49, 57, 474, DateTimeKind.Local).AddTicks(2949), new DateTime(2021, 12, 27, 15, 49, 57, 474, DateTimeKind.Local).AddTicks(2436), new DateTime(2021, 12, 27, 15, 49, 57, 474, DateTimeKind.Local).AddTicks(4686) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 27, 15, 49, 57, 474, DateTimeKind.Local).AddTicks(4748), new DateTime(2021, 12, 27, 15, 49, 57, 474, DateTimeKind.Local).AddTicks(4735) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 15, 49, 57, 486, DateTimeKind.Local).AddTicks(9481), new DateTime(2021, 12, 27, 15, 49, 57, 486, DateTimeKind.Local).AddTicks(6427), new DateTime(2021, 12, 27, 15, 49, 57, 486, DateTimeKind.Local).AddTicks(8293), new DateTime(2021, 12, 27, 15, 49, 57, 486, DateTimeKind.Local).AddTicks(9495) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 15, 49, 57, 486, DateTimeKind.Local).AddTicks(9983), new DateTime(2021, 12, 27, 15, 49, 57, 486, DateTimeKind.Local).AddTicks(9853), new DateTime(2021, 12, 27, 15, 49, 57, 486, DateTimeKind.Local).AddTicks(9947), new DateTime(2021, 12, 27, 15, 49, 57, 486, DateTimeKind.Local).AddTicks(9987) });

            migrationBuilder.CreateIndex(
                name: "IX_Detentos_Ipen",
                table: "Detentos",
                column: "Ipen",
                unique: true);
        }
    }
}
