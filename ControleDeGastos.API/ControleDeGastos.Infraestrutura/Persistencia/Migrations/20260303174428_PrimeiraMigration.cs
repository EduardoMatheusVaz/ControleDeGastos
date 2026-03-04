using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeGastos.Infraestrutura.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(400)", nullable: false),
                    Finalidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "tb_Pessoas",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Pessoas", x => x.IdPessoa);
                });

            migrationBuilder.CreateTable(
                name: "tb_Transacao",
                columns: table => new
                {
                    IdTransacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(400)", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    TipoDespesa = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Transacao", x => x.IdTransacao);
                    table.ForeignKey(
                        name: "FK_tb_Transacao_tb_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "tb_Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Transacao_tb_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "tb_Pessoas",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Transacao_IdCategoria",
                table: "tb_Transacao",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Transacao_IdPessoa",
                table: "tb_Transacao",
                column: "IdPessoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Transacao");

            migrationBuilder.DropTable(
                name: "tb_Categoria");

            migrationBuilder.DropTable(
                name: "tb_Pessoas");
        }
    }
}
