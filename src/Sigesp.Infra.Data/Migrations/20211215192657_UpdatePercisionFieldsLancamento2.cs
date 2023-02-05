using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class UpdatePercisionFieldsLancamento2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorLiquido",
                table: "Lancamentos",
                type: "decimal(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorBruto",
                table: "Lancamentos",
                type: "decimal(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,3)");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 15, 16, 26, 56, 207, DateTimeKind.Local).AddTicks(2297), new DateTime(2021, 12, 15, 16, 26, 56, 207, DateTimeKind.Local).AddTicks(2027), 25m, 33m, 5, "Fábrica do conveniado", 3, new DateTime(2021, 12, 15, 16, 26, 56, 207, DateTimeKind.Local).AddTicks(2306) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 15, 16, 26, 56, 207, DateTimeKind.Local).AddTicks(1957), new DateTime(2021, 12, 15, 16, 26, 56, 206, DateTimeKind.Local).AddTicks(2928), 25m, 33m, 10, "GALERIA", 2, new DateTime(2021, 12, 15, 16, 26, 56, 207, DateTimeKind.Local).AddTicks(1975) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 26, 56, 185, DateTimeKind.Local).AddTicks(5222), new DateTime(2021, 12, 15, 16, 26, 56, 185, DateTimeKind.Local).AddTicks(5243) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 26, 56, 184, DateTimeKind.Local).AddTicks(4026), new DateTime(2021, 12, 15, 16, 26, 56, 185, DateTimeKind.Local).AddTicks(4066) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 26, 56, 212, DateTimeKind.Local).AddTicks(127), new DateTime(2021, 12, 15, 16, 26, 56, 212, DateTimeKind.Local).AddTicks(109), new DateTime(2021, 12, 15, 16, 26, 56, 212, DateTimeKind.Local).AddTicks(131) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 26, 56, 211, DateTimeKind.Local).AddTicks(9649), new DateTime(2021, 12, 15, 16, 26, 56, 211, DateTimeKind.Local).AddTicks(8892), new DateTime(2021, 12, 15, 16, 26, 56, 211, DateTimeKind.Local).AddTicks(9665) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Situacao", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 15, 16, 26, 56, 192, DateTimeKind.Local).AddTicks(7361), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 15, 16, 26, 56, 192, DateTimeKind.Local).AddTicks(7398) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Situacao", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 15, 16, 26, 56, 192, DateTimeKind.Local).AddTicks(7514), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 15, 16, 26, 56, 192, DateTimeKind.Local).AddTicks(7517) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 26, 56, 196, DateTimeKind.Local).AddTicks(2941), new DateTime(2021, 12, 15, 16, 26, 56, 196, DateTimeKind.Local).AddTicks(2966) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 26, 56, 196, DateTimeKind.Local).AddTicks(3109), new DateTime(2021, 12, 15, 16, 26, 56, 196, DateTimeKind.Local).AddTicks(3112) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 26, 56, 199, DateTimeKind.Local).AddTicks(7718), new DateTime(2021, 12, 15, 16, 26, 56, 199, DateTimeKind.Local).AddTicks(6091), new DateTime(2021, 12, 15, 16, 26, 56, 199, DateTimeKind.Local).AddTicks(5709), new DateTime(2021, 12, 15, 16, 26, 56, 199, DateTimeKind.Local).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 26, 56, 199, DateTimeKind.Local).AddTicks(7776), new DateTime(2021, 12, 15, 16, 26, 56, 199, DateTimeKind.Local).AddTicks(7767) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 26, 56, 214, DateTimeKind.Local).AddTicks(8554), new DateTime(2021, 12, 15, 16, 26, 56, 214, DateTimeKind.Local).AddTicks(5307), new DateTime(2021, 12, 15, 16, 26, 56, 214, DateTimeKind.Local).AddTicks(7221), new DateTime(2021, 12, 15, 16, 26, 56, 214, DateTimeKind.Local).AddTicks(8570) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 26, 56, 214, DateTimeKind.Local).AddTicks(9080), new DateTime(2021, 12, 15, 16, 26, 56, 214, DateTimeKind.Local).AddTicks(8932), new DateTime(2021, 12, 15, 16, 26, 56, 214, DateTimeKind.Local).AddTicks(9043), new DateTime(2021, 12, 15, 16, 26, 56, 214, DateTimeKind.Local).AddTicks(9084) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorLiquido",
                table: "Lancamentos",
                type: "decimal(7,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorBruto",
                table: "Lancamentos",
                type: "decimal(7,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,3)");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 15, 16, 18, 57, 180, DateTimeKind.Local).AddTicks(2898), new DateTime(2021, 12, 15, 16, 18, 57, 180, DateTimeKind.Local).AddTicks(2689), 25m, 33m, 5, "Fábrica do conveniado", 3, new DateTime(2021, 12, 15, 16, 18, 57, 180, DateTimeKind.Local).AddTicks(2902) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 15, 16, 18, 57, 180, DateTimeKind.Local).AddTicks(2641), new DateTime(2021, 12, 15, 16, 18, 57, 179, DateTimeKind.Local).AddTicks(7564), 25m, 33m, 10, "GALERIA", 2, new DateTime(2021, 12, 15, 16, 18, 57, 180, DateTimeKind.Local).AddTicks(2649) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 18, 57, 160, DateTimeKind.Local).AddTicks(3510), new DateTime(2021, 12, 15, 16, 18, 57, 160, DateTimeKind.Local).AddTicks(3532) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 18, 57, 159, DateTimeKind.Local).AddTicks(2422), new DateTime(2021, 12, 15, 16, 18, 57, 160, DateTimeKind.Local).AddTicks(2413) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 18, 57, 183, DateTimeKind.Local).AddTicks(8733), new DateTime(2021, 12, 15, 16, 18, 57, 183, DateTimeKind.Local).AddTicks(8712), new DateTime(2021, 12, 15, 16, 18, 57, 183, DateTimeKind.Local).AddTicks(8737) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 18, 57, 183, DateTimeKind.Local).AddTicks(8290), new DateTime(2021, 12, 15, 16, 18, 57, 183, DateTimeKind.Local).AddTicks(7604), new DateTime(2021, 12, 15, 16, 18, 57, 183, DateTimeKind.Local).AddTicks(8304) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Situacao", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 15, 16, 18, 57, 167, DateTimeKind.Local).AddTicks(3610), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 15, 16, 18, 57, 167, DateTimeKind.Local).AddTicks(3648) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Situacao", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 15, 16, 18, 57, 167, DateTimeKind.Local).AddTicks(3771), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 15, 16, 18, 57, 167, DateTimeKind.Local).AddTicks(3774) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 18, 57, 170, DateTimeKind.Local).AddTicks(9982), new DateTime(2021, 12, 15, 16, 18, 57, 171, DateTimeKind.Local).AddTicks(11) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 18, 57, 171, DateTimeKind.Local).AddTicks(161), new DateTime(2021, 12, 15, 16, 18, 57, 171, DateTimeKind.Local).AddTicks(164) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 18, 57, 174, DateTimeKind.Local).AddTicks(4517), new DateTime(2021, 12, 15, 16, 18, 57, 174, DateTimeKind.Local).AddTicks(2902), new DateTime(2021, 12, 15, 16, 18, 57, 174, DateTimeKind.Local).AddTicks(2519), new DateTime(2021, 12, 15, 16, 18, 57, 174, DateTimeKind.Local).AddTicks(4530) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 18, 57, 174, DateTimeKind.Local).AddTicks(4578), new DateTime(2021, 12, 15, 16, 18, 57, 174, DateTimeKind.Local).AddTicks(4569) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 18, 57, 186, DateTimeKind.Local).AddTicks(5132), new DateTime(2021, 12, 15, 16, 18, 57, 186, DateTimeKind.Local).AddTicks(1572), new DateTime(2021, 12, 15, 16, 18, 57, 186, DateTimeKind.Local).AddTicks(3670), new DateTime(2021, 12, 15, 16, 18, 57, 186, DateTimeKind.Local).AddTicks(5147) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 16, 18, 57, 186, DateTimeKind.Local).AddTicks(5662), new DateTime(2021, 12, 15, 16, 18, 57, 186, DateTimeKind.Local).AddTicks(5522), new DateTime(2021, 12, 15, 16, 18, 57, 186, DateTimeKind.Local).AddTicks(5627), new DateTime(2021, 12, 15, 16, 18, 57, 186, DateTimeKind.Local).AddTicks(5666) });
        }
    }
}
