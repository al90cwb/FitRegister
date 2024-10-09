using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTabelasPlanoTreinos : Migration
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

            migrationBuilder.DropTable(
                name: "PlanoDeUso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treino",
                table: "Treino");

            migrationBuilder.RenameTable(
                name: "Treino",
                newName: "Treinos");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Professores",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Professores",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Professores",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Professores",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Alunos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Alunos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Alunos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Alunos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treinos",
                table: "Treinos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomePlano = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Planos_PlanoId",
                table: "Alunos",
                column: "PlanoId",
                principalTable: "Planos",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Planos_PlanoId",
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

            migrationBuilder.DropTable(
                name: "Planos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treinos",
                table: "Treinos");

            migrationBuilder.RenameTable(
                name: "Treinos",
                newName: "Treino");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Professores",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Professores",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Professores",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Professores",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Alunos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Alunos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Alunos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Alunos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treino",
                table: "Treino",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PlanoDeUso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomePlano = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoDeUso", x => x.Id);
                });

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
    }
}
