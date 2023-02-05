using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeScaleFieldDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorLiquido",
                table: "Lancamentos",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorBruto",
                table: "Lancamentos",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,3)");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 21, 8, 24, 50, 409, DateTimeKind.Local).AddTicks(5870), new DateTime(2021, 12, 21, 8, 24, 50, 409, DateTimeKind.Local).AddTicks(5705), 25m, 33m, 5, "Fábrica do conveniado", 3, new DateTime(2021, 12, 21, 8, 24, 50, 409, DateTimeKind.Local).AddTicks(5873) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 21, 8, 24, 50, 409, DateTimeKind.Local).AddTicks(5653), new DateTime(2021, 12, 21, 8, 24, 50, 408, DateTimeKind.Local).AddTicks(9421), 25m, 33m, 10, "GALERIA", 2, new DateTime(2021, 12, 21, 8, 24, 50, 409, DateTimeKind.Local).AddTicks(5663) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 8, 24, 50, 389, DateTimeKind.Local).AddTicks(4467), new DateTime(2021, 12, 21, 8, 24, 50, 389, DateTimeKind.Local).AddTicks(4490) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 8, 24, 50, 388, DateTimeKind.Local).AddTicks(2380), new DateTime(2021, 12, 21, 8, 24, 50, 389, DateTimeKind.Local).AddTicks(3221) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 8, 24, 50, 412, DateTimeKind.Local).AddTicks(8006), new DateTime(2021, 12, 21, 8, 24, 50, 412, DateTimeKind.Local).AddTicks(7985), new DateTime(2021, 12, 21, 8, 24, 50, 412, DateTimeKind.Local).AddTicks(8009) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 8, 24, 50, 412, DateTimeKind.Local).AddTicks(7522), new DateTime(2021, 12, 21, 8, 24, 50, 412, DateTimeKind.Local).AddTicks(6796), new DateTime(2021, 12, 21, 8, 24, 50, 412, DateTimeKind.Local).AddTicks(7535) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Situacao", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 21, 8, 24, 50, 394, DateTimeKind.Local).AddTicks(3991), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 21, 8, 24, 50, 394, DateTimeKind.Local).AddTicks(4016) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Situacao", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 21, 8, 24, 50, 394, DateTimeKind.Local).AddTicks(4139), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 21, 8, 24, 50, 394, DateTimeKind.Local).AddTicks(4143) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 8, 24, 50, 398, DateTimeKind.Local).AddTicks(1917), new DateTime(2021, 12, 21, 8, 24, 50, 398, DateTimeKind.Local).AddTicks(1944) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 8, 24, 50, 398, DateTimeKind.Local).AddTicks(2095), new DateTime(2021, 12, 21, 8, 24, 50, 398, DateTimeKind.Local).AddTicks(2099) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 8, 24, 50, 402, DateTimeKind.Local).AddTicks(2926), new DateTime(2021, 12, 21, 8, 24, 50, 401, DateTimeKind.Local).AddTicks(6953), new DateTime(2021, 12, 21, 8, 24, 50, 401, DateTimeKind.Local).AddTicks(6546), new DateTime(2021, 12, 21, 8, 24, 50, 402, DateTimeKind.Local).AddTicks(2955) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 21, 8, 24, 50, 402, DateTimeKind.Local).AddTicks(3013), new DateTime(2021, 12, 21, 8, 24, 50, 402, DateTimeKind.Local).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 8, 24, 50, 415, DateTimeKind.Local).AddTicks(4397), new DateTime(2021, 12, 21, 8, 24, 50, 415, DateTimeKind.Local).AddTicks(617), new DateTime(2021, 12, 21, 8, 24, 50, 415, DateTimeKind.Local).AddTicks(2851), new DateTime(2021, 12, 21, 8, 24, 50, 415, DateTimeKind.Local).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 8, 24, 50, 415, DateTimeKind.Local).AddTicks(4918), new DateTime(2021, 12, 21, 8, 24, 50, 415, DateTimeKind.Local).AddTicks(4797), new DateTime(2021, 12, 21, 8, 24, 50, 415, DateTimeKind.Local).AddTicks(4882), new DateTime(2021, 12, 21, 8, 24, 50, 415, DateTimeKind.Local).AddTicks(4921) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorLiquido",
                table: "Lancamentos",
                type: "decimal(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorBruto",
                table: "Lancamentos",
                type: "decimal(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 17, 18, 5, 42, 169, DateTimeKind.Local).AddTicks(4330), new DateTime(2021, 12, 17, 18, 5, 42, 169, DateTimeKind.Local).AddTicks(4108), 25m, 33m, 5, "Fábrica do conveniado", 3, new DateTime(2021, 12, 17, 18, 5, 42, 169, DateTimeKind.Local).AddTicks(4335) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 17, 18, 5, 42, 169, DateTimeKind.Local).AddTicks(4038), new DateTime(2021, 12, 17, 18, 5, 42, 168, DateTimeKind.Local).AddTicks(8541), 25m, 33m, 10, "GALERIA", 2, new DateTime(2021, 12, 17, 18, 5, 42, 169, DateTimeKind.Local).AddTicks(4059) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 18, 5, 42, 109, DateTimeKind.Local).AddTicks(8119), new DateTime(2021, 12, 17, 18, 5, 42, 109, DateTimeKind.Local).AddTicks(8141) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 18, 5, 42, 108, DateTimeKind.Local).AddTicks(6484), new DateTime(2021, 12, 17, 18, 5, 42, 109, DateTimeKind.Local).AddTicks(7204) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 18, 5, 42, 174, DateTimeKind.Local).AddTicks(6844), new DateTime(2021, 12, 17, 18, 5, 42, 174, DateTimeKind.Local).AddTicks(6812), new DateTime(2021, 12, 17, 18, 5, 42, 174, DateTimeKind.Local).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 18, 5, 42, 174, DateTimeKind.Local).AddTicks(6314), new DateTime(2021, 12, 17, 18, 5, 42, 174, DateTimeKind.Local).AddTicks(5563), new DateTime(2021, 12, 17, 18, 5, 42, 174, DateTimeKind.Local).AddTicks(6335) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Situacao", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 17, 18, 5, 42, 115, DateTimeKind.Local).AddTicks(1588), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 17, 18, 5, 42, 115, DateTimeKind.Local).AddTicks(1636) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Situacao", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 17, 18, 5, 42, 115, DateTimeKind.Local).AddTicks(1786), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 17, 18, 5, 42, 115, DateTimeKind.Local).AddTicks(1794) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 18, 5, 42, 143, DateTimeKind.Local).AddTicks(8945), new DateTime(2021, 12, 17, 18, 5, 42, 143, DateTimeKind.Local).AddTicks(8994) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 18, 5, 42, 143, DateTimeKind.Local).AddTicks(9191), new DateTime(2021, 12, 17, 18, 5, 42, 143, DateTimeKind.Local).AddTicks(9197) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 18, 5, 42, 151, DateTimeKind.Local).AddTicks(9327), new DateTime(2021, 12, 17, 18, 5, 42, 151, DateTimeKind.Local).AddTicks(7569), new DateTime(2021, 12, 17, 18, 5, 42, 151, DateTimeKind.Local).AddTicks(7147), new DateTime(2021, 12, 17, 18, 5, 42, 151, DateTimeKind.Local).AddTicks(9345) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 17, 18, 5, 42, 151, DateTimeKind.Local).AddTicks(9409), new DateTime(2021, 12, 17, 18, 5, 42, 151, DateTimeKind.Local).AddTicks(9396) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 18, 5, 42, 178, DateTimeKind.Local).AddTicks(4629), new DateTime(2021, 12, 17, 18, 5, 42, 178, DateTimeKind.Local).AddTicks(969), new DateTime(2021, 12, 17, 18, 5, 42, 178, DateTimeKind.Local).AddTicks(3080), new DateTime(2021, 12, 17, 18, 5, 42, 178, DateTimeKind.Local).AddTicks(4651) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 18, 5, 42, 178, DateTimeKind.Local).AddTicks(5376), new DateTime(2021, 12, 17, 18, 5, 42, 178, DateTimeKind.Local).AddTicks(5192), new DateTime(2021, 12, 17, 18, 5, 42, 178, DateTimeKind.Local).AddTicks(5324), new DateTime(2021, 12, 17, 18, 5, 42, 178, DateTimeKind.Local).AddTicks(5383) });
        }
    }
}
