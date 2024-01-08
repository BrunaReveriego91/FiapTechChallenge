using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiapTechChallenge.API.Migrations
{
    /// <inheritdoc />
    public partial class first_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClasseInvestimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasseInvestimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroConta = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(250)", nullable: true),
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
                    Ativo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    IdClasseInvestimento = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investimento_ClasseInvestimento_IdClasseInvestimento",
                        column: x => x.IdClasseInvestimento,
                        principalTable: "ClasseInvestimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DadosBancarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoBanco = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    NumeroConta = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Agencia = table.Column<string>(type: "VARCHAR(20)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Login = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Senha = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ContaId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Conta_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtivoSimbolo = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Quantidade = table.Column<int>(type: "INT", nullable: false),
                    PrecoCompra = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DataTransacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    TipoTransacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClasseInvestimento",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Renda Fixa" },
                    { 2, "Renda Variável" },
                    { 3, "Fundos de Investimento" },
                    { 4, "Previdência Privada" },
                    { 5, "COE (Certificado de Operações Estruturadas)" },
                    { 6, "Operações no Mercado Internacional" },
                    { 7, "Câmbio" }
                });

            migrationBuilder.InsertData(
                table: "Conta",
                columns: new[] { "Id", "Ativo", "Bairro", "CEP", "CPF", "Cidade", "Complemento", "Email", "Estado", "Logradouro", "Nome", "NomeMae", "NomePai", "Numero", "NumeroConta", "Renda" },
                values: new object[] { 1, true, "Centro", "1200000", "11111111111", "São Paulo", "Casa", "admin@admin.com", "SP", "Rua Sem Nome", "Admin", "Maria", "José", "1", "1111", 0m });

            migrationBuilder.InsertData(
                table: "Investimento",
                columns: new[] { "Id", "Descricao", "IdClasseInvestimento" },
                values: new object[,]
                {
                    { 1, "Tesouro Direto", 1 },
                    { 2, "CDB (Certificado de Depósito Bancário)", 1 },
                    { 3, "LCI (Letra de Crédito Imobiliário)", 1 },
                    { 4, "LCA (Letra de Crédito do Agronegócio)", 1 },
                    { 5, "Debêntures", 1 },
                    { 6, "Ações", 2 },
                    { 7, "Opções", 2 },
                    { 8, "ETFs (Exchange Traded Funds)", 2 },
                    { 9, "Fundos de Investimento em Ações", 2 },
                    { 10, "Fundos de Renda Fixa", 3 },
                    { 11, "Fundos Multimercado", 3 },
                    { 12, "Fundos de Ações", 3 },
                    { 13, "Fundos Imobiliários", 3 },
                    { 14, "PGBL (Plano Gerador de Benefício Livre)", 4 },
                    { 15, "VGBL (Vida Gerador de Benefício Livre)", 4 },
                    { 16, "COE (Certificado de Operações Estruturadas)", 5 },
                    { 17, "Investimentos em ativos estrangeiros", 6 },
                    { 18, "Operações com moedas estrangeiras", 7 }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "ContaId", "Email", "Login", "Nome", "Senha" },
                values: new object[] { 1, 1, "admin@admin.com", "admin", "admin", "admin@123" });

            migrationBuilder.CreateIndex(
                name: "IX_DadosBancarios_ContaId",
                table: "DadosBancarios",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Investimento_IdClasseInvestimento",
                table: "Investimento",
                column: "IdClasseInvestimento");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_UsuarioId",
                table: "Transacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ContaId",
                table: "Usuario",
                column: "ContaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosBancarios");

            migrationBuilder.DropTable(
                name: "Investimento");

            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "ClasseInvestimento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Conta");
        }
    }
}
