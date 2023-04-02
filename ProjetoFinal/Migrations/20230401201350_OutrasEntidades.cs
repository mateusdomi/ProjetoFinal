using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinal.Migrations
{
    public partial class OutrasEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Perfil",
                table: "Usuario",
                newName: "Atividade");

            migrationBuilder.AddColumn<int>(
                name: "DisciplinaId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TurmaId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mensagem",
                columns: table => new
                {
                    MensagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.MensagemId);
                });

            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    SerieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.SerieId);
                });

            migrationBuilder.CreateTable(
                name: "Notificacao",
                columns: table => new
                {
                    NotificacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMensagem = table.Column<int>(type: "int", nullable: false),
                    MensagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacao", x => x.NotificacaoId);
                    table.ForeignKey(
                        name: "FK_Notificacao_Mensagem_MensagemId",
                        column: x => x.MensagemId,
                        principalTable: "Mensagem",
                        principalColumn: "MensagemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.TurmaId);
                    table.ForeignKey(
                        name: "FK_Turma_Serie_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Serie",
                        principalColumn: "SerieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    DisciplinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.DisciplinaId);
                    table.ForeignKey(
                        name: "FK_Disciplina_Turma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turma",
                        principalColumn: "TurmaId");
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.MateriaId);
                    table.ForeignKey(
                        name: "FK_Materia_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "DisciplinaId");
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.AvaliacaoId);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Usuario_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_DisciplinaId",
                table: "Usuario",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TurmaId",
                table: "Usuario",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_AlunoId",
                table: "Avaliacao",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_MateriaId",
                table: "Avaliacao",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_TurmaId",
                table: "Disciplina",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Materia_DisciplinaId",
                table: "Materia",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_MensagemId",
                table: "Notificacao",
                column: "MensagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_UsuarioId",
                table: "Notificacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_SerieId",
                table: "Turma",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Disciplina_DisciplinaId",
                table: "Usuario",
                column: "DisciplinaId",
                principalTable: "Disciplina",
                principalColumn: "DisciplinaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Turma_TurmaId",
                table: "Usuario",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "TurmaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Disciplina_DisciplinaId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Turma_TurmaId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Notificacao");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "Mensagem");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Serie");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_DisciplinaId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_TurmaId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Atividade",
                table: "Usuario",
                newName: "Perfil");

            migrationBuilder.AddColumn<int>(
                name: "Ativo",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
