using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class ChangeColaboradoresFieldTipoConta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoConta",
                table: "Colaboradores",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "TipoConta", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 735, DateTimeKind.Local).AddTicks(6710), new DateTime(2021, 12, 7, 13, 41, 35, 735, DateTimeKind.Local).AddTicks(6532), 3, new DateTime(2021, 12, 7, 13, 41, 35, 735, DateTimeKind.Local).AddTicks(6713) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "TipoConta", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 735, DateTimeKind.Local).AddTicks(6482), new DateTime(2021, 12, 7, 13, 41, 35, 735, DateTimeKind.Local).AddTicks(1118), 2, new DateTime(2021, 12, 7, 13, 41, 35, 735, DateTimeKind.Local).AddTicks(6492) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 739, DateTimeKind.Local).AddTicks(8593), new DateTime(2021, 12, 7, 13, 41, 35, 739, DateTimeKind.Local).AddTicks(8559), new DateTime(2021, 12, 7, 13, 41, 35, 739, DateTimeKind.Local).AddTicks(8602) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 739, DateTimeKind.Local).AddTicks(7873), new DateTime(2021, 12, 7, 13, 41, 35, 739, DateTimeKind.Local).AddTicks(6803), new DateTime(2021, 12, 7, 13, 41, 35, 739, DateTimeKind.Local).AddTicks(7903) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 720, DateTimeKind.Local).AddTicks(9935), "Maria de Lourdes", new DateTime(2021, 12, 7, 13, 41, 35, 722, DateTimeKind.Local).AddTicks(596) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 722, DateTimeKind.Local).AddTicks(1482), "Carlos Amarildo de Souza", new DateTime(2021, 12, 7, 13, 41, 35, 722, DateTimeKind.Local).AddTicks(1504) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 726, DateTimeKind.Local).AddTicks(2446), new DateTime(2021, 12, 7, 13, 41, 35, 726, DateTimeKind.Local).AddTicks(2480) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 726, DateTimeKind.Local).AddTicks(2640), new DateTime(2021, 12, 7, 13, 41, 35, 726, DateTimeKind.Local).AddTicks(2644) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 729, DateTimeKind.Local).AddTicks(8760), new DateTime(2021, 12, 7, 13, 41, 35, 729, DateTimeKind.Local).AddTicks(6959), new DateTime(2021, 12, 7, 13, 41, 35, 729, DateTimeKind.Local).AddTicks(6579), new DateTime(2021, 12, 7, 13, 41, 35, 729, DateTimeKind.Local).AddTicks(8776) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 729, DateTimeKind.Local).AddTicks(8827), new DateTime(2021, 12, 7, 13, 41, 35, 729, DateTimeKind.Local).AddTicks(8814) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(7509), new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(3992), new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(6071), new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(7529) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(8056), new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(7905), new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(7973), new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(8061) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoConta",
                table: "Colaboradores",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

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
    }
}
