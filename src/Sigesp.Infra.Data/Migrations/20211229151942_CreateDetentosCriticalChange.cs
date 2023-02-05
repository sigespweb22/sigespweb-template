using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateDetentosCriticalChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalTransferencia",
                table: "Detentos");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransferenciaDataRetorno",
                table: "Detentos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TransferenciaLocal",
                table: "Detentos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransferenciaTipo",
                table: "Detentos",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransferenciaDataRetorno",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "TransferenciaLocal",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "TransferenciaTipo",
                table: "Detentos");

            migrationBuilder.AddColumn<string>(
                name: "LocalTransferencia",
                table: "Detentos",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 29, 9, 36, 25, 91, DateTimeKind.Local).AddTicks(9777), new DateTime(2021, 12, 29, 9, 36, 25, 91, DateTimeKind.Local).AddTicks(9622), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2021, 12, 29, 9, 36, 25, 91, DateTimeKind.Local).AddTicks(9780) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 29, 9, 36, 25, 91, DateTimeKind.Local).AddTicks(9583), new DateTime(2021, 12, 29, 9, 36, 25, 91, DateTimeKind.Local).AddTicks(5359), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2021, 12, 29, 9, 36, 25, 91, DateTimeKind.Local).AddTicks(9592) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 36, 25, 75, DateTimeKind.Local).AddTicks(8310), new DateTime(2021, 12, 29, 9, 36, 25, 75, DateTimeKind.Local).AddTicks(8329) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 36, 25, 74, DateTimeKind.Local).AddTicks(9929), new DateTime(2021, 12, 29, 9, 36, 25, 75, DateTimeKind.Local).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 36, 25, 94, DateTimeKind.Local).AddTicks(7599), new DateTime(2021, 12, 29, 9, 36, 25, 94, DateTimeKind.Local).AddTicks(7583), new DateTime(2021, 12, 29, 9, 36, 25, 94, DateTimeKind.Local).AddTicks(7602) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 36, 25, 94, DateTimeKind.Local).AddTicks(7253), new DateTime(2021, 12, 29, 9, 36, 25, 94, DateTimeKind.Local).AddTicks(6732), new DateTime(2021, 12, 29, 9, 36, 25, 94, DateTimeKind.Local).AddTicks(7263) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 29, 9, 36, 25, 80, DateTimeKind.Local).AddTicks(485), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 29, 9, 36, 25, 80, DateTimeKind.Local).AddTicks(507) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 29, 9, 36, 25, 80, DateTimeKind.Local).AddTicks(589), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 29, 9, 36, 25, 80, DateTimeKind.Local).AddTicks(592) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 36, 25, 82, DateTimeKind.Local).AddTicks(9287), new DateTime(2021, 12, 29, 9, 36, 25, 82, DateTimeKind.Local).AddTicks(9306) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 36, 25, 82, DateTimeKind.Local).AddTicks(9430), new DateTime(2021, 12, 29, 9, 36, 25, 82, DateTimeKind.Local).AddTicks(9432) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 36, 25, 86, DateTimeKind.Local).AddTicks(4660), new DateTime(2021, 12, 29, 9, 36, 25, 86, DateTimeKind.Local).AddTicks(3334), new DateTime(2021, 12, 29, 9, 36, 25, 86, DateTimeKind.Local).AddTicks(2996), new DateTime(2021, 12, 29, 9, 36, 25, 86, DateTimeKind.Local).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 36, 25, 86, DateTimeKind.Local).AddTicks(4714), new DateTime(2021, 12, 29, 9, 36, 25, 86, DateTimeKind.Local).AddTicks(4706) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 36, 25, 96, DateTimeKind.Local).AddTicks(9425), new DateTime(2021, 12, 29, 9, 36, 25, 96, DateTimeKind.Local).AddTicks(6922), new DateTime(2021, 12, 29, 9, 36, 25, 96, DateTimeKind.Local).AddTicks(8496), new DateTime(2021, 12, 29, 9, 36, 25, 96, DateTimeKind.Local).AddTicks(9435) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 36, 25, 96, DateTimeKind.Local).AddTicks(9804), new DateTime(2021, 12, 29, 9, 36, 25, 96, DateTimeKind.Local).AddTicks(9704), new DateTime(2021, 12, 29, 9, 36, 25, 96, DateTimeKind.Local).AddTicks(9773), new DateTime(2021, 12, 29, 9, 36, 25, 96, DateTimeKind.Local).AddTicks(9806) });
        }
    }
}
