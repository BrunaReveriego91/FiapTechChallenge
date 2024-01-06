using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiapTechChallenge.API.Migrations
{
    /// <inheritdoc />
    public partial class Conta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroConta = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CPF = table.Column<int>(type: "INT", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    NomeMae = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    NomePai = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Renda = table.Column<decimal>(type: "NUMERIC(15,2)", nullable: false),
                    CEP = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Logradouro = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Numero = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Bairro = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Cidade = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Estado = table.Column<string>(type: "VARCHAR(2)", nullable: true),
                    Ativo = table.Column<bool>(type: "BIT", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false),
                    UsuarioId = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conta_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DadosBancarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroConta = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Agencia = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    IdConta = table.Column<int>(type: "INT", nullable: false),
                    ContaId = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosBancarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosBancarios_Conta_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Conta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conta_UsuarioId",
                table: "Conta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosBancarios_ContaId",
                table: "DadosBancarios",
                column: "ContaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosBancarios");

            migrationBuilder.DropTable(
                name: "Conta");
        }
    }
}
