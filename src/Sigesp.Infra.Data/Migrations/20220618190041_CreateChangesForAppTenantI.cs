using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesForAppTenantI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "EdisLogs",
                nullable: false,
                defaultValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Edis",
                nullable: false,
                defaultValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AlunosLeiturasCronogramas",
                nullable: false,
                defaultValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "AlunosLeitores",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "Alunos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

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
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 18, 16, 0, 41, 323, DateTimeKind.Local).AddTicks(4931), new DateTime(2022, 6, 18, 16, 0, 41, 324, DateTimeKind.Local).AddTicks(2350) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 18, 16, 0, 41, 324, DateTimeKind.Local).AddTicks(4338), new DateTime(2022, 6, 18, 16, 0, 41, 324, DateTimeKind.Local).AddTicks(4362) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 18, 16, 0, 41, 324, DateTimeKind.Local).AddTicks(4393), new DateTime(2022, 6, 18, 16, 0, 41, 324, DateTimeKind.Local).AddTicks(4396) });

            migrationBuilder.CreateIndex(
                name: "IX_EdisLogs_TenantId",
                table: "EdisLogs",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Edis_TenantId",
                table: "Edis",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeiturasCronogramas_TenantId",
                table: "AlunosLeiturasCronogramas",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeituras_TenantId",
                table: "AlunosLeituras",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosLeituras_Tenants_TenantId",
                table: "AlunosLeituras",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosLeiturasCronogramas_Tenants_TenantId",
                table: "AlunosLeiturasCronogramas",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Edis_Tenants_TenantId",
                table: "Edis",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EdisLogs_Tenants_TenantId",
                table: "EdisLogs",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunosLeituras_Tenants_TenantId",
                table: "AlunosLeituras");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunosLeiturasCronogramas_Tenants_TenantId",
                table: "AlunosLeiturasCronogramas");

            migrationBuilder.DropForeignKey(
                name: "FK_Edis_Tenants_TenantId",
                table: "Edis");

            migrationBuilder.DropForeignKey(
                name: "FK_EdisLogs_Tenants_TenantId",
                table: "EdisLogs");

            migrationBuilder.DropIndex(
                name: "IX_EdisLogs_TenantId",
                table: "EdisLogs");

            migrationBuilder.DropIndex(
                name: "IX_Edis_TenantId",
                table: "Edis");

            migrationBuilder.DropIndex(
                name: "IX_AlunosLeiturasCronogramas_TenantId",
                table: "AlunosLeiturasCronogramas");

            migrationBuilder.DropIndex(
                name: "IX_AlunosLeituras_TenantId",
                table: "AlunosLeituras");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "EdisLogs");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Edis");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AlunosLeiturasCronogramas");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AlunosLeituras");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "AlunosLeitores",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "Alunos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                oldClrType: typeof(Guid));

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
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 16, 18, 7, 40, 859, DateTimeKind.Local).AddTicks(2882), new DateTime(2022, 6, 16, 18, 7, 40, 860, DateTimeKind.Local).AddTicks(2386) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 16, 18, 7, 40, 860, DateTimeKind.Local).AddTicks(3681), new DateTime(2022, 6, 16, 18, 7, 40, 860, DateTimeKind.Local).AddTicks(3703) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 16, 18, 7, 40, 860, DateTimeKind.Local).AddTicks(3736), new DateTime(2022, 6, 16, 18, 7, 40, 860, DateTimeKind.Local).AddTicks(3739) });
        }
    }
}
