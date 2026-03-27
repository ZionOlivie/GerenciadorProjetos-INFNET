using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorProjetos.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentosAvancados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjetoEquipes",
                columns: table => new
                {
                    EquipaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjetosParticipadosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoEquipes", x => new { x.EquipaId, x.ProjetosParticipadosId });
                    table.ForeignKey(
                        name: "FK_ProjetoEquipes_Projetos_ProjetosParticipadosId",
                        column: x => x.ProjetosParticipadosId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetoEquipes_Usuarios_EquipaId",
                        column: x => x.EquipaId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_GerenteResponsavelId",
                table: "Projetos",
                column: "GerenteResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoEquipes_ProjetosParticipadosId",
                table: "ProjetoEquipes",
                column: "ProjetosParticipadosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Usuarios_GerenteResponsavelId",
                table: "Projetos",
                column: "GerenteResponsavelId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Projetos_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Usuarios_GerenteResponsavelId",
                table: "Projetos");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Projetos_ProjetoId",
                table: "Tarefas");

            migrationBuilder.DropTable(
                name: "ProjetoEquipes");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_GerenteResponsavelId",
                table: "Projetos");
        }
    }
}
