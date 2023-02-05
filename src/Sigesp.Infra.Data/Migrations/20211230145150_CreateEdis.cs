using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateEdis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    ArquivoNome = table.Column<string>(maxLength: 255, nullable: false),
                    ArquivoExtensao = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EdisInconsistencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 100, nullable: true),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    KeyNumber = table.Column<long>(nullable: true),
                    KeyText = table.Column<string>(maxLength: 255, nullable: true),
                    EdiId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdisInconsistencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EdisInconsistencias_Edis_EdiId",
                        column: x => x.EdiId,
                        principalTable: "Edis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 30, 11, 51, 50, 45, DateTimeKind.Local).AddTicks(5404), new DateTime(2021, 12, 30, 11, 51, 50, 45, DateTimeKind.Local).AddTicks(5267), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2021, 12, 30, 11, 51, 50, 45, DateTimeKind.Local).AddTicks(5407) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 30, 11, 51, 50, 45, DateTimeKind.Local).AddTicks(5232), new DateTime(2021, 12, 30, 11, 51, 50, 45, DateTimeKind.Local).AddTicks(1066), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2021, 12, 30, 11, 51, 50, 45, DateTimeKind.Local).AddTicks(5239) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 51, 50, 29, DateTimeKind.Local).AddTicks(5002), new DateTime(2021, 12, 30, 11, 51, 50, 29, DateTimeKind.Local).AddTicks(5022) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 51, 50, 28, DateTimeKind.Local).AddTicks(6530), new DateTime(2021, 12, 30, 11, 51, 50, 29, DateTimeKind.Local).AddTicks(4110) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 51, 50, 48, DateTimeKind.Local).AddTicks(3774), new DateTime(2021, 12, 30, 11, 51, 50, 48, DateTimeKind.Local).AddTicks(3757), new DateTime(2021, 12, 30, 11, 51, 50, 48, DateTimeKind.Local).AddTicks(3777) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 51, 50, 48, DateTimeKind.Local).AddTicks(3427), new DateTime(2021, 12, 30, 11, 51, 50, 48, DateTimeKind.Local).AddTicks(2893), new DateTime(2021, 12, 30, 11, 51, 50, 48, DateTimeKind.Local).AddTicks(3439) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 30, 11, 51, 50, 33, DateTimeKind.Local).AddTicks(9992), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 30, 11, 51, 50, 34, DateTimeKind.Local).AddTicks(12) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 30, 11, 51, 50, 34, DateTimeKind.Local).AddTicks(94), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 30, 11, 51, 50, 34, DateTimeKind.Local).AddTicks(97) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 51, 50, 37, DateTimeKind.Local).AddTicks(423), new DateTime(2021, 12, 30, 11, 51, 50, 37, DateTimeKind.Local).AddTicks(444) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 51, 50, 37, DateTimeKind.Local).AddTicks(566), new DateTime(2021, 12, 30, 11, 51, 50, 37, DateTimeKind.Local).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 51, 50, 40, DateTimeKind.Local).AddTicks(3306), new DateTime(2021, 12, 30, 11, 51, 50, 40, DateTimeKind.Local).AddTicks(1687), new DateTime(2021, 12, 30, 11, 51, 50, 40, DateTimeKind.Local).AddTicks(1115), new DateTime(2021, 12, 30, 11, 51, 50, 40, DateTimeKind.Local).AddTicks(3318) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 51, 50, 40, DateTimeKind.Local).AddTicks(3361), new DateTime(2021, 12, 30, 11, 51, 50, 40, DateTimeKind.Local).AddTicks(3354) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 51, 50, 50, DateTimeKind.Local).AddTicks(4244), new DateTime(2021, 12, 30, 11, 51, 50, 50, DateTimeKind.Local).AddTicks(1722), new DateTime(2021, 12, 30, 11, 51, 50, 50, DateTimeKind.Local).AddTicks(3168), new DateTime(2021, 12, 30, 11, 51, 50, 50, DateTimeKind.Local).AddTicks(4255) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 51, 50, 50, DateTimeKind.Local).AddTicks(4655), new DateTime(2021, 12, 30, 11, 51, 50, 50, DateTimeKind.Local).AddTicks(4554), new DateTime(2021, 12, 30, 11, 51, 50, 50, DateTimeKind.Local).AddTicks(4625), new DateTime(2021, 12, 30, 11, 51, 50, 50, DateTimeKind.Local).AddTicks(4658) });

            migrationBuilder.CreateIndex(
                name: "IX_EdisInconsistencias_EdiId",
                table: "EdisInconsistencias",
                column: "EdiId",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EdisInconsistencias");

            migrationBuilder.DropTable(
                name: "Edis");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 30, 11, 50, 0, 154, DateTimeKind.Local).AddTicks(177), new DateTime(2021, 12, 30, 11, 50, 0, 154, DateTimeKind.Local).AddTicks(40), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2021, 12, 30, 11, 50, 0, 154, DateTimeKind.Local).AddTicks(179) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 30, 11, 50, 0, 154, DateTimeKind.Local).AddTicks(5), new DateTime(2021, 12, 30, 11, 50, 0, 153, DateTimeKind.Local).AddTicks(5840), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2021, 12, 30, 11, 50, 0, 154, DateTimeKind.Local).AddTicks(13) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 50, 0, 137, DateTimeKind.Local).AddTicks(1240), new DateTime(2021, 12, 30, 11, 50, 0, 137, DateTimeKind.Local).AddTicks(1258) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 50, 0, 136, DateTimeKind.Local).AddTicks(2851), new DateTime(2021, 12, 30, 11, 50, 0, 137, DateTimeKind.Local).AddTicks(325) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 50, 0, 157, DateTimeKind.Local).AddTicks(8959), new DateTime(2021, 12, 30, 11, 50, 0, 157, DateTimeKind.Local).AddTicks(8943), new DateTime(2021, 12, 30, 11, 50, 0, 157, DateTimeKind.Local).AddTicks(8963) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 50, 0, 157, DateTimeKind.Local).AddTicks(8623), new DateTime(2021, 12, 30, 11, 50, 0, 157, DateTimeKind.Local).AddTicks(8107), new DateTime(2021, 12, 30, 11, 50, 0, 157, DateTimeKind.Local).AddTicks(8635) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 30, 11, 50, 0, 143, DateTimeKind.Local).AddTicks(2291), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 30, 11, 50, 0, 143, DateTimeKind.Local).AddTicks(2323) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 30, 11, 50, 0, 143, DateTimeKind.Local).AddTicks(2411), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 30, 11, 50, 0, 143, DateTimeKind.Local).AddTicks(2414) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 50, 0, 146, DateTimeKind.Local).AddTicks(1477), new DateTime(2021, 12, 30, 11, 50, 0, 146, DateTimeKind.Local).AddTicks(1518) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 50, 0, 146, DateTimeKind.Local).AddTicks(1678), new DateTime(2021, 12, 30, 11, 50, 0, 146, DateTimeKind.Local).AddTicks(1682) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 50, 0, 148, DateTimeKind.Local).AddTicks(9847), new DateTime(2021, 12, 30, 11, 50, 0, 148, DateTimeKind.Local).AddTicks(8556), new DateTime(2021, 12, 30, 11, 50, 0, 148, DateTimeKind.Local).AddTicks(8232), new DateTime(2021, 12, 30, 11, 50, 0, 148, DateTimeKind.Local).AddTicks(9858) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 50, 0, 148, DateTimeKind.Local).AddTicks(9893), new DateTime(2021, 12, 30, 11, 50, 0, 148, DateTimeKind.Local).AddTicks(9887) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 50, 0, 159, DateTimeKind.Local).AddTicks(9370), new DateTime(2021, 12, 30, 11, 50, 0, 159, DateTimeKind.Local).AddTicks(6972), new DateTime(2021, 12, 30, 11, 50, 0, 159, DateTimeKind.Local).AddTicks(8365), new DateTime(2021, 12, 30, 11, 50, 0, 159, DateTimeKind.Local).AddTicks(9382) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 30, 11, 50, 0, 159, DateTimeKind.Local).AddTicks(9762), new DateTime(2021, 12, 30, 11, 50, 0, 159, DateTimeKind.Local).AddTicks(9660), new DateTime(2021, 12, 30, 11, 50, 0, 159, DateTimeKind.Local).AddTicks(9735), new DateTime(2021, 12, 30, 11, 50, 0, 159, DateTimeKind.Local).AddTicks(9765) });
        }
    }
}
