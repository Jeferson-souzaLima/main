using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAulas.Data.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CATEGORIA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CATEGORIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_FORNECEDOR",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(14)", nullable: false),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FORNECEDOR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_FORNECEDOR_ENDERECO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(150)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(150)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(100)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FORNECEDOR_ENDERECO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_FORNECEDOR_ENDERECO_TB_FORNECEDOR_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "TB_FORNECEDOR",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUTO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PRODUTO_TB_CATEGORIA_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "TB_CATEGORIA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_PRODUTO_TB_FORNECEDOR_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "TB_FORNECEDOR",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_FORNECEDOR_ENDERECO_FornecedorId",
                table: "TB_FORNECEDOR_ENDERECO",
                column: "FornecedorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTO_CategoriaId",
                table: "TB_PRODUTO",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTO_FornecedorId",
                table: "TB_PRODUTO",
                column: "FornecedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_FORNECEDOR_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_PRODUTO");

            migrationBuilder.DropTable(
                name: "TB_CATEGORIA");

            migrationBuilder.DropTable(
                name: "TB_FORNECEDOR");
        }
    }
}
