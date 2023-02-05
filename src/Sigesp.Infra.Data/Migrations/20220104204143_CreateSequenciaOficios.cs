using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateSequenciaOficios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_DetentoId",
                table: "Colaboradores");

            migrationBuilder.CreateTable(
                name: "SequenciasOficios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Sequencia = table.Column<int>(nullable: false),
                    UsuarioNomeUltimaSequencia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SequenciasOficios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2238a399-29e0-4b50-971a-e42bf0dfb219", "6b2bb02e-96e4-448a-855f-f480cd110f9f", "Sequencias-Oficios_Todos", "SEQUENCIAS-OFICIOS_TODOS" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_DetentoId",
                table: "Colaboradores",
                column: "DetentoId",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SequenciasOficios");

            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_DetentoId",
                table: "Colaboradores");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2238a399-29e0-4b50-971a-e42bf0dfb219");

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
    }
}
