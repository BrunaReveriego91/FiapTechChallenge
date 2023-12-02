using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiapTechChallenge.API.Migrations
{
    /// <inheritdoc />
    public partial class primeiramigration : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_Investimento_IdClasseInvestimento",
                table: "Investimento",
                column: "IdClasseInvestimento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investimento");

            migrationBuilder.DropTable(
                name: "ClasseInvestimento");
        }
    }
}
