using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ClasseAlunoPoderecebeValoresNulos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_PlanoDeUso_PlanoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treino_TreinoDomingoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treino_TreinoQuartaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treino_TreinoQuintaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treino_TreinoSabadoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treino_TreinoSegundaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treino_TreinoSextaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treino_TreinoTercaId",
                table: "Alunos");

            migrationBuilder.AlterColumn<int>(
                name: "TreinoTercaId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "TreinoSextaId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "TreinoSegundaId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "TreinoSabadoId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "TreinoQuintaId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "TreinoQuartaId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "TreinoDomingoId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PlanoId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDuracao",
                table: "Alunos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_PlanoDeUso_PlanoId",
                table: "Alunos",
                column: "PlanoId",
                principalTable: "PlanoDeUso",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treino_TreinoDomingoId",
                table: "Alunos",
                column: "TreinoDomingoId",
                principalTable: "Treino",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treino_TreinoQuartaId",
                table: "Alunos",
                column: "TreinoQuartaId",
                principalTable: "Treino",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treino_TreinoQuintaId",
                table: "Alunos",
                column: "TreinoQuintaId",
                principalTable: "Treino",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treino_TreinoSabadoId",
                table: "Alunos",
                column: "TreinoSabadoId",
                principalTable: "Treino",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treino_TreinoSegundaId",
                table: "Alunos",
                column: "TreinoSegundaId",
                principalTable: "Treino",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treino_TreinoSextaId",
                table: "Alunos",
                column: "TreinoSextaId",
                principalTable: "Treino",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treino_TreinoTercaId",
                table: "Alunos",
                column: "TreinoTercaId",
                principalTable: "Treino",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_PlanoDeUso_PlanoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treino_TreinoDomingoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treino_TreinoQuartaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treino_TreinoQuintaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treino_TreinoSabadoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treino_TreinoSegundaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treino_TreinoSextaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treino_TreinoTercaId",
                table: "Alunos");

            migrationBuilder.AlterColumn<int>(
                name: "TreinoTercaId",
                table: "Alunos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TreinoSextaId",
                table: "Alunos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TreinoSegundaId",
                table: "Alunos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TreinoSabadoId",
                table: "Alunos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TreinoQuintaId",
                table: "Alunos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TreinoQuartaId",
                table: "Alunos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TreinoDomingoId",
                table: "Alunos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlanoId",
                table: "Alunos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDuracao",
                table: "Alunos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_PlanoDeUso_PlanoId",
                table: "Alunos",
                column: "PlanoId",
                principalTable: "PlanoDeUso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treino_TreinoDomingoId",
                table: "Alunos",
                column: "TreinoDomingoId",
                principalTable: "Treino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treino_TreinoQuartaId",
                table: "Alunos",
                column: "TreinoQuartaId",
                principalTable: "Treino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treino_TreinoQuintaId",
                table: "Alunos",
                column: "TreinoQuintaId",
                principalTable: "Treino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treino_TreinoSabadoId",
                table: "Alunos",
                column: "TreinoSabadoId",
                principalTable: "Treino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treino_TreinoSegundaId",
                table: "Alunos",
                column: "TreinoSegundaId",
                principalTable: "Treino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treino_TreinoSextaId",
                table: "Alunos",
                column: "TreinoSextaId",
                principalTable: "Treino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treino_TreinoTercaId",
                table: "Alunos",
                column: "TreinoTercaId",
                principalTable: "Treino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
