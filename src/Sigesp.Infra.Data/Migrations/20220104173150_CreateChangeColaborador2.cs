using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeColaborador2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Detentos_DetentoId",
                table: "Colaboradores");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Detentos_DetentoId",
                table: "Colaboradores",
                column: "DetentoId",
                principalTable: "Detentos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Detentos_DetentoId",
                table: "Colaboradores");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 4, 14, 29, 59, 850, DateTimeKind.Local).AddTicks(3495), new DateTime(2022, 1, 4, 14, 29, 59, 850, DateTimeKind.Local).AddTicks(3333), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2022, 1, 4, 14, 29, 59, 850, DateTimeKind.Local).AddTicks(3499) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2022, 1, 4, 14, 29, 59, 850, DateTimeKind.Local).AddTicks(3271), new DateTime(2022, 1, 4, 14, 29, 59, 849, DateTimeKind.Local).AddTicks(8669), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2022, 1, 4, 14, 29, 59, 850, DateTimeKind.Local).AddTicks(3292) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 29, 59, 833, DateTimeKind.Local).AddTicks(2094), new DateTime(2022, 1, 4, 14, 29, 59, 833, DateTimeKind.Local).AddTicks(2115) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 29, 59, 832, DateTimeKind.Local).AddTicks(3615), new DateTime(2022, 1, 4, 14, 29, 59, 833, DateTimeKind.Local).AddTicks(1241) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 29, 59, 853, DateTimeKind.Local).AddTicks(2568), new DateTime(2022, 1, 4, 14, 29, 59, 853, DateTimeKind.Local).AddTicks(2554), new DateTime(2022, 1, 4, 14, 29, 59, 853, DateTimeKind.Local).AddTicks(2572) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 29, 59, 853, DateTimeKind.Local).AddTicks(2228), new DateTime(2022, 1, 4, 14, 29, 59, 853, DateTimeKind.Local).AddTicks(1724), new DateTime(2022, 1, 4, 14, 29, 59, 853, DateTimeKind.Local).AddTicks(2242) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2022, 1, 4, 14, 29, 59, 838, DateTimeKind.Local).AddTicks(8024), true, "Maria de Lourdes", 7, new DateTime(2022, 1, 4, 14, 29, 59, 838, DateTimeKind.Local).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2022, 1, 4, 14, 29, 59, 838, DateTimeKind.Local).AddTicks(8158), true, "Carlos Amarildo de Souza", 8, new DateTime(2022, 1, 4, 14, 29, 59, 838, DateTimeKind.Local).AddTicks(8162) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 29, 59, 842, DateTimeKind.Local).AddTicks(2819), new DateTime(2022, 1, 4, 14, 29, 59, 842, DateTimeKind.Local).AddTicks(2856) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 29, 59, 842, DateTimeKind.Local).AddTicks(2987), new DateTime(2022, 1, 4, 14, 29, 59, 842, DateTimeKind.Local).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 29, 59, 845, DateTimeKind.Local).AddTicks(520), new DateTime(2022, 1, 4, 14, 29, 59, 844, DateTimeKind.Local).AddTicks(9226), new DateTime(2022, 1, 4, 14, 29, 59, 844, DateTimeKind.Local).AddTicks(8910), new DateTime(2022, 1, 4, 14, 29, 59, 845, DateTimeKind.Local).AddTicks(532) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 29, 59, 845, DateTimeKind.Local).AddTicks(572), new DateTime(2022, 1, 4, 14, 29, 59, 845, DateTimeKind.Local).AddTicks(564) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 29, 59, 855, DateTimeKind.Local).AddTicks(3703), new DateTime(2022, 1, 4, 14, 29, 59, 855, DateTimeKind.Local).AddTicks(1261), new DateTime(2022, 1, 4, 14, 29, 59, 855, DateTimeKind.Local).AddTicks(2762), new DateTime(2022, 1, 4, 14, 29, 59, 855, DateTimeKind.Local).AddTicks(3715) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 29, 59, 855, DateTimeKind.Local).AddTicks(4098), new DateTime(2022, 1, 4, 14, 29, 59, 855, DateTimeKind.Local).AddTicks(3983), new DateTime(2022, 1, 4, 14, 29, 59, 855, DateTimeKind.Local).AddTicks(4070), new DateTime(2022, 1, 4, 14, 29, 59, 855, DateTimeKind.Local).AddTicks(4102) });

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Detentos_DetentoId",
                table: "Colaboradores",
                column: "DetentoId",
                principalTable: "Detentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
