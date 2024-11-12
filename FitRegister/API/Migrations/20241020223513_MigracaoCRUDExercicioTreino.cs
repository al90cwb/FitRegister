using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoCRUDExercicioTreino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercicioTreino_Exercicios_ExerciciosId",
                table: "ExercicioTreino");

            migrationBuilder.DropForeignKey(
                name: "FK_ExercicioTreino_Treinos_TreinosId",
                table: "ExercicioTreino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExercicioTreino",
                table: "ExercicioTreino");

            migrationBuilder.RenameTable(
                name: "ExercicioTreino",
                newName: "TreinoExercicio");

            migrationBuilder.RenameIndex(
                name: "IX_ExercicioTreino_TreinosId",
                table: "TreinoExercicio",
                newName: "IX_TreinoExercicio_TreinosId");

            migrationBuilder.AlterColumn<int>(
                name: "TempoDescanso",
                table: "Exercicios",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Repeticoes",
                table: "Exercicios",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Exercicios",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "GrupoMuscular",
                table: "Exercicios",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Exercicios",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "Exercicios",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TreinoExercicio",
                table: "TreinoExercicio",
                columns: new[] { "ExerciciosId", "TreinosId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TreinoExercicio_Exercicios_ExerciciosId",
                table: "TreinoExercicio",
                column: "ExerciciosId",
                principalTable: "Exercicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreinoExercicio_Treinos_TreinosId",
                table: "TreinoExercicio",
                column: "TreinosId",
                principalTable: "Treinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreinoExercicio_Exercicios_ExerciciosId",
                table: "TreinoExercicio");

            migrationBuilder.DropForeignKey(
                name: "FK_TreinoExercicio_Treinos_TreinosId",
                table: "TreinoExercicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TreinoExercicio",
                table: "TreinoExercicio");

            migrationBuilder.RenameTable(
                name: "TreinoExercicio",
                newName: "ExercicioTreino");

            migrationBuilder.RenameIndex(
                name: "IX_TreinoExercicio_TreinosId",
                table: "ExercicioTreino",
                newName: "IX_ExercicioTreino_TreinosId");

            migrationBuilder.AlterColumn<int>(
                name: "TempoDescanso",
                table: "Exercicios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Repeticoes",
                table: "Exercicios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Exercicios",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GrupoMuscular",
                table: "Exercicios",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Exercicios",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "Exercicios",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExercicioTreino",
                table: "ExercicioTreino",
                columns: new[] { "ExerciciosId", "TreinosId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExercicioTreino_Exercicios_ExerciciosId",
                table: "ExercicioTreino",
                column: "ExerciciosId",
                principalTable: "Exercicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercicioTreino_Treinos_TreinosId",
                table: "ExercicioTreino",
                column: "TreinosId",
                principalTable: "Treinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
