using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class UpdatePercisionFieldsLancamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorLiquido",
                table: "Lancamentos",
                type: "decimal(7,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorBruto",
                table: "Lancamentos",
                type: "decimal(7,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorLiquido",
                table: "Lancamentos",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorBruto",
                table: "Lancamentos",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,3)");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 15, 13, 57, 34, 234, DateTimeKind.Local).AddTicks(7623), new DateTime(2021, 12, 15, 13, 57, 34, 234, DateTimeKind.Local).AddTicks(7449), 25m, 33m, 5, "Fábrica do conveniado", 3, new DateTime(2021, 12, 15, 13, 57, 34, 234, DateTimeKind.Local).AddTicks(7627) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 15, 13, 57, 34, 234, DateTimeKind.Local).AddTicks(7245), new DateTime(2021, 12, 15, 13, 57, 34, 234, DateTimeKind.Local).AddTicks(1490), 25m, 33m, 10, "GALERIA", 2, new DateTime(2021, 12, 15, 13, 57, 34, 234, DateTimeKind.Local).AddTicks(7255) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 212, DateTimeKind.Local).AddTicks(8203), new DateTime(2021, 12, 15, 13, 57, 34, 212, DateTimeKind.Local).AddTicks(8232) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 211, DateTimeKind.Local).AddTicks(6841), new DateTime(2021, 12, 15, 13, 57, 34, 212, DateTimeKind.Local).AddTicks(7064) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 238, DateTimeKind.Local).AddTicks(6361), new DateTime(2021, 12, 15, 13, 57, 34, 238, DateTimeKind.Local).AddTicks(6342), new DateTime(2021, 12, 15, 13, 57, 34, 238, DateTimeKind.Local).AddTicks(6365) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 238, DateTimeKind.Local).AddTicks(5907), new DateTime(2021, 12, 15, 13, 57, 34, 238, DateTimeKind.Local).AddTicks(5200), new DateTime(2021, 12, 15, 13, 57, 34, 238, DateTimeKind.Local).AddTicks(5922) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Situacao", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 15, 13, 57, 34, 219, DateTimeKind.Local).AddTicks(7565), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 15, 13, 57, 34, 219, DateTimeKind.Local).AddTicks(7600) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Situacao", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 15, 13, 57, 34, 219, DateTimeKind.Local).AddTicks(7714), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 15, 13, 57, 34, 219, DateTimeKind.Local).AddTicks(7717) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 224, DateTimeKind.Local).AddTicks(7844), new DateTime(2021, 12, 15, 13, 57, 34, 224, DateTimeKind.Local).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 224, DateTimeKind.Local).AddTicks(8070), new DateTime(2021, 12, 15, 13, 57, 34, 224, DateTimeKind.Local).AddTicks(8074) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 228, DateTimeKind.Local).AddTicks(5051), new DateTime(2021, 12, 15, 13, 57, 34, 228, DateTimeKind.Local).AddTicks(3365), new DateTime(2021, 12, 15, 13, 57, 34, 228, DateTimeKind.Local).AddTicks(2968), new DateTime(2021, 12, 15, 13, 57, 34, 228, DateTimeKind.Local).AddTicks(5067) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 228, DateTimeKind.Local).AddTicks(5116), new DateTime(2021, 12, 15, 13, 57, 34, 228, DateTimeKind.Local).AddTicks(5107) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 241, DateTimeKind.Local).AddTicks(3417), new DateTime(2021, 12, 15, 13, 57, 34, 240, DateTimeKind.Local).AddTicks(9995), new DateTime(2021, 12, 15, 13, 57, 34, 241, DateTimeKind.Local).AddTicks(2102), new DateTime(2021, 12, 15, 13, 57, 34, 241, DateTimeKind.Local).AddTicks(3436) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 241, DateTimeKind.Local).AddTicks(3930), new DateTime(2021, 12, 15, 13, 57, 34, 241, DateTimeKind.Local).AddTicks(3794), new DateTime(2021, 12, 15, 13, 57, 34, 241, DateTimeKind.Local).AddTicks(3896), new DateTime(2021, 12, 15, 13, 57, 34, 241, DateTimeKind.Local).AddTicks(3933) });
        }
    }
}
