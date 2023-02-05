using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChange2Edis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Edis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 3, 15, 14, 31, 136, DateTimeKind.Local).AddTicks(6645), new DateTime(2022, 1, 3, 15, 14, 31, 136, DateTimeKind.Local).AddTicks(6492), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2022, 1, 3, 15, 14, 31, 136, DateTimeKind.Local).AddTicks(6648) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2022, 1, 3, 15, 14, 31, 136, DateTimeKind.Local).AddTicks(6457), new DateTime(2022, 1, 3, 15, 14, 31, 136, DateTimeKind.Local).AddTicks(2432), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2022, 1, 3, 15, 14, 31, 136, DateTimeKind.Local).AddTicks(6464) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 14, 31, 121, DateTimeKind.Local).AddTicks(9067), new DateTime(2022, 1, 3, 15, 14, 31, 121, DateTimeKind.Local).AddTicks(9086) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 14, 31, 121, DateTimeKind.Local).AddTicks(617), new DateTime(2022, 1, 3, 15, 14, 31, 121, DateTimeKind.Local).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 14, 31, 139, DateTimeKind.Local).AddTicks(1599), new DateTime(2022, 1, 3, 15, 14, 31, 139, DateTimeKind.Local).AddTicks(1583), new DateTime(2022, 1, 3, 15, 14, 31, 139, DateTimeKind.Local).AddTicks(1602) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 14, 31, 139, DateTimeKind.Local).AddTicks(1260), new DateTime(2022, 1, 3, 15, 14, 31, 139, DateTimeKind.Local).AddTicks(742), new DateTime(2022, 1, 3, 15, 14, 31, 139, DateTimeKind.Local).AddTicks(1271) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2022, 1, 3, 15, 14, 31, 126, DateTimeKind.Local).AddTicks(3803), true, "Maria de Lourdes", 7, new DateTime(2022, 1, 3, 15, 14, 31, 126, DateTimeKind.Local).AddTicks(3825) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2022, 1, 3, 15, 14, 31, 126, DateTimeKind.Local).AddTicks(3931), true, "Carlos Amarildo de Souza", 8, new DateTime(2022, 1, 3, 15, 14, 31, 126, DateTimeKind.Local).AddTicks(3935) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 14, 31, 129, DateTimeKind.Local).AddTicks(1953), new DateTime(2022, 1, 3, 15, 14, 31, 129, DateTimeKind.Local).AddTicks(1975) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 14, 31, 129, DateTimeKind.Local).AddTicks(2092), new DateTime(2022, 1, 3, 15, 14, 31, 129, DateTimeKind.Local).AddTicks(2095) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 14, 31, 131, DateTimeKind.Local).AddTicks(7716), new DateTime(2022, 1, 3, 15, 14, 31, 131, DateTimeKind.Local).AddTicks(6374), new DateTime(2022, 1, 3, 15, 14, 31, 131, DateTimeKind.Local).AddTicks(6079), new DateTime(2022, 1, 3, 15, 14, 31, 131, DateTimeKind.Local).AddTicks(7726) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 14, 31, 131, DateTimeKind.Local).AddTicks(7762), new DateTime(2022, 1, 3, 15, 14, 31, 131, DateTimeKind.Local).AddTicks(7755) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 14, 31, 141, DateTimeKind.Local).AddTicks(1540), new DateTime(2022, 1, 3, 15, 14, 31, 140, DateTimeKind.Local).AddTicks(9137), new DateTime(2022, 1, 3, 15, 14, 31, 141, DateTimeKind.Local).AddTicks(573), new DateTime(2022, 1, 3, 15, 14, 31, 141, DateTimeKind.Local).AddTicks(1552) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 14, 31, 141, DateTimeKind.Local).AddTicks(1923), new DateTime(2022, 1, 3, 15, 14, 31, 141, DateTimeKind.Local).AddTicks(1818), new DateTime(2022, 1, 3, 15, 14, 31, 141, DateTimeKind.Local).AddTicks(1880), new DateTime(2022, 1, 3, 15, 14, 31, 141, DateTimeKind.Local).AddTicks(1926) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Edis");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 3, 10, 44, 25, 428, DateTimeKind.Local).AddTicks(1139), new DateTime(2022, 1, 3, 10, 44, 25, 428, DateTimeKind.Local).AddTicks(998), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2022, 1, 3, 10, 44, 25, 428, DateTimeKind.Local).AddTicks(1141) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2022, 1, 3, 10, 44, 25, 428, DateTimeKind.Local).AddTicks(961), new DateTime(2022, 1, 3, 10, 44, 25, 427, DateTimeKind.Local).AddTicks(6652), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2022, 1, 3, 10, 44, 25, 428, DateTimeKind.Local).AddTicks(968) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 411, DateTimeKind.Local).AddTicks(2624), new DateTime(2022, 1, 3, 10, 44, 25, 411, DateTimeKind.Local).AddTicks(2645) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 410, DateTimeKind.Local).AddTicks(2809), new DateTime(2022, 1, 3, 10, 44, 25, 411, DateTimeKind.Local).AddTicks(1793) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 430, DateTimeKind.Local).AddTicks(6518), new DateTime(2022, 1, 3, 10, 44, 25, 430, DateTimeKind.Local).AddTicks(6504), new DateTime(2022, 1, 3, 10, 44, 25, 430, DateTimeKind.Local).AddTicks(6521) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 430, DateTimeKind.Local).AddTicks(6190), new DateTime(2022, 1, 3, 10, 44, 25, 430, DateTimeKind.Local).AddTicks(5717), new DateTime(2022, 1, 3, 10, 44, 25, 430, DateTimeKind.Local).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2022, 1, 3, 10, 44, 25, 416, DateTimeKind.Local).AddTicks(29), true, "Maria de Lourdes", 7, new DateTime(2022, 1, 3, 10, 44, 25, 416, DateTimeKind.Local).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2022, 1, 3, 10, 44, 25, 416, DateTimeKind.Local).AddTicks(142), true, "Carlos Amarildo de Souza", 8, new DateTime(2022, 1, 3, 10, 44, 25, 416, DateTimeKind.Local).AddTicks(145) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 418, DateTimeKind.Local).AddTicks(8879), new DateTime(2022, 1, 3, 10, 44, 25, 418, DateTimeKind.Local).AddTicks(8897) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 418, DateTimeKind.Local).AddTicks(9011), new DateTime(2022, 1, 3, 10, 44, 25, 418, DateTimeKind.Local).AddTicks(9015) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 421, DateTimeKind.Local).AddTicks(3999), new DateTime(2022, 1, 3, 10, 44, 25, 421, DateTimeKind.Local).AddTicks(2766), new DateTime(2022, 1, 3, 10, 44, 25, 421, DateTimeKind.Local).AddTicks(2480), new DateTime(2022, 1, 3, 10, 44, 25, 421, DateTimeKind.Local).AddTicks(4011) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 421, DateTimeKind.Local).AddTicks(4051), new DateTime(2022, 1, 3, 10, 44, 25, 421, DateTimeKind.Local).AddTicks(4044) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(6461), new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(4193), new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(5575), new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(6472) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(6816), new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(6723), new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(6786), new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(6820) });
        }
    }
}
