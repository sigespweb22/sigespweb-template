using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeDetentoMap2 : Migration
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
                values: new object[] { 1, new DateTime(2021, 12, 27, 14, 53, 33, 269, DateTimeKind.Local).AddTicks(2338), new DateTime(2021, 12, 27, 14, 53, 33, 269, DateTimeKind.Local).AddTicks(2155), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2021, 12, 27, 14, 53, 33, 269, DateTimeKind.Local).AddTicks(2341) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 27, 14, 53, 33, 269, DateTimeKind.Local).AddTicks(2109), new DateTime(2021, 12, 27, 14, 53, 33, 268, DateTimeKind.Local).AddTicks(6774), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2021, 12, 27, 14, 53, 33, 269, DateTimeKind.Local).AddTicks(2118) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 14, 53, 33, 250, DateTimeKind.Local).AddTicks(1065), new DateTime(2021, 12, 27, 14, 53, 33, 250, DateTimeKind.Local).AddTicks(1086) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 14, 53, 33, 249, DateTimeKind.Local).AddTicks(301), new DateTime(2021, 12, 27, 14, 53, 33, 249, DateTimeKind.Local).AddTicks(9963) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 14, 53, 33, 272, DateTimeKind.Local).AddTicks(4667), new DateTime(2021, 12, 27, 14, 53, 33, 272, DateTimeKind.Local).AddTicks(4634), new DateTime(2021, 12, 27, 14, 53, 33, 272, DateTimeKind.Local).AddTicks(4671) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 14, 53, 33, 272, DateTimeKind.Local).AddTicks(4219), new DateTime(2021, 12, 27, 14, 53, 33, 272, DateTimeKind.Local).AddTicks(3553), new DateTime(2021, 12, 27, 14, 53, 33, 272, DateTimeKind.Local).AddTicks(4233) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 27, 14, 53, 33, 255, DateTimeKind.Local).AddTicks(2185), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 27, 14, 53, 33, 255, DateTimeKind.Local).AddTicks(2218) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 27, 14, 53, 33, 255, DateTimeKind.Local).AddTicks(2333), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 27, 14, 53, 33, 255, DateTimeKind.Local).AddTicks(2336) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 14, 53, 33, 259, DateTimeKind.Local).AddTicks(2257), new DateTime(2021, 12, 27, 14, 53, 33, 259, DateTimeKind.Local).AddTicks(2292) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 14, 53, 33, 259, DateTimeKind.Local).AddTicks(2446), new DateTime(2021, 12, 27, 14, 53, 33, 259, DateTimeKind.Local).AddTicks(2451) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 14, 53, 33, 262, DateTimeKind.Local).AddTicks(9272), new DateTime(2021, 12, 27, 14, 53, 33, 262, DateTimeKind.Local).AddTicks(7462), new DateTime(2021, 12, 27, 14, 53, 33, 262, DateTimeKind.Local).AddTicks(7081), new DateTime(2021, 12, 27, 14, 53, 33, 262, DateTimeKind.Local).AddTicks(9287) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 27, 14, 53, 33, 262, DateTimeKind.Local).AddTicks(9342), new DateTime(2021, 12, 27, 14, 53, 33, 262, DateTimeKind.Local).AddTicks(9328) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 14, 53, 33, 275, DateTimeKind.Local).AddTicks(2838), new DateTime(2021, 12, 27, 14, 53, 33, 274, DateTimeKind.Local).AddTicks(9682), new DateTime(2021, 12, 27, 14, 53, 33, 275, DateTimeKind.Local).AddTicks(1628), new DateTime(2021, 12, 27, 14, 53, 33, 275, DateTimeKind.Local).AddTicks(2852) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 14, 53, 33, 275, DateTimeKind.Local).AddTicks(3360), new DateTime(2021, 12, 27, 14, 53, 33, 275, DateTimeKind.Local).AddTicks(3196), new DateTime(2021, 12, 27, 14, 53, 33, 275, DateTimeKind.Local).AddTicks(3328), new DateTime(2021, 12, 27, 14, 53, 33, 275, DateTimeKind.Local).AddTicks(3365) });

            migrationBuilder.CreateIndex(
                name: "IX_Detentos_Ipen",
                table: "Detentos",
                column: "Ipen");
        }
    }
}
