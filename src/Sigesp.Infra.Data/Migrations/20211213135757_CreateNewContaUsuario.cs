using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateNewContaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int[]>(
                name: "InstrumentosPrisao",
                table: "Detentos",
                nullable: true,
                oldClrType: typeof(List<InstrumentoPrisaoTipoEnum>),
                oldType: "instrumento_prisao_tipo_enum[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Setor",
                table: "ContaUsuarios",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "PerfilFoto",
                table: "ContaUsuarios",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Funcao",
                table: "ContaUsuarios",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba56983e-f96f-4009-afe1-96586b830a93", "729acc13-9d1a-436b-bcea-2d0231b09c38", "Usuarios_Perfil", "USUARIOS_PERFIL" });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "TipoConta", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 203, DateTimeKind.Local).AddTicks(8150), new DateTime(2021, 12, 13, 10, 57, 56, 203, DateTimeKind.Local).AddTicks(7974), 3, new DateTime(2021, 12, 13, 10, 57, 56, 203, DateTimeKind.Local).AddTicks(8154) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "TipoConta", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 203, DateTimeKind.Local).AddTicks(7916), new DateTime(2021, 12, 13, 10, 57, 56, 203, DateTimeKind.Local).AddTicks(2676), 2, new DateTime(2021, 12, 13, 10, 57, 56, 203, DateTimeKind.Local).AddTicks(7926) });

            migrationBuilder.InsertData(
                table: "ContaUsuarios",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Funcao", "IsDeleted", "Nome", "PerfilFoto", "Setor", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[,]
                {
                    { new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"), new DateTime(2021, 12, 13, 10, 57, 56, 182, DateTimeKind.Local).AddTicks(1639), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "ARQUITETO_SOFTWARE", false, "Usuário Master", "data:image/jpeg;base64,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", "TECNOLOGIA_INFORMACAO", new DateTime(2021, 12, 13, 10, 57, 56, 183, DateTimeKind.Local).AddTicks(2238), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "1e526008-75f7-4a01-9942-d178f2b38888" },
                    { new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"), new DateTime(2021, 12, 13, 10, 57, 56, 183, DateTimeKind.Local).AddTicks(3390), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "CHEFE_PECULIO", false, "Usuário Administrador", "data:image/png;base64,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", "LABORAL", new DateTime(2021, 12, 13, 10, 57, 56, 183, DateTimeKind.Local).AddTicks(3413), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "8e445865-a24d-4543-a6c6-9443d048cdb9" }
                });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 207, DateTimeKind.Local).AddTicks(970), new DateTime(2021, 12, 13, 10, 57, 56, 207, DateTimeKind.Local).AddTicks(949), new DateTime(2021, 12, 13, 10, 57, 56, 207, DateTimeKind.Local).AddTicks(975) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 207, DateTimeKind.Local).AddTicks(518), new DateTime(2021, 12, 13, 10, 57, 56, 206, DateTimeKind.Local).AddTicks(9799), new DateTime(2021, 12, 13, 10, 57, 56, 207, DateTimeKind.Local).AddTicks(533) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 190, DateTimeKind.Local).AddTicks(481), "Maria de Lourdes", new DateTime(2021, 12, 13, 10, 57, 56, 190, DateTimeKind.Local).AddTicks(516) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 190, DateTimeKind.Local).AddTicks(624), "Carlos Amarildo de Souza", new DateTime(2021, 12, 13, 10, 57, 56, 190, DateTimeKind.Local).AddTicks(628) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 194, DateTimeKind.Local).AddTicks(1683), new DateTime(2021, 12, 13, 10, 57, 56, 194, DateTimeKind.Local).AddTicks(1722) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 194, DateTimeKind.Local).AddTicks(1884), new DateTime(2021, 12, 13, 10, 57, 56, 194, DateTimeKind.Local).AddTicks(1889) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 197, DateTimeKind.Local).AddTicks(9487), new DateTime(2021, 12, 13, 10, 57, 56, 197, DateTimeKind.Local).AddTicks(7825), new DateTime(2021, 12, 13, 10, 57, 56, 197, DateTimeKind.Local).AddTicks(7428), new DateTime(2021, 12, 13, 10, 57, 56, 197, DateTimeKind.Local).AddTicks(9501) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 197, DateTimeKind.Local).AddTicks(9548), new DateTime(2021, 12, 13, 10, 57, 56, 197, DateTimeKind.Local).AddTicks(9538) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(6909), new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(3527), new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(5636), new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(6935) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(7469), new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(7310), new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(7432), new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(7475) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba56983e-f96f-4009-afe1-96586b830a93");

            migrationBuilder.DeleteData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"));

            migrationBuilder.DeleteData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"));

            migrationBuilder.AlterColumn<List<InstrumentoPrisaoTipoEnum>>(
                name: "InstrumentosPrisao",
                table: "Detentos",
                type: "instrumento_prisao_tipo_enum[]",
                nullable: true,
                oldClrType: typeof(int[]),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Setor",
                table: "ContaUsuarios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PerfilFoto",
                table: "ContaUsuarios",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Funcao",
                table: "ContaUsuarios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "TipoConta", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 579, DateTimeKind.Local).AddTicks(3387), new DateTime(2021, 12, 9, 16, 29, 31, 579, DateTimeKind.Local).AddTicks(3181), 3, new DateTime(2021, 12, 9, 16, 29, 31, 579, DateTimeKind.Local).AddTicks(3391) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "TipoConta", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 579, DateTimeKind.Local).AddTicks(3132), new DateTime(2021, 12, 9, 16, 29, 31, 578, DateTimeKind.Local).AddTicks(7730), 2, new DateTime(2021, 12, 9, 16, 29, 31, 579, DateTimeKind.Local).AddTicks(3145) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 583, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 12, 9, 16, 29, 31, 583, DateTimeKind.Local).AddTicks(770), new DateTime(2021, 12, 9, 16, 29, 31, 583, DateTimeKind.Local).AddTicks(813) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 583, DateTimeKind.Local).AddTicks(67), new DateTime(2021, 12, 9, 16, 29, 31, 582, DateTimeKind.Local).AddTicks(9042), new DateTime(2021, 12, 9, 16, 29, 31, 583, DateTimeKind.Local).AddTicks(104) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 564, DateTimeKind.Local).AddTicks(4432), "Maria de Lourdes", new DateTime(2021, 12, 9, 16, 29, 31, 565, DateTimeKind.Local).AddTicks(4821) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 565, DateTimeKind.Local).AddTicks(5678), "Carlos Amarildo de Souza", new DateTime(2021, 12, 9, 16, 29, 31, 565, DateTimeKind.Local).AddTicks(5700) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 569, DateTimeKind.Local).AddTicks(2896), new DateTime(2021, 12, 9, 16, 29, 31, 569, DateTimeKind.Local).AddTicks(2924) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 569, DateTimeKind.Local).AddTicks(3100), new DateTime(2021, 12, 9, 16, 29, 31, 569, DateTimeKind.Local).AddTicks(3104) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 573, DateTimeKind.Local).AddTicks(1688), new DateTime(2021, 12, 9, 16, 29, 31, 572, DateTimeKind.Local).AddTicks(9908), new DateTime(2021, 12, 9, 16, 29, 31, 572, DateTimeKind.Local).AddTicks(9458), new DateTime(2021, 12, 9, 16, 29, 31, 573, DateTimeKind.Local).AddTicks(1702) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 573, DateTimeKind.Local).AddTicks(1755), new DateTime(2021, 12, 9, 16, 29, 31, 573, DateTimeKind.Local).AddTicks(1744) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(7503), new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(4442), new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(6308), new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(7516) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(7983), new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(7861), new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(7912), new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(7987) });
        }
    }
}
