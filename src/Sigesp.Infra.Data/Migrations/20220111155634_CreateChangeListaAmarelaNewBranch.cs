using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeListaAmarelaNewBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAtivo",
                table: "ListaAmarela");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 11, 12, 56, 33, 501, DateTimeKind.Local).AddTicks(3058), new DateTime(2022, 1, 11, 12, 56, 33, 501, DateTimeKind.Local).AddTicks(2868), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2022, 1, 11, 12, 56, 33, 501, DateTimeKind.Local).AddTicks(3063) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2022, 1, 11, 12, 56, 33, 501, DateTimeKind.Local).AddTicks(2830), new DateTime(2022, 1, 11, 12, 56, 33, 500, DateTimeKind.Local).AddTicks(8576), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2022, 1, 11, 12, 56, 33, 501, DateTimeKind.Local).AddTicks(2838) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 12, 56, 33, 484, DateTimeKind.Local).AddTicks(3583), new DateTime(2022, 1, 11, 12, 56, 33, 484, DateTimeKind.Local).AddTicks(3604) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 12, 56, 33, 483, DateTimeKind.Local).AddTicks(4051), new DateTime(2022, 1, 11, 12, 56, 33, 484, DateTimeKind.Local).AddTicks(2673) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 12, 56, 33, 504, DateTimeKind.Local).AddTicks(1152), new DateTime(2022, 1, 11, 12, 56, 33, 504, DateTimeKind.Local).AddTicks(1134), new DateTime(2022, 1, 11, 12, 56, 33, 504, DateTimeKind.Local).AddTicks(1155) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 12, 56, 33, 504, DateTimeKind.Local).AddTicks(761), new DateTime(2022, 1, 11, 12, 56, 33, 504, DateTimeKind.Local).AddTicks(180), new DateTime(2022, 1, 11, 12, 56, 33, 504, DateTimeKind.Local).AddTicks(774) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2022, 1, 11, 12, 56, 33, 489, DateTimeKind.Local).AddTicks(3078), true, "Maria de Lourdes", 7, new DateTime(2022, 1, 11, 12, 56, 33, 489, DateTimeKind.Local).AddTicks(3137) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2022, 1, 11, 12, 56, 33, 489, DateTimeKind.Local).AddTicks(3231), true, "Carlos Amarildo de Souza", 8, new DateTime(2022, 1, 11, 12, 56, 33, 489, DateTimeKind.Local).AddTicks(3235) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 12, 56, 33, 492, DateTimeKind.Local).AddTicks(6463), new DateTime(2022, 1, 11, 12, 56, 33, 492, DateTimeKind.Local).AddTicks(6491) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 12, 56, 33, 492, DateTimeKind.Local).AddTicks(6628), new DateTime(2022, 1, 11, 12, 56, 33, 492, DateTimeKind.Local).AddTicks(6632) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 12, 56, 33, 495, DateTimeKind.Local).AddTicks(5979), new DateTime(2022, 1, 11, 12, 56, 33, 495, DateTimeKind.Local).AddTicks(4620), new DateTime(2022, 1, 11, 12, 56, 33, 495, DateTimeKind.Local).AddTicks(4291), new DateTime(2022, 1, 11, 12, 56, 33, 495, DateTimeKind.Local).AddTicks(5990) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2022, 1, 11, 12, 56, 33, 495, DateTimeKind.Local).AddTicks(6031), new DateTime(2022, 1, 11, 12, 56, 33, 495, DateTimeKind.Local).AddTicks(6024) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 12, 56, 33, 506, DateTimeKind.Local).AddTicks(7506), new DateTime(2022, 1, 11, 12, 56, 33, 506, DateTimeKind.Local).AddTicks(4878), new DateTime(2022, 1, 11, 12, 56, 33, 506, DateTimeKind.Local).AddTicks(6482), new DateTime(2022, 1, 11, 12, 56, 33, 506, DateTimeKind.Local).AddTicks(7520) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 12, 56, 33, 506, DateTimeKind.Local).AddTicks(7927), new DateTime(2022, 1, 11, 12, 56, 33, 506, DateTimeKind.Local).AddTicks(7806), new DateTime(2022, 1, 11, 12, 56, 33, 506, DateTimeKind.Local).AddTicks(7895), new DateTime(2022, 1, 11, 12, 56, 33, 506, DateTimeKind.Local).AddTicks(7931) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAtivo",
                table: "ListaAmarela",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 4, 17, 41, 42, 865, DateTimeKind.Local).AddTicks(6303), new DateTime(2022, 1, 4, 17, 41, 42, 865, DateTimeKind.Local).AddTicks(6148), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2022, 1, 4, 17, 41, 42, 865, DateTimeKind.Local).AddTicks(6306) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2022, 1, 4, 17, 41, 42, 865, DateTimeKind.Local).AddTicks(6082), new DateTime(2022, 1, 4, 17, 41, 42, 864, DateTimeKind.Local).AddTicks(8899), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2022, 1, 4, 17, 41, 42, 865, DateTimeKind.Local).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 17, 41, 42, 848, DateTimeKind.Local).AddTicks(8776), new DateTime(2022, 1, 4, 17, 41, 42, 848, DateTimeKind.Local).AddTicks(8797) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 17, 41, 42, 847, DateTimeKind.Local).AddTicks(9263), new DateTime(2022, 1, 4, 17, 41, 42, 848, DateTimeKind.Local).AddTicks(7868) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 17, 41, 42, 868, DateTimeKind.Local).AddTicks(6070), new DateTime(2022, 1, 4, 17, 41, 42, 868, DateTimeKind.Local).AddTicks(6053), new DateTime(2022, 1, 4, 17, 41, 42, 868, DateTimeKind.Local).AddTicks(6073) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 17, 41, 42, 868, DateTimeKind.Local).AddTicks(5698), new DateTime(2022, 1, 4, 17, 41, 42, 868, DateTimeKind.Local).AddTicks(5124), new DateTime(2022, 1, 4, 17, 41, 42, 868, DateTimeKind.Local).AddTicks(5711) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2022, 1, 4, 17, 41, 42, 853, DateTimeKind.Local).AddTicks(9242), true, "Maria de Lourdes", 7, new DateTime(2022, 1, 4, 17, 41, 42, 853, DateTimeKind.Local).AddTicks(9273) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2022, 1, 4, 17, 41, 42, 853, DateTimeKind.Local).AddTicks(9366), true, "Carlos Amarildo de Souza", 8, new DateTime(2022, 1, 4, 17, 41, 42, 853, DateTimeKind.Local).AddTicks(9370) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 17, 41, 42, 857, DateTimeKind.Local).AddTicks(523), new DateTime(2022, 1, 4, 17, 41, 42, 857, DateTimeKind.Local).AddTicks(553) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 17, 41, 42, 857, DateTimeKind.Local).AddTicks(689), new DateTime(2022, 1, 4, 17, 41, 42, 857, DateTimeKind.Local).AddTicks(692) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 17, 41, 42, 859, DateTimeKind.Local).AddTicks(9226), new DateTime(2022, 1, 4, 17, 41, 42, 859, DateTimeKind.Local).AddTicks(7796), new DateTime(2022, 1, 4, 17, 41, 42, 859, DateTimeKind.Local).AddTicks(7460), new DateTime(2022, 1, 4, 17, 41, 42, 859, DateTimeKind.Local).AddTicks(9239) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2022, 1, 4, 17, 41, 42, 859, DateTimeKind.Local).AddTicks(9277), new DateTime(2022, 1, 4, 17, 41, 42, 859, DateTimeKind.Local).AddTicks(9269) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 17, 41, 42, 870, DateTimeKind.Local).AddTicks(9572), new DateTime(2022, 1, 4, 17, 41, 42, 870, DateTimeKind.Local).AddTicks(7042), new DateTime(2022, 1, 4, 17, 41, 42, 870, DateTimeKind.Local).AddTicks(8582), new DateTime(2022, 1, 4, 17, 41, 42, 870, DateTimeKind.Local).AddTicks(9584) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 17, 41, 42, 870, DateTimeKind.Local).AddTicks(9978), new DateTime(2022, 1, 4, 17, 41, 42, 870, DateTimeKind.Local).AddTicks(9869), new DateTime(2022, 1, 4, 17, 41, 42, 870, DateTimeKind.Local).AddTicks(9946), new DateTime(2022, 1, 4, 17, 41, 42, 870, DateTimeKind.Local).AddTicks(9982) });
        }
    }
}
