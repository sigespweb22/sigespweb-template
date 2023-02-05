using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesColaborador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Remuneracao",
                table: "Colaboradores",
                type: "decimal(7,3)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,3)");

            migrationBuilder.AlterColumn<int>(
                name: "DiaPagamento",
                table: "Colaboradores",
                maxLength: 2,
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "DescontoOutro",
                table: "Colaboradores",
                type: "decimal(4,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Desconto",
                table: "Colaboradores",
                type: "decimal(4,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");

            migrationBuilder.AlterColumn<int>(
                name: "BancoNumero",
                table: "Colaboradores",
                maxLength: 25,
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 25);

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 27, 10, 46, 54, 403, DateTimeKind.Local).AddTicks(8489), new DateTime(2021, 12, 27, 10, 46, 54, 403, DateTimeKind.Local).AddTicks(8318), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2021, 12, 27, 10, 46, 54, 403, DateTimeKind.Local).AddTicks(8493) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 27, 10, 46, 54, 403, DateTimeKind.Local).AddTicks(8269), new DateTime(2021, 12, 27, 10, 46, 54, 403, DateTimeKind.Local).AddTicks(2557), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2021, 12, 27, 10, 46, 54, 403, DateTimeKind.Local).AddTicks(8278) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 10, 46, 54, 384, DateTimeKind.Local).AddTicks(7883), new DateTime(2021, 12, 27, 10, 46, 54, 384, DateTimeKind.Local).AddTicks(7908) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 10, 46, 54, 383, DateTimeKind.Local).AddTicks(5937), new DateTime(2021, 12, 27, 10, 46, 54, 384, DateTimeKind.Local).AddTicks(6691) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 10, 46, 54, 407, DateTimeKind.Local).AddTicks(4633), new DateTime(2021, 12, 27, 10, 46, 54, 407, DateTimeKind.Local).AddTicks(4609), new DateTime(2021, 12, 27, 10, 46, 54, 407, DateTimeKind.Local).AddTicks(4636) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 10, 46, 54, 407, DateTimeKind.Local).AddTicks(4123), new DateTime(2021, 12, 27, 10, 46, 54, 407, DateTimeKind.Local).AddTicks(3242), new DateTime(2021, 12, 27, 10, 46, 54, 407, DateTimeKind.Local).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 27, 10, 46, 54, 389, DateTimeKind.Local).AddTicks(7151), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 27, 10, 46, 54, 389, DateTimeKind.Local).AddTicks(7184) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 27, 10, 46, 54, 389, DateTimeKind.Local).AddTicks(7301), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 27, 10, 46, 54, 389, DateTimeKind.Local).AddTicks(7304) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 10, 46, 54, 393, DateTimeKind.Local).AddTicks(5069), new DateTime(2021, 12, 27, 10, 46, 54, 393, DateTimeKind.Local).AddTicks(5101) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 10, 46, 54, 393, DateTimeKind.Local).AddTicks(5250), new DateTime(2021, 12, 27, 10, 46, 54, 393, DateTimeKind.Local).AddTicks(5254) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 10, 46, 54, 397, DateTimeKind.Local).AddTicks(3519), new DateTime(2021, 12, 27, 10, 46, 54, 397, DateTimeKind.Local).AddTicks(1718), new DateTime(2021, 12, 27, 10, 46, 54, 397, DateTimeKind.Local).AddTicks(1310), new DateTime(2021, 12, 27, 10, 46, 54, 397, DateTimeKind.Local).AddTicks(3534) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 27, 10, 46, 54, 397, DateTimeKind.Local).AddTicks(3585), new DateTime(2021, 12, 27, 10, 46, 54, 397, DateTimeKind.Local).AddTicks(3575) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 10, 46, 54, 410, DateTimeKind.Local).AddTicks(879), new DateTime(2021, 12, 27, 10, 46, 54, 409, DateTimeKind.Local).AddTicks(7533), new DateTime(2021, 12, 27, 10, 46, 54, 409, DateTimeKind.Local).AddTicks(9541), new DateTime(2021, 12, 27, 10, 46, 54, 410, DateTimeKind.Local).AddTicks(894) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 27, 10, 46, 54, 410, DateTimeKind.Local).AddTicks(1595), new DateTime(2021, 12, 27, 10, 46, 54, 410, DateTimeKind.Local).AddTicks(1265), new DateTime(2021, 12, 27, 10, 46, 54, 410, DateTimeKind.Local).AddTicks(1554), new DateTime(2021, 12, 27, 10, 46, 54, 410, DateTimeKind.Local).AddTicks(1599) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Remuneracao",
                table: "Colaboradores",
                type: "decimal(7,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,3)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "DiaPagamento",
                table: "Colaboradores",
                type: "integer",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 2,
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "DescontoOutro",
                table: "Colaboradores",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Desconto",
                table: "Colaboradores",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "BancoNumero",
                table: "Colaboradores",
                type: "integer",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 25,
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 23, 13, 48, 46, 231, DateTimeKind.Local).AddTicks(2517), new DateTime(2021, 12, 23, 13, 48, 46, 231, DateTimeKind.Local).AddTicks(2366), 25m, 33m, 5, "Fábrica do conveniado", 3, new DateTime(2021, 12, 23, 13, 48, 46, 231, DateTimeKind.Local).AddTicks(2520) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 23, 13, 48, 46, 231, DateTimeKind.Local).AddTicks(2325), new DateTime(2021, 12, 23, 13, 48, 46, 230, DateTimeKind.Local).AddTicks(8083), 25m, 33m, 10, "GALERIA", 2, new DateTime(2021, 12, 23, 13, 48, 46, 231, DateTimeKind.Local).AddTicks(2335) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 23, 13, 48, 46, 215, DateTimeKind.Local).AddTicks(5586), new DateTime(2021, 12, 23, 13, 48, 46, 215, DateTimeKind.Local).AddTicks(5607) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 23, 13, 48, 46, 214, DateTimeKind.Local).AddTicks(5957), new DateTime(2021, 12, 23, 13, 48, 46, 215, DateTimeKind.Local).AddTicks(4691) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 23, 13, 48, 46, 234, DateTimeKind.Local).AddTicks(603), new DateTime(2021, 12, 23, 13, 48, 46, 234, DateTimeKind.Local).AddTicks(586), new DateTime(2021, 12, 23, 13, 48, 46, 234, DateTimeKind.Local).AddTicks(607) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 23, 13, 48, 46, 234, DateTimeKind.Local).AddTicks(248), new DateTime(2021, 12, 23, 13, 48, 46, 233, DateTimeKind.Local).AddTicks(9710), new DateTime(2021, 12, 23, 13, 48, 46, 234, DateTimeKind.Local).AddTicks(259) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 23, 13, 48, 46, 219, DateTimeKind.Local).AddTicks(6373), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 23, 13, 48, 46, 219, DateTimeKind.Local).AddTicks(6404) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 23, 13, 48, 46, 219, DateTimeKind.Local).AddTicks(6495), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 23, 13, 48, 46, 219, DateTimeKind.Local).AddTicks(6499) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 23, 13, 48, 46, 223, DateTimeKind.Local).AddTicks(685), new DateTime(2021, 12, 23, 13, 48, 46, 223, DateTimeKind.Local).AddTicks(716) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 23, 13, 48, 46, 223, DateTimeKind.Local).AddTicks(851), new DateTime(2021, 12, 23, 13, 48, 46, 223, DateTimeKind.Local).AddTicks(855) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 23, 13, 48, 46, 226, DateTimeKind.Local).AddTicks(1162), new DateTime(2021, 12, 23, 13, 48, 46, 225, DateTimeKind.Local).AddTicks(9848), new DateTime(2021, 12, 23, 13, 48, 46, 225, DateTimeKind.Local).AddTicks(9531), new DateTime(2021, 12, 23, 13, 48, 46, 226, DateTimeKind.Local).AddTicks(1174) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 23, 13, 48, 46, 226, DateTimeKind.Local).AddTicks(1213), new DateTime(2021, 12, 23, 13, 48, 46, 226, DateTimeKind.Local).AddTicks(1204) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 23, 13, 48, 46, 236, DateTimeKind.Local).AddTicks(2211), new DateTime(2021, 12, 23, 13, 48, 46, 235, DateTimeKind.Local).AddTicks(9705), new DateTime(2021, 12, 23, 13, 48, 46, 236, DateTimeKind.Local).AddTicks(1201), new DateTime(2021, 12, 23, 13, 48, 46, 236, DateTimeKind.Local).AddTicks(2223) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 23, 13, 48, 46, 236, DateTimeKind.Local).AddTicks(2628), new DateTime(2021, 12, 23, 13, 48, 46, 236, DateTimeKind.Local).AddTicks(2501), new DateTime(2021, 12, 23, 13, 48, 46, 236, DateTimeKind.Local).AddTicks(2570), new DateTime(2021, 12, 23, 13, 48, 46, 236, DateTimeKind.Local).AddTicks(2632) });
        }
    }
}
