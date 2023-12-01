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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClasseInvestimento");
        }
    }
}
