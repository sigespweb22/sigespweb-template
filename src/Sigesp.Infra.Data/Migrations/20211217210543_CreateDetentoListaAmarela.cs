using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateDetentoListaAmarela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetentosListaAmarela",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    RevisaoIpenData = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    RevisaoIpenObservacao = table.Column<string>(maxLength: 255, nullable: true),
                    DataPrisao = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Artigos = table.Column<string>(maxLength: 255, nullable: true),
                    Comarca = table.Column<string>(maxLength: 255, nullable: true),
                    PenaAno = table.Column<string>(maxLength: 4, nullable: true),
                    PenaMes = table.Column<string>(maxLength: 6, nullable: true),
                    PenaDia = table.Column<string>(maxLength: 12, nullable: true),
                    InstrumentosPrisao = table.Column<int[]>(nullable: true),
                    CondenacaoTipo = table.Column<int>(nullable: false),
                    DiasMedidaDisciplinar = table.Column<long>(nullable: false, defaultValue: 0L),
                    AcaoPenal = table.Column<string>(maxLength: 255, nullable: true),
                    DataPrevisaoBeneficio = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    DataProgressao = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    PrevisaoBeneficioObservacao = table.Column<string>(maxLength: 255, nullable: true),
                    DetentoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetentosListaAmarela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetentosListaAmarela_Detentos_DetentoId",
                        column: x => x.DetentoId,
                        principalTable: "Detentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DetentosListaAmarela_DetentoId",
                table: "DetentosListaAmarela",
                column: "DetentoId",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetentosListaAmarela");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 17, 17, 55, 30, 493, DateTimeKind.Local).AddTicks(8247), new DateTime(2021, 12, 17, 17, 55, 30, 493, DateTimeKind.Local).AddTicks(8000), 25m, 33m, 5, "Fábrica do conveniado", 3, new DateTime(2021, 12, 17, 17, 55, 30, 493, DateTimeKind.Local).AddTicks(8253) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 17, 17, 55, 30, 493, DateTimeKind.Local).AddTicks(7942), new DateTime(2021, 12, 17, 17, 55, 30, 493, DateTimeKind.Local).AddTicks(992), 25m, 33m, 10, "GALERIA", 2, new DateTime(2021, 12, 17, 17, 55, 30, 493, DateTimeKind.Local).AddTicks(7957) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 17, 55, 30, 475, DateTimeKind.Local).AddTicks(6478), new DateTime(2021, 12, 17, 17, 55, 30, 475, DateTimeKind.Local).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 17, 55, 30, 474, DateTimeKind.Local).AddTicks(5694), new DateTime(2021, 12, 17, 17, 55, 30, 475, DateTimeKind.Local).AddTicks(5541) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 17, 55, 30, 498, DateTimeKind.Local).AddTicks(3814), new DateTime(2021, 12, 17, 17, 55, 30, 498, DateTimeKind.Local).AddTicks(3789), new DateTime(2021, 12, 17, 17, 55, 30, 498, DateTimeKind.Local).AddTicks(3821) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 17, 55, 30, 498, DateTimeKind.Local).AddTicks(3255), new DateTime(2021, 12, 17, 17, 55, 30, 498, DateTimeKind.Local).AddTicks(2416), new DateTime(2021, 12, 17, 17, 55, 30, 498, DateTimeKind.Local).AddTicks(3273) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Situacao", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 17, 17, 55, 30, 480, DateTimeKind.Local).AddTicks(108), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 17, 17, 55, 30, 480, DateTimeKind.Local).AddTicks(143) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Situacao", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 17, 17, 55, 30, 480, DateTimeKind.Local).AddTicks(245), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 17, 17, 55, 30, 480, DateTimeKind.Local).AddTicks(249) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 17, 55, 30, 483, DateTimeKind.Local).AddTicks(3142), new DateTime(2021, 12, 17, 17, 55, 30, 483, DateTimeKind.Local).AddTicks(3176) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 17, 55, 30, 483, DateTimeKind.Local).AddTicks(3327), new DateTime(2021, 12, 17, 17, 55, 30, 483, DateTimeKind.Local).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 17, 55, 30, 486, DateTimeKind.Local).AddTicks(6983), new DateTime(2021, 12, 17, 17, 55, 30, 486, DateTimeKind.Local).AddTicks(5648), new DateTime(2021, 12, 17, 17, 55, 30, 486, DateTimeKind.Local).AddTicks(5314), new DateTime(2021, 12, 17, 17, 55, 30, 486, DateTimeKind.Local).AddTicks(6996) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 17, 17, 55, 30, 486, DateTimeKind.Local).AddTicks(7044), new DateTime(2021, 12, 17, 17, 55, 30, 486, DateTimeKind.Local).AddTicks(7036) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 17, 55, 30, 501, DateTimeKind.Local).AddTicks(8964), new DateTime(2021, 12, 17, 17, 55, 30, 501, DateTimeKind.Local).AddTicks(4662), new DateTime(2021, 12, 17, 17, 55, 30, 501, DateTimeKind.Local).AddTicks(7104), new DateTime(2021, 12, 17, 17, 55, 30, 501, DateTimeKind.Local).AddTicks(8982) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 17, 17, 55, 30, 501, DateTimeKind.Local).AddTicks(9826), new DateTime(2021, 12, 17, 17, 55, 30, 501, DateTimeKind.Local).AddTicks(9612), new DateTime(2021, 12, 17, 17, 55, 30, 501, DateTimeKind.Local).AddTicks(9779), new DateTime(2021, 12, 17, 17, 55, 30, 501, DateTimeKind.Local).AddTicks(9834) });
        }
    }
}
