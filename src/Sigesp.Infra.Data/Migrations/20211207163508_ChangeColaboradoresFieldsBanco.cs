using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class ChangeColaboradoresFieldsBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BancoConta",
                table: "Colaboradores",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BancoAgencia",
                table: "Colaboradores",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 35, 7, 896, DateTimeKind.Local).AddTicks(4610), new DateTime(2021, 12, 7, 13, 35, 7, 896, DateTimeKind.Local).AddTicks(4243), new DateTime(2021, 12, 7, 13, 35, 7, 896, DateTimeKind.Local).AddTicks(4618) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 35, 7, 896, DateTimeKind.Local).AddTicks(4120), new DateTime(2021, 12, 7, 13, 35, 7, 895, DateTimeKind.Local).AddTicks(2458), new DateTime(2021, 12, 7, 13, 35, 7, 896, DateTimeKind.Local).AddTicks(4163) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 35, 7, 902, DateTimeKind.Local).AddTicks(9055), new DateTime(2021, 12, 7, 13, 35, 7, 902, DateTimeKind.Local).AddTicks(9013), new DateTime(2021, 12, 7, 13, 35, 7, 902, DateTimeKind.Local).AddTicks(9059) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 35, 7, 902, DateTimeKind.Local).AddTicks(8554), new DateTime(2021, 12, 7, 13, 35, 7, 902, DateTimeKind.Local).AddTicks(7845), new DateTime(2021, 12, 7, 13, 35, 7, 902, DateTimeKind.Local).AddTicks(8571) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 35, 7, 878, DateTimeKind.Local).AddTicks(7664), "Maria de Lourdes", new DateTime(2021, 12, 7, 13, 35, 7, 881, DateTimeKind.Local).AddTicks(5424) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 35, 7, 881, DateTimeKind.Local).AddTicks(6420), "Carlos Amarildo de Souza", new DateTime(2021, 12, 7, 13, 35, 7, 881, DateTimeKind.Local).AddTicks(6445) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 35, 7, 885, DateTimeKind.Local).AddTicks(9761), new DateTime(2021, 12, 7, 13, 35, 7, 885, DateTimeKind.Local).AddTicks(9794) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 35, 7, 885, DateTimeKind.Local).AddTicks(9972), new DateTime(2021, 12, 7, 13, 35, 7, 885, DateTimeKind.Local).AddTicks(9978) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 35, 7, 889, DateTimeKind.Local).AddTicks(8183), new DateTime(2021, 12, 7, 13, 35, 7, 889, DateTimeKind.Local).AddTicks(6345), new DateTime(2021, 12, 7, 13, 35, 7, 889, DateTimeKind.Local).AddTicks(5949), new DateTime(2021, 12, 7, 13, 35, 7, 889, DateTimeKind.Local).AddTicks(8197) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 35, 7, 889, DateTimeKind.Local).AddTicks(8245), new DateTime(2021, 12, 7, 13, 35, 7, 889, DateTimeKind.Local).AddTicks(8236) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 35, 7, 905, DateTimeKind.Local).AddTicks(5462), new DateTime(2021, 12, 7, 13, 35, 7, 905, DateTimeKind.Local).AddTicks(2195), new DateTime(2021, 12, 7, 13, 35, 7, 905, DateTimeKind.Local).AddTicks(4186), new DateTime(2021, 12, 7, 13, 35, 7, 905, DateTimeKind.Local).AddTicks(5478) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 35, 7, 905, DateTimeKind.Local).AddTicks(5966), new DateTime(2021, 12, 7, 13, 35, 7, 905, DateTimeKind.Local).AddTicks(5842), new DateTime(2021, 12, 7, 13, 35, 7, 905, DateTimeKind.Local).AddTicks(5894), new DateTime(2021, 12, 7, 13, 35, 7, 905, DateTimeKind.Local).AddTicks(5970) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BancoConta",
                table: "Colaboradores",
                type: "character varying(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BancoAgencia",
                table: "Colaboradores",
                type: "character varying(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 12, 47, 50, 230, DateTimeKind.Local).AddTicks(4117), new DateTime(2021, 12, 7, 12, 47, 50, 230, DateTimeKind.Local).AddTicks(3929), new DateTime(2021, 12, 7, 12, 47, 50, 230, DateTimeKind.Local).AddTicks(4121) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 12, 47, 50, 230, DateTimeKind.Local).AddTicks(3883), new DateTime(2021, 12, 7, 12, 47, 50, 229, DateTimeKind.Local).AddTicks(8837), new DateTime(2021, 12, 7, 12, 47, 50, 230, DateTimeKind.Local).AddTicks(3892) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 12, 47, 50, 233, DateTimeKind.Local).AddTicks(5172), new DateTime(2021, 12, 7, 12, 47, 50, 233, DateTimeKind.Local).AddTicks(5153), new DateTime(2021, 12, 7, 12, 47, 50, 233, DateTimeKind.Local).AddTicks(5176) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 12, 47, 50, 233, DateTimeKind.Local).AddTicks(4735), new DateTime(2021, 12, 7, 12, 47, 50, 233, DateTimeKind.Local).AddTicks(4088), new DateTime(2021, 12, 7, 12, 47, 50, 233, DateTimeKind.Local).AddTicks(4747) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 12, 47, 50, 217, DateTimeKind.Local).AddTicks(160), "Maria de Lourdes", new DateTime(2021, 12, 7, 12, 47, 50, 218, DateTimeKind.Local).AddTicks(14) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 12, 47, 50, 218, DateTimeKind.Local).AddTicks(847), "Carlos Amarildo de Souza", new DateTime(2021, 12, 7, 12, 47, 50, 218, DateTimeKind.Local).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 12, 47, 50, 221, DateTimeKind.Local).AddTicks(9157), new DateTime(2021, 12, 7, 12, 47, 50, 221, DateTimeKind.Local).AddTicks(9187) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 12, 47, 50, 221, DateTimeKind.Local).AddTicks(9329), new DateTime(2021, 12, 7, 12, 47, 50, 221, DateTimeKind.Local).AddTicks(9333) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 12, 47, 50, 225, DateTimeKind.Local).AddTicks(3825), new DateTime(2021, 12, 7, 12, 47, 50, 225, DateTimeKind.Local).AddTicks(2112), new DateTime(2021, 12, 7, 12, 47, 50, 225, DateTimeKind.Local).AddTicks(1738), new DateTime(2021, 12, 7, 12, 47, 50, 225, DateTimeKind.Local).AddTicks(3839) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 7, 12, 47, 50, 225, DateTimeKind.Local).AddTicks(3890), new DateTime(2021, 12, 7, 12, 47, 50, 225, DateTimeKind.Local).AddTicks(3881) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 12, 47, 50, 236, DateTimeKind.Local).AddTicks(1070), new DateTime(2021, 12, 7, 12, 47, 50, 235, DateTimeKind.Local).AddTicks(8037), new DateTime(2021, 12, 7, 12, 47, 50, 235, DateTimeKind.Local).AddTicks(9888), new DateTime(2021, 12, 7, 12, 47, 50, 236, DateTimeKind.Local).AddTicks(1083) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 12, 47, 50, 236, DateTimeKind.Local).AddTicks(1563), new DateTime(2021, 12, 7, 12, 47, 50, 236, DateTimeKind.Local).AddTicks(1426), new DateTime(2021, 12, 7, 12, 47, 50, 236, DateTimeKind.Local).AddTicks(1489), new DateTime(2021, 12, 7, 12, 47, 50, 236, DateTimeKind.Local).AddTicks(1567) });
        }
    }
}
