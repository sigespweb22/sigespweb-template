using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeDetentoAndColaboradores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Detentos_DetentoId",
                table: "Colaboradores");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 4, 14, 48, 14, 354, DateTimeKind.Local).AddTicks(8923), new DateTime(2022, 1, 4, 14, 48, 14, 354, DateTimeKind.Local).AddTicks(8760), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2022, 1, 4, 14, 48, 14, 354, DateTimeKind.Local).AddTicks(8926) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2022, 1, 4, 14, 48, 14, 354, DateTimeKind.Local).AddTicks(8610), new DateTime(2022, 1, 4, 14, 48, 14, 354, DateTimeKind.Local).AddTicks(3690), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2022, 1, 4, 14, 48, 14, 354, DateTimeKind.Local).AddTicks(8625) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 48, 14, 338, DateTimeKind.Local).AddTicks(2374), new DateTime(2022, 1, 4, 14, 48, 14, 338, DateTimeKind.Local).AddTicks(2393) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 48, 14, 337, DateTimeKind.Local).AddTicks(4036), new DateTime(2022, 1, 4, 14, 48, 14, 338, DateTimeKind.Local).AddTicks(1531) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 48, 14, 359, DateTimeKind.Local).AddTicks(7630), new DateTime(2022, 1, 4, 14, 48, 14, 359, DateTimeKind.Local).AddTicks(7612), new DateTime(2022, 1, 4, 14, 48, 14, 359, DateTimeKind.Local).AddTicks(7633) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 48, 14, 359, DateTimeKind.Local).AddTicks(7245), new DateTime(2022, 1, 4, 14, 48, 14, 359, DateTimeKind.Local).AddTicks(6709), new DateTime(2022, 1, 4, 14, 48, 14, 359, DateTimeKind.Local).AddTicks(7263) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2022, 1, 4, 14, 48, 14, 344, DateTimeKind.Local).AddTicks(6036), true, "Maria de Lourdes", 7, new DateTime(2022, 1, 4, 14, 48, 14, 344, DateTimeKind.Local).AddTicks(6073) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2022, 1, 4, 14, 48, 14, 344, DateTimeKind.Local).AddTicks(6165), true, "Carlos Amarildo de Souza", 8, new DateTime(2022, 1, 4, 14, 48, 14, 344, DateTimeKind.Local).AddTicks(6169) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 48, 14, 347, DateTimeKind.Local).AddTicks(5660), new DateTime(2022, 1, 4, 14, 48, 14, 347, DateTimeKind.Local).AddTicks(5682) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 48, 14, 347, DateTimeKind.Local).AddTicks(5812), new DateTime(2022, 1, 4, 14, 48, 14, 347, DateTimeKind.Local).AddTicks(5816) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 48, 14, 350, DateTimeKind.Local).AddTicks(944), new DateTime(2022, 1, 4, 14, 48, 14, 349, DateTimeKind.Local).AddTicks(9654), new DateTime(2022, 1, 4, 14, 48, 14, 349, DateTimeKind.Local).AddTicks(9356), new DateTime(2022, 1, 4, 14, 48, 14, 350, DateTimeKind.Local).AddTicks(955) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 48, 14, 350, DateTimeKind.Local).AddTicks(990), new DateTime(2022, 1, 4, 14, 48, 14, 350, DateTimeKind.Local).AddTicks(982) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 48, 14, 362, DateTimeKind.Local).AddTicks(6152), new DateTime(2022, 1, 4, 14, 48, 14, 362, DateTimeKind.Local).AddTicks(3384), new DateTime(2022, 1, 4, 14, 48, 14, 362, DateTimeKind.Local).AddTicks(5218), new DateTime(2022, 1, 4, 14, 48, 14, 362, DateTimeKind.Local).AddTicks(6164) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 48, 14, 362, DateTimeKind.Local).AddTicks(6544), new DateTime(2022, 1, 4, 14, 48, 14, 362, DateTimeKind.Local).AddTicks(6431), new DateTime(2022, 1, 4, 14, 48, 14, 362, DateTimeKind.Local).AddTicks(6514), new DateTime(2022, 1, 4, 14, 48, 14, 362, DateTimeKind.Local).AddTicks(6547) });

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Detentos_DetentoId",
                table: "Colaboradores",
                column: "DetentoId",
                principalTable: "Detentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Detentos_DetentoId",
                table: "Colaboradores");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 4, 14, 39, 43, 302, DateTimeKind.Local).AddTicks(3117), new DateTime(2022, 1, 4, 14, 39, 43, 302, DateTimeKind.Local).AddTicks(2965), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2022, 1, 4, 14, 39, 43, 302, DateTimeKind.Local).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2022, 1, 4, 14, 39, 43, 302, DateTimeKind.Local).AddTicks(2922), new DateTime(2022, 1, 4, 14, 39, 43, 301, DateTimeKind.Local).AddTicks(8462), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2022, 1, 4, 14, 39, 43, 302, DateTimeKind.Local).AddTicks(2934) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 285, DateTimeKind.Local).AddTicks(6237), new DateTime(2022, 1, 4, 14, 39, 43, 285, DateTimeKind.Local).AddTicks(6258) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 284, DateTimeKind.Local).AddTicks(7270), new DateTime(2022, 1, 4, 14, 39, 43, 285, DateTimeKind.Local).AddTicks(5348) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 305, DateTimeKind.Local).AddTicks(128), new DateTime(2022, 1, 4, 14, 39, 43, 305, DateTimeKind.Local).AddTicks(111), new DateTime(2022, 1, 4, 14, 39, 43, 305, DateTimeKind.Local).AddTicks(131) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 304, DateTimeKind.Local).AddTicks(9758), new DateTime(2022, 1, 4, 14, 39, 43, 304, DateTimeKind.Local).AddTicks(9233), new DateTime(2022, 1, 4, 14, 39, 43, 304, DateTimeKind.Local).AddTicks(9770) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2022, 1, 4, 14, 39, 43, 291, DateTimeKind.Local).AddTicks(3704), true, "Maria de Lourdes", 7, new DateTime(2022, 1, 4, 14, 39, 43, 291, DateTimeKind.Local).AddTicks(3743) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2022, 1, 4, 14, 39, 43, 291, DateTimeKind.Local).AddTicks(3832), true, "Carlos Amarildo de Souza", 8, new DateTime(2022, 1, 4, 14, 39, 43, 291, DateTimeKind.Local).AddTicks(3836) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 294, DateTimeKind.Local).AddTicks(3899), new DateTime(2022, 1, 4, 14, 39, 43, 294, DateTimeKind.Local).AddTicks(3937) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 294, DateTimeKind.Local).AddTicks(4090), new DateTime(2022, 1, 4, 14, 39, 43, 294, DateTimeKind.Local).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 297, DateTimeKind.Local).AddTicks(125), new DateTime(2022, 1, 4, 14, 39, 43, 296, DateTimeKind.Local).AddTicks(8782), new DateTime(2022, 1, 4, 14, 39, 43, 296, DateTimeKind.Local).AddTicks(8461), new DateTime(2022, 1, 4, 14, 39, 43, 297, DateTimeKind.Local).AddTicks(138) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 297, DateTimeKind.Local).AddTicks(177), new DateTime(2022, 1, 4, 14, 39, 43, 297, DateTimeKind.Local).AddTicks(168) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(3481), new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(906), new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(2502), new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(3495) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(3890), new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(3777), new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(3860), new DateTime(2022, 1, 4, 14, 39, 43, 307, DateTimeKind.Local).AddTicks(3894) });

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Detentos_DetentoId",
                table: "Colaboradores",
                column: "DetentoId",
                principalTable: "Detentos",
                principalColumn: "Id");
        }
    }
}
