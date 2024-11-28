using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoExercicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExercicioId",
                table: "Professores",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ExercicioId",
                table: "Alunos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professores_ExercicioId",
                table: "Professores",
                column: "ExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ExercicioId",
                table: "Alunos",
                column: "ExercicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Exercicios_ExercicioId",
                table: "Alunos",
                column: "ExercicioId",
                principalTable: "Exercicios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Exercicios_ExercicioId",
                table: "Professores",
                column: "ExercicioId",
                principalTable: "Exercicios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Exercicios_ExercicioId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Exercicios_ExercicioId",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Professores_ExercicioId",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_ExercicioId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "ExercicioId",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "ExercicioId",
                table: "Alunos");
        }
    }
}
