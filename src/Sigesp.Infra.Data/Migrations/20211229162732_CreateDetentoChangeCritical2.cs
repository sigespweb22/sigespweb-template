using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateDetentoChangeCritical2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransferenciaDataRetorno",
                table: "Detentos");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransferenciaDataRetornoPrevisto",
                table: "Detentos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TransferenciaDataRetornoRealizado",
                table: "Detentos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TransferenciaDataSaida",
                table: "Detentos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 29, 13, 27, 31, 492, DateTimeKind.Local).AddTicks(4114), new DateTime(2021, 12, 29, 13, 27, 31, 492, DateTimeKind.Local).AddTicks(3974), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2021, 12, 29, 13, 27, 31, 492, DateTimeKind.Local).AddTicks(4116) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 29, 13, 27, 31, 492, DateTimeKind.Local).AddTicks(3938), new DateTime(2021, 12, 29, 13, 27, 31, 491, DateTimeKind.Local).AddTicks(9874), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2021, 12, 29, 13, 27, 31, 492, DateTimeKind.Local).AddTicks(3946) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 13, 27, 31, 477, DateTimeKind.Local).AddTicks(6883), new DateTime(2021, 12, 29, 13, 27, 31, 477, DateTimeKind.Local).AddTicks(6901) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 13, 27, 31, 476, DateTimeKind.Local).AddTicks(8683), new DateTime(2021, 12, 29, 13, 27, 31, 477, DateTimeKind.Local).AddTicks(6039) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 13, 27, 31, 494, DateTimeKind.Local).AddTicks(8611), new DateTime(2021, 12, 29, 13, 27, 31, 494, DateTimeKind.Local).AddTicks(8594), new DateTime(2021, 12, 29, 13, 27, 31, 494, DateTimeKind.Local).AddTicks(8614) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 13, 27, 31, 494, DateTimeKind.Local).AddTicks(8281), new DateTime(2021, 12, 29, 13, 27, 31, 494, DateTimeKind.Local).AddTicks(7779), new DateTime(2021, 12, 29, 13, 27, 31, 494, DateTimeKind.Local).AddTicks(8292) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 29, 13, 27, 31, 481, DateTimeKind.Local).AddTicks(9988), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 29, 13, 27, 31, 482, DateTimeKind.Local).AddTicks(7) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 29, 13, 27, 31, 482, DateTimeKind.Local).AddTicks(91), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 29, 13, 27, 31, 482, DateTimeKind.Local).AddTicks(94) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 13, 27, 31, 485, DateTimeKind.Local).AddTicks(1656), new DateTime(2021, 12, 29, 13, 27, 31, 485, DateTimeKind.Local).AddTicks(1680) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 13, 27, 31, 485, DateTimeKind.Local).AddTicks(1795), new DateTime(2021, 12, 29, 13, 27, 31, 485, DateTimeKind.Local).AddTicks(1799) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 13, 27, 31, 487, DateTimeKind.Local).AddTicks(6248), new DateTime(2021, 12, 29, 13, 27, 31, 487, DateTimeKind.Local).AddTicks(4993), new DateTime(2021, 12, 29, 13, 27, 31, 487, DateTimeKind.Local).AddTicks(4702), new DateTime(2021, 12, 29, 13, 27, 31, 487, DateTimeKind.Local).AddTicks(6259) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 29, 13, 27, 31, 487, DateTimeKind.Local).AddTicks(6294), new DateTime(2021, 12, 29, 13, 27, 31, 487, DateTimeKind.Local).AddTicks(6287) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 13, 27, 31, 496, DateTimeKind.Local).AddTicks(7849), new DateTime(2021, 12, 29, 13, 27, 31, 496, DateTimeKind.Local).AddTicks(5441), new DateTime(2021, 12, 29, 13, 27, 31, 496, DateTimeKind.Local).AddTicks(6935), new DateTime(2021, 12, 29, 13, 27, 31, 496, DateTimeKind.Local).AddTicks(7860) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 13, 27, 31, 496, DateTimeKind.Local).AddTicks(8338), new DateTime(2021, 12, 29, 13, 27, 31, 496, DateTimeKind.Local).AddTicks(8247), new DateTime(2021, 12, 29, 13, 27, 31, 496, DateTimeKind.Local).AddTicks(8311), new DateTime(2021, 12, 29, 13, 27, 31, 496, DateTimeKind.Local).AddTicks(8342) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransferenciaDataRetornoPrevisto",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "TransferenciaDataRetornoRealizado",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "TransferenciaDataSaida",
                table: "Detentos");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransferenciaDataRetorno",
                table: "Detentos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 29, 12, 19, 42, 109, DateTimeKind.Local).AddTicks(5316), new DateTime(2021, 12, 29, 12, 19, 42, 109, DateTimeKind.Local).AddTicks(5159), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2021, 12, 29, 12, 19, 42, 109, DateTimeKind.Local).AddTicks(5319) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 29, 12, 19, 42, 109, DateTimeKind.Local).AddTicks(5114), new DateTime(2021, 12, 29, 12, 19, 42, 109, DateTimeKind.Local).AddTicks(766), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2021, 12, 29, 12, 19, 42, 109, DateTimeKind.Local).AddTicks(5127) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 12, 19, 42, 89, DateTimeKind.Local).AddTicks(1329), new DateTime(2021, 12, 29, 12, 19, 42, 89, DateTimeKind.Local).AddTicks(1352) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 12, 19, 42, 87, DateTimeKind.Local).AddTicks(9908), new DateTime(2021, 12, 29, 12, 19, 42, 89, DateTimeKind.Local).AddTicks(121) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 12, 19, 42, 113, DateTimeKind.Local).AddTicks(8205), new DateTime(2021, 12, 29, 12, 19, 42, 113, DateTimeKind.Local).AddTicks(8185), new DateTime(2021, 12, 29, 12, 19, 42, 113, DateTimeKind.Local).AddTicks(8208) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 12, 19, 42, 113, DateTimeKind.Local).AddTicks(7545), new DateTime(2021, 12, 29, 12, 19, 42, 113, DateTimeKind.Local).AddTicks(6595), new DateTime(2021, 12, 29, 12, 19, 42, 113, DateTimeKind.Local).AddTicks(7570) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 29, 12, 19, 42, 94, DateTimeKind.Local).AddTicks(1993), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 29, 12, 19, 42, 94, DateTimeKind.Local).AddTicks(2030) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 29, 12, 19, 42, 94, DateTimeKind.Local).AddTicks(2126), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 29, 12, 19, 42, 94, DateTimeKind.Local).AddTicks(2129) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 12, 19, 42, 97, DateTimeKind.Local).AddTicks(9205), new DateTime(2021, 12, 29, 12, 19, 42, 97, DateTimeKind.Local).AddTicks(9245) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 12, 19, 42, 97, DateTimeKind.Local).AddTicks(9394), new DateTime(2021, 12, 29, 12, 19, 42, 97, DateTimeKind.Local).AddTicks(9397) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 12, 19, 42, 102, DateTimeKind.Local).AddTicks(867), new DateTime(2021, 12, 29, 12, 19, 42, 101, DateTimeKind.Local).AddTicks(9142), new DateTime(2021, 12, 29, 12, 19, 42, 101, DateTimeKind.Local).AddTicks(8742), new DateTime(2021, 12, 29, 12, 19, 42, 102, DateTimeKind.Local).AddTicks(892) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 29, 12, 19, 42, 102, DateTimeKind.Local).AddTicks(979), new DateTime(2021, 12, 29, 12, 19, 42, 102, DateTimeKind.Local).AddTicks(969) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 12, 19, 42, 115, DateTimeKind.Local).AddTicks(8998), new DateTime(2021, 12, 29, 12, 19, 42, 115, DateTimeKind.Local).AddTicks(6472), new DateTime(2021, 12, 29, 12, 19, 42, 115, DateTimeKind.Local).AddTicks(7959), new DateTime(2021, 12, 29, 12, 19, 42, 115, DateTimeKind.Local).AddTicks(9011) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 12, 19, 42, 115, DateTimeKind.Local).AddTicks(9395), new DateTime(2021, 12, 29, 12, 19, 42, 115, DateTimeKind.Local).AddTicks(9287), new DateTime(2021, 12, 29, 12, 19, 42, 115, DateTimeKind.Local).AddTicks(9365), new DateTime(2021, 12, 29, 12, 19, 42, 115, DateTimeKind.Local).AddTicks(9398) });
        }
    }
}
