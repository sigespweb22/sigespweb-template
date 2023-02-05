using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeEdis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EdisInconsistencias");

            migrationBuilder.CreateTable(
                name: "EdisLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    EntityName = table.Column<string>(maxLength: 100, nullable: true),
                    EntityProperty = table.Column<string>(maxLength: 100, nullable: true),
                    EntityPropertyOldValue = table.Column<string>(nullable: true),
                    EntityPropertyNewValue = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false, defaultValue: 0),
                    EdiId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdisLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EdisLogs_Edis_EdiId",
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
                values: new object[] { 1, new DateTime(2022, 1, 3, 10, 44, 25, 428, DateTimeKind.Local).AddTicks(1139), new DateTime(2022, 1, 3, 10, 44, 25, 428, DateTimeKind.Local).AddTicks(998), 25m, 33m, 5, "Fábrica do conveniado", 1000.20m, 3, new DateTime(2022, 1, 3, 10, 44, 25, 428, DateTimeKind.Local).AddTicks(1141) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "Remuneracao", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2022, 1, 3, 10, 44, 25, 428, DateTimeKind.Local).AddTicks(961), new DateTime(2022, 1, 3, 10, 44, 25, 427, DateTimeKind.Local).AddTicks(6652), 25m, 33m, 10, "GALERIA", 1000.20m, 2, new DateTime(2022, 1, 3, 10, 44, 25, 428, DateTimeKind.Local).AddTicks(968) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 411, DateTimeKind.Local).AddTicks(2624), new DateTime(2022, 1, 3, 10, 44, 25, 411, DateTimeKind.Local).AddTicks(2645) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 410, DateTimeKind.Local).AddTicks(2809), new DateTime(2022, 1, 3, 10, 44, 25, 411, DateTimeKind.Local).AddTicks(1793) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 430, DateTimeKind.Local).AddTicks(6518), new DateTime(2022, 1, 3, 10, 44, 25, 430, DateTimeKind.Local).AddTicks(6504), new DateTime(2022, 1, 3, 10, 44, 25, 430, DateTimeKind.Local).AddTicks(6521) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 430, DateTimeKind.Local).AddTicks(6190), new DateTime(2022, 1, 3, 10, 44, 25, 430, DateTimeKind.Local).AddTicks(5717), new DateTime(2022, 1, 3, 10, 44, 25, 430, DateTimeKind.Local).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2022, 1, 3, 10, 44, 25, 416, DateTimeKind.Local).AddTicks(29), true, "Maria de Lourdes", 7, new DateTime(2022, 1, 3, 10, 44, 25, 416, DateTimeKind.Local).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2022, 1, 3, 10, 44, 25, 416, DateTimeKind.Local).AddTicks(142), true, "Carlos Amarildo de Souza", 8, new DateTime(2022, 1, 3, 10, 44, 25, 416, DateTimeKind.Local).AddTicks(145) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 418, DateTimeKind.Local).AddTicks(8879), new DateTime(2022, 1, 3, 10, 44, 25, 418, DateTimeKind.Local).AddTicks(8897) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 418, DateTimeKind.Local).AddTicks(9011), new DateTime(2022, 1, 3, 10, 44, 25, 418, DateTimeKind.Local).AddTicks(9015) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 421, DateTimeKind.Local).AddTicks(3999), new DateTime(2022, 1, 3, 10, 44, 25, 421, DateTimeKind.Local).AddTicks(2766), new DateTime(2022, 1, 3, 10, 44, 25, 421, DateTimeKind.Local).AddTicks(2480), new DateTime(2022, 1, 3, 10, 44, 25, 421, DateTimeKind.Local).AddTicks(4011) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 421, DateTimeKind.Local).AddTicks(4051), new DateTime(2022, 1, 3, 10, 44, 25, 421, DateTimeKind.Local).AddTicks(4044) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(6461), new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(4193), new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(5575), new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(6472) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(6816), new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(6723), new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(6786), new DateTime(2022, 1, 3, 10, 44, 25, 432, DateTimeKind.Local).AddTicks(6820) });

            migrationBuilder.CreateIndex(
                name: "IX_EdisLogs_EdiId",
                table: "EdisLogs",
                column: "EdiId",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EdisLogs");

            migrationBuilder.CreateTable(
                name: "EdisInconsistencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    EdiId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    KeyNumber = table.Column<long>(type: "bigint", nullable: true),
                    KeyText = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
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
    }
}
