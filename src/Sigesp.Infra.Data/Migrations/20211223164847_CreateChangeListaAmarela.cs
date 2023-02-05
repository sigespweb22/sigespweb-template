using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeListaAmarela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetentosListaAmarela");

            migrationBuilder.CreateTable(
                name: "ListaAmarela",
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
                    table.PrimaryKey("PK_ListaAmarela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListaAmarela_Detentos_DetentoId",
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

            migrationBuilder.CreateIndex(
                name: "IX_ListaAmarela_DetentoId",
                table: "ListaAmarela",
                column: "DetentoId",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaAmarela");

            migrationBuilder.CreateTable(
                name: "DetentosListaAmarela",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AcaoPenal = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Artigos = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Comarca = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CondenacaoTipo = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DataPrevisaoBeneficio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    DataPrisao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    DataProgressao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    DetentoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DiasMedidaDisciplinar = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    InstrumentosPrisao = table.Column<int[]>(type: "integer[]", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    PenaAno = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    PenaDia = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    PenaMes = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    PrevisaoBeneficioObservacao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    RevisaoIpenData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    RevisaoIpenObservacao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
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
                values: new object[] { 1, new DateTime(2021, 12, 22, 10, 39, 44, 205, DateTimeKind.Local).AddTicks(8933), new DateTime(2021, 12, 22, 10, 39, 44, 205, DateTimeKind.Local).AddTicks(8752), 25m, 33m, 5, "Fábrica do conveniado", 3, new DateTime(2021, 12, 22, 10, 39, 44, 205, DateTimeKind.Local).AddTicks(8937) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 22, 10, 39, 44, 205, DateTimeKind.Local).AddTicks(8705), new DateTime(2021, 12, 22, 10, 39, 44, 205, DateTimeKind.Local).AddTicks(3298), 25m, 33m, 10, "GALERIA", 2, new DateTime(2021, 12, 22, 10, 39, 44, 205, DateTimeKind.Local).AddTicks(8715) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 22, 10, 39, 44, 186, DateTimeKind.Local).AddTicks(1123), new DateTime(2021, 12, 22, 10, 39, 44, 186, DateTimeKind.Local).AddTicks(1159) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 22, 10, 39, 44, 184, DateTimeKind.Local).AddTicks(9768), new DateTime(2021, 12, 22, 10, 39, 44, 185, DateTimeKind.Local).AddTicks(9933) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 22, 10, 39, 44, 209, DateTimeKind.Local).AddTicks(1168), new DateTime(2021, 12, 22, 10, 39, 44, 209, DateTimeKind.Local).AddTicks(1148), new DateTime(2021, 12, 22, 10, 39, 44, 209, DateTimeKind.Local).AddTicks(1172) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 22, 10, 39, 44, 209, DateTimeKind.Local).AddTicks(691), new DateTime(2021, 12, 22, 10, 39, 44, 209, DateTimeKind.Local).AddTicks(8), new DateTime(2021, 12, 22, 10, 39, 44, 209, DateTimeKind.Local).AddTicks(704) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 22, 10, 39, 44, 191, DateTimeKind.Local).AddTicks(1618), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 22, 10, 39, 44, 191, DateTimeKind.Local).AddTicks(1654) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Regime", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 22, 10, 39, 44, 191, DateTimeKind.Local).AddTicks(1770), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 22, 10, 39, 44, 191, DateTimeKind.Local).AddTicks(1773) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 22, 10, 39, 44, 195, DateTimeKind.Local).AddTicks(5405), new DateTime(2021, 12, 22, 10, 39, 44, 195, DateTimeKind.Local).AddTicks(5444) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 22, 10, 39, 44, 195, DateTimeKind.Local).AddTicks(5621), new DateTime(2021, 12, 22, 10, 39, 44, 195, DateTimeKind.Local).AddTicks(5625) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 22, 10, 39, 44, 199, DateTimeKind.Local).AddTicks(3342), new DateTime(2021, 12, 22, 10, 39, 44, 199, DateTimeKind.Local).AddTicks(1600), new DateTime(2021, 12, 22, 10, 39, 44, 199, DateTimeKind.Local).AddTicks(1194), new DateTime(2021, 12, 22, 10, 39, 44, 199, DateTimeKind.Local).AddTicks(3357) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 22, 10, 39, 44, 199, DateTimeKind.Local).AddTicks(3408), new DateTime(2021, 12, 22, 10, 39, 44, 199, DateTimeKind.Local).AddTicks(3399) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 22, 10, 39, 44, 211, DateTimeKind.Local).AddTicks(6672), new DateTime(2021, 12, 22, 10, 39, 44, 211, DateTimeKind.Local).AddTicks(3299), new DateTime(2021, 12, 22, 10, 39, 44, 211, DateTimeKind.Local).AddTicks(5253), new DateTime(2021, 12, 22, 10, 39, 44, 211, DateTimeKind.Local).AddTicks(6686) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 22, 10, 39, 44, 211, DateTimeKind.Local).AddTicks(7175), new DateTime(2021, 12, 22, 10, 39, 44, 211, DateTimeKind.Local).AddTicks(7045), new DateTime(2021, 12, 22, 10, 39, 44, 211, DateTimeKind.Local).AddTicks(7135), new DateTime(2021, 12, 22, 10, 39, 44, 211, DateTimeKind.Local).AddTicks(7178) });

            migrationBuilder.CreateIndex(
                name: "IX_DetentosListaAmarela_DetentoId",
                table: "DetentosListaAmarela",
                column: "DetentoId",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }
    }
}
