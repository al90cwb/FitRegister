using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class fixRelacaoClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Professores_ProfessorId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treinos_TreinoDomingoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treinos_TreinoQuartaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treinos_TreinoQuintaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treinos_TreinoSabadoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treinos_TreinoSegundaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treinos_TreinoSextaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treinos_TreinoTercaId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TreinoDomingoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TreinoQuartaId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TreinoQuintaId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TreinoSabadoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TreinoSegundaId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TreinoSextaId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TreinoTercaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TreinoDomingoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TreinoQuartaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TreinoQuintaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TreinoSabadoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TreinoSegundaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TreinoSextaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TreinoTercaId",
                table: "Alunos");

            migrationBuilder.RenameColumn(
                name: "DataDuracao",
                table: "Alunos",
                newName: "TreinoId");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Treinos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Planos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessorId",
                table: "Alunos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlanoId",
                table: "Alunos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TreinoId",
                table: "Alunos",
                column: "TreinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Professores_ProfessorId",
                table: "Alunos",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treinos_TreinoId",
                table: "Alunos",
                column: "TreinoId",
                principalTable: "Treinos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Professores_ProfessorId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Treinos_TreinoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TreinoId",
                table: "Alunos");

            migrationBuilder.RenameColumn(
                name: "TreinoId",
                table: "Alunos",
                newName: "DataDuracao");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Treinos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Planos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfessorId",
                table: "Alunos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlanoId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreinoDomingoId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreinoQuartaId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreinoQuintaId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreinoSabadoId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreinoSegundaId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreinoSextaId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreinoTercaId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TreinoDomingoId",
                table: "Alunos",
                column: "TreinoDomingoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TreinoQuartaId",
                table: "Alunos",
                column: "TreinoQuartaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TreinoQuintaId",
                table: "Alunos",
                column: "TreinoQuintaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TreinoSabadoId",
                table: "Alunos",
                column: "TreinoSabadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TreinoSegundaId",
                table: "Alunos",
                column: "TreinoSegundaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TreinoSextaId",
                table: "Alunos",
                column: "TreinoSextaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TreinoTercaId",
                table: "Alunos",
                column: "TreinoTercaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Professores_ProfessorId",
                table: "Alunos",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treinos_TreinoDomingoId",
                table: "Alunos",
                column: "TreinoDomingoId",
                principalTable: "Treinos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treinos_TreinoQuartaId",
                table: "Alunos",
                column: "TreinoQuartaId",
                principalTable: "Treinos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treinos_TreinoQuintaId",
                table: "Alunos",
                column: "TreinoQuintaId",
                principalTable: "Treinos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treinos_TreinoSabadoId",
                table: "Alunos",
                column: "TreinoSabadoId",
                principalTable: "Treinos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treinos_TreinoSegundaId",
                table: "Alunos",
                column: "TreinoSegundaId",
                principalTable: "Treinos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treinos_TreinoSextaId",
                table: "Alunos",
                column: "TreinoSextaId",
                principalTable: "Treinos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Treinos_TreinoTercaId",
                table: "Alunos",
                column: "TreinoTercaId",
                principalTable: "Treinos",
                principalColumn: "Id");
        }
    }
}
