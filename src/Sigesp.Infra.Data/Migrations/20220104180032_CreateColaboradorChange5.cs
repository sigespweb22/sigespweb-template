using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateColaboradorChange5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_DetentoId",
                table: "Colaboradores");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 4, 15, 0, 32, 230, DateTimeKind.Local).AddTicks(3909), new DateTime(2022, 1, 4, 15, 0, 32, 230, DateTimeKind.Local).AddTicks(3765), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2022, 1, 4, 15, 0, 32, 230, DateTimeKind.Local).AddTicks(3912) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2022, 1, 4, 15, 0, 32, 230, DateTimeKind.Local).AddTicks(3726), new DateTime(2022, 1, 4, 15, 0, 32, 229, DateTimeKind.Local).AddTicks(9038), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2022, 1, 4, 15, 0, 32, 230, DateTimeKind.Local).AddTicks(3734) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 15, 0, 32, 212, DateTimeKind.Local).AddTicks(3742), new DateTime(2022, 1, 4, 15, 0, 32, 212, DateTimeKind.Local).AddTicks(3762) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 15, 0, 32, 211, DateTimeKind.Local).AddTicks(4951), new DateTime(2022, 1, 4, 15, 0, 32, 212, DateTimeKind.Local).AddTicks(2858) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 15, 0, 32, 233, DateTimeKind.Local).AddTicks(1044), new DateTime(2022, 1, 4, 15, 0, 32, 233, DateTimeKind.Local).AddTicks(1028), new DateTime(2022, 1, 4, 15, 0, 32, 233, DateTimeKind.Local).AddTicks(1047) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 15, 0, 32, 233, DateTimeKind.Local).AddTicks(699), new DateTime(2022, 1, 4, 15, 0, 32, 233, DateTimeKind.Local).AddTicks(170), new DateTime(2022, 1, 4, 15, 0, 32, 233, DateTimeKind.Local).AddTicks(711) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2022, 1, 4, 15, 0, 32, 217, DateTimeKind.Local).AddTicks(9234), true, "Maria de Lourdes", 7, new DateTime(2022, 1, 4, 15, 0, 32, 217, DateTimeKind.Local).AddTicks(9272) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2022, 1, 4, 15, 0, 32, 217, DateTimeKind.Local).AddTicks(9373), true, "Carlos Amarildo de Souza", 8, new DateTime(2022, 1, 4, 15, 0, 32, 217, DateTimeKind.Local).AddTicks(9377) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 15, 0, 32, 220, DateTimeKind.Local).AddTicks(9969), new DateTime(2022, 1, 4, 15, 0, 32, 220, DateTimeKind.Local).AddTicks(9999) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 15, 0, 32, 221, DateTimeKind.Local).AddTicks(126), new DateTime(2022, 1, 4, 15, 0, 32, 221, DateTimeKind.Local).AddTicks(129) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 15, 0, 32, 223, DateTimeKind.Local).AddTicks(6129), new DateTime(2022, 1, 4, 15, 0, 32, 223, DateTimeKind.Local).AddTicks(4802), new DateTime(2022, 1, 4, 15, 0, 32, 223, DateTimeKind.Local).AddTicks(4483), new DateTime(2022, 1, 4, 15, 0, 32, 223, DateTimeKind.Local).AddTicks(6143) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2022, 1, 4, 15, 0, 32, 223, DateTimeKind.Local).AddTicks(6188), new DateTime(2022, 1, 4, 15, 0, 32, 223, DateTimeKind.Local).AddTicks(6179) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 15, 0, 32, 235, DateTimeKind.Local).AddTicks(2502), new DateTime(2022, 1, 4, 15, 0, 32, 235, DateTimeKind.Local).AddTicks(25), new DateTime(2022, 1, 4, 15, 0, 32, 235, DateTimeKind.Local).AddTicks(1532), new DateTime(2022, 1, 4, 15, 0, 32, 235, DateTimeKind.Local).AddTicks(2515) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 4, 15, 0, 32, 235, DateTimeKind.Local).AddTicks(3188), new DateTime(2022, 1, 4, 15, 0, 32, 235, DateTimeKind.Local).AddTicks(3080), new DateTime(2022, 1, 4, 15, 0, 32, 235, DateTimeKind.Local).AddTicks(3156), new DateTime(2022, 1, 4, 15, 0, 32, 235, DateTimeKind.Local).AddTicks(3191) });

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_DetentoId",
                table: "Colaboradores",
                column: "DetentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_DetentoId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_DetentoId",
                table: "Colaboradores",
                column: "DetentoId",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }
    }
}
