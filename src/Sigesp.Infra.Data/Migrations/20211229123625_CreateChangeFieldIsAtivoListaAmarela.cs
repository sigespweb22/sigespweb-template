using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeFieldIsAtivoListaAmarela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsAtivo",
                table: "ListaAmarela",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsAtivo",
                table: "ListaAmarela",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 29, 9, 7, 54, 704, DateTimeKind.Local).AddTicks(692), new DateTime(2021, 12, 29, 9, 7, 54, 704, DateTimeKind.Local).AddTicks(554), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2021, 12, 29, 9, 7, 54, 704, DateTimeKind.Local).AddTicks(695) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 29, 9, 7, 54, 704, DateTimeKind.Local).AddTicks(516), new DateTime(2021, 12, 29, 9, 7, 54, 703, DateTimeKind.Local).AddTicks(6365), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2021, 12, 29, 9, 7, 54, 704, DateTimeKind.Local).AddTicks(523) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 7, 54, 689, DateTimeKind.Local).AddTicks(4877), new DateTime(2021, 12, 29, 9, 7, 54, 689, DateTimeKind.Local).AddTicks(4898) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 7, 54, 688, DateTimeKind.Local).AddTicks(6649), new DateTime(2021, 12, 29, 9, 7, 54, 689, DateTimeKind.Local).AddTicks(4022) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 7, 54, 706, DateTimeKind.Local).AddTicks(5608), new DateTime(2021, 12, 29, 9, 7, 54, 706, DateTimeKind.Local).AddTicks(5593), new DateTime(2021, 12, 29, 9, 7, 54, 706, DateTimeKind.Local).AddTicks(5612) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 7, 54, 706, DateTimeKind.Local).AddTicks(5271), new DateTime(2021, 12, 29, 9, 7, 54, 706, DateTimeKind.Local).AddTicks(4771), new DateTime(2021, 12, 29, 9, 7, 54, 706, DateTimeKind.Local).AddTicks(5281) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 29, 9, 7, 54, 693, DateTimeKind.Local).AddTicks(6924), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 29, 9, 7, 54, 693, DateTimeKind.Local).AddTicks(6942) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 29, 9, 7, 54, 693, DateTimeKind.Local).AddTicks(7028), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 29, 9, 7, 54, 693, DateTimeKind.Local).AddTicks(7032) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 7, 54, 696, DateTimeKind.Local).AddTicks(5152), new DateTime(2021, 12, 29, 9, 7, 54, 696, DateTimeKind.Local).AddTicks(5168) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 7, 54, 696, DateTimeKind.Local).AddTicks(5278), new DateTime(2021, 12, 29, 9, 7, 54, 696, DateTimeKind.Local).AddTicks(5282) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 7, 54, 699, DateTimeKind.Local).AddTicks(1784), new DateTime(2021, 12, 29, 9, 7, 54, 699, DateTimeKind.Local).AddTicks(492), new DateTime(2021, 12, 29, 9, 7, 54, 699, DateTimeKind.Local).AddTicks(198), new DateTime(2021, 12, 29, 9, 7, 54, 699, DateTimeKind.Local).AddTicks(1795) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 7, 54, 699, DateTimeKind.Local).AddTicks(1827), new DateTime(2021, 12, 29, 9, 7, 54, 699, DateTimeKind.Local).AddTicks(1821) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 7, 54, 708, DateTimeKind.Local).AddTicks(6022), new DateTime(2021, 12, 29, 9, 7, 54, 708, DateTimeKind.Local).AddTicks(3587), new DateTime(2021, 12, 29, 9, 7, 54, 708, DateTimeKind.Local).AddTicks(5101), new DateTime(2021, 12, 29, 9, 7, 54, 708, DateTimeKind.Local).AddTicks(6033) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 7, 54, 708, DateTimeKind.Local).AddTicks(6418), new DateTime(2021, 12, 29, 9, 7, 54, 708, DateTimeKind.Local).AddTicks(6304), new DateTime(2021, 12, 29, 9, 7, 54, 708, DateTimeKind.Local).AddTicks(6390), new DateTime(2021, 12, 29, 9, 7, 54, 708, DateTimeKind.Local).AddTicks(6422) });
        }
    }
}
