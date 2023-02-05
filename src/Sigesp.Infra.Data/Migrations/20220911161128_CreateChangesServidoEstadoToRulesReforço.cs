using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesServidoEstadoToRulesReforço : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateFimGozo",
                table: "ServidoresEstado",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateInicioGozo",
                table: "ServidoresEstado",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "HasFeriasAgendadas",
                table: "ServidoresEstado",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasLicencaPremioAgendada",
                table: "ServidoresEstado",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "1e526008-75f7-4a01-9942-d178f2b38888",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscrita",
                keyColumn: "Id",
                keyValue: new Guid("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 13, 11, 27, 799, DateTimeKind.Local).AddTicks(5744), new DateTime(2022, 9, 11, 13, 11, 27, 799, DateTimeKind.Local).AddTicks(5757) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 13, 11, 27, 801, DateTimeKind.Local).AddTicks(3433), new DateTime(2022, 9, 11, 13, 11, 27, 801, DateTimeKind.Local).AddTicks(3439) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 13, 11, 27, 801, DateTimeKind.Local).AddTicks(2439), new DateTime(2022, 9, 11, 13, 11, 27, 801, DateTimeKind.Local).AddTicks(2451) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 13, 11, 27, 801, DateTimeKind.Local).AddTicks(3473), new DateTime(2022, 9, 11, 13, 11, 27, 801, DateTimeKind.Local).AddTicks(3475) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 13, 11, 27, 801, DateTimeKind.Local).AddTicks(3480), new DateTime(2022, 9, 11, 13, 11, 27, 801, DateTimeKind.Local).AddTicks(3481) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 13, 11, 27, 801, DateTimeKind.Local).AddTicks(3466), new DateTime(2022, 9, 11, 13, 11, 27, 801, DateTimeKind.Local).AddTicks(3469) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 13, 11, 27, 804, DateTimeKind.Local).AddTicks(3734), new DateTime(2022, 9, 11, 13, 11, 27, 804, DateTimeKind.Local).AddTicks(3736) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 13, 11, 27, 804, DateTimeKind.Local).AddTicks(3728), new DateTime(2022, 9, 11, 13, 11, 27, 804, DateTimeKind.Local).AddTicks(3729) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 13, 11, 27, 804, DateTimeKind.Local).AddTicks(3720), new DateTime(2022, 9, 11, 13, 11, 27, 804, DateTimeKind.Local).AddTicks(3722) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 13, 11, 27, 804, DateTimeKind.Local).AddTicks(2824), new DateTime(2022, 9, 11, 13, 11, 27, 804, DateTimeKind.Local).AddTicks(2835) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 13, 11, 27, 804, DateTimeKind.Local).AddTicks(3689), new DateTime(2022, 9, 11, 13, 11, 27, 804, DateTimeKind.Local).AddTicks(3695) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 13, 11, 27, 802, DateTimeKind.Local).AddTicks(6699), new DateTime(2022, 9, 11, 13, 11, 27, 802, DateTimeKind.Local).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 13, 11, 27, 797, DateTimeKind.Local).AddTicks(1141), new DateTime(2022, 9, 11, 13, 11, 27, 797, DateTimeKind.Local).AddTicks(9464) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 13, 11, 27, 798, DateTimeKind.Local).AddTicks(725), new DateTime(2022, 9, 11, 13, 11, 27, 798, DateTimeKind.Local).AddTicks(743) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 13, 11, 27, 798, DateTimeKind.Local).AddTicks(777), new DateTime(2022, 9, 11, 13, 11, 27, 798, DateTimeKind.Local).AddTicks(779) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFimGozo",
                table: "ServidoresEstado");

            migrationBuilder.DropColumn(
                name: "DateInicioGozo",
                table: "ServidoresEstado");

            migrationBuilder.DropColumn(
                name: "HasFeriasAgendadas",
                table: "ServidoresEstado");

            migrationBuilder.DropColumn(
                name: "HasLicencaPremioAgendada",
                table: "ServidoresEstado");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "1e526008-75f7-4a01-9942-d178f2b38888",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscrita",
                keyColumn: "Id",
                keyValue: new Guid("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 10, 11, 59, 5, 403, DateTimeKind.Local).AddTicks(2797), new DateTime(2022, 9, 10, 11, 59, 5, 403, DateTimeKind.Local).AddTicks(2818) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 10, 11, 59, 5, 405, DateTimeKind.Local).AddTicks(1625), new DateTime(2022, 9, 10, 11, 59, 5, 405, DateTimeKind.Local).AddTicks(1632) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 10, 11, 59, 5, 405, DateTimeKind.Local).AddTicks(736), new DateTime(2022, 9, 10, 11, 59, 5, 405, DateTimeKind.Local).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 10, 11, 59, 5, 405, DateTimeKind.Local).AddTicks(1669), new DateTime(2022, 9, 10, 11, 59, 5, 405, DateTimeKind.Local).AddTicks(1671) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 10, 11, 59, 5, 405, DateTimeKind.Local).AddTicks(1676), new DateTime(2022, 9, 10, 11, 59, 5, 405, DateTimeKind.Local).AddTicks(1677) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 10, 11, 59, 5, 405, DateTimeKind.Local).AddTicks(1661), new DateTime(2022, 9, 10, 11, 59, 5, 405, DateTimeKind.Local).AddTicks(1663) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 10, 11, 59, 5, 408, DateTimeKind.Local).AddTicks(3587), new DateTime(2022, 9, 10, 11, 59, 5, 408, DateTimeKind.Local).AddTicks(3589) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 10, 11, 59, 5, 408, DateTimeKind.Local).AddTicks(3581), new DateTime(2022, 9, 10, 11, 59, 5, 408, DateTimeKind.Local).AddTicks(3582) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 10, 11, 59, 5, 408, DateTimeKind.Local).AddTicks(3573), new DateTime(2022, 9, 10, 11, 59, 5, 408, DateTimeKind.Local).AddTicks(3576) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 10, 11, 59, 5, 408, DateTimeKind.Local).AddTicks(2610), new DateTime(2022, 9, 10, 11, 59, 5, 408, DateTimeKind.Local).AddTicks(2622) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 10, 11, 59, 5, 408, DateTimeKind.Local).AddTicks(3541), new DateTime(2022, 9, 10, 11, 59, 5, 408, DateTimeKind.Local).AddTicks(3547) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 10, 11, 59, 5, 406, DateTimeKind.Local).AddTicks(5723), new DateTime(2022, 9, 10, 11, 59, 5, 406, DateTimeKind.Local).AddTicks(5734) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 10, 11, 59, 5, 400, DateTimeKind.Local).AddTicks(5729), new DateTime(2022, 9, 10, 11, 59, 5, 401, DateTimeKind.Local).AddTicks(4185) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 10, 11, 59, 5, 401, DateTimeKind.Local).AddTicks(5693), new DateTime(2022, 9, 10, 11, 59, 5, 401, DateTimeKind.Local).AddTicks(5718) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 10, 11, 59, 5, 401, DateTimeKind.Local).AddTicks(5762), new DateTime(2022, 9, 10, 11, 59, 5, 401, DateTimeKind.Local).AddTicks(5765) });
        }
    }
}
