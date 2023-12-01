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
                    Descricao = table.Column<string>(type: "VARCHAR(100)", nullable: false)
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
                    Descricao = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    IdClasseInvestimento = table.Column<int>(type: "int", nullable: false),
                    ClasseInvestimentoId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investimento_ClasseInvestimento_ClasseInvestimentoId",
                        column: x => x.ClasseInvestimentoId,
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

            migrationBuilder.CreateIndex(
                name: "IX_Investimento_ClasseInvestimentoId",
                table: "Investimento",
                column: "ClasseInvestimentoId");
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
