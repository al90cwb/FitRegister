using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    DuracaoEmDias = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treino", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    TreinoSegundaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TreinoTercaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TreinoQuartaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TreinoQuintaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TreinoSextaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TreinoSabadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TreinoDomingoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataDuracao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PlanoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProfessorId = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_PlanoDeUso_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "PlanoDeUso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alunos_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Alunos_Treino_TreinoDomingoId",
                        column: x => x.TreinoDomingoId,
                        principalTable: "Treino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alunos_Treino_TreinoQuartaId",
                        column: x => x.TreinoQuartaId,
                        principalTable: "Treino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alunos_Treino_TreinoQuintaId",
                        column: x => x.TreinoQuintaId,
                        principalTable: "Treino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alunos_Treino_TreinoSabadoId",
                        column: x => x.TreinoSabadoId,
                        principalTable: "Treino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alunos_Treino_TreinoSegundaId",
                        column: x => x.TreinoSegundaId,
                        principalTable: "Treino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alunos_Treino_TreinoSextaId",
                        column: x => x.TreinoSextaId,
                        principalTable: "Treino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alunos_Treino_TreinoTercaId",
                        column: x => x.TreinoTercaId,
                        principalTable: "Treino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_PlanoId",
                table: "Alunos",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ProfessorId",
                table: "Alunos",
                column: "ProfessorId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "PlanoDeUso");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Treino");
        }
    }
}
