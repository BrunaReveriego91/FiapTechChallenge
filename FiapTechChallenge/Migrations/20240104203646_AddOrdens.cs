using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiapTechChallenge.API.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoOrdem = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordem", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Ordem",
                columns: new[] { "Id", "Quantidade", "TipoOrdem" },
                values: new object[,]
                {
                    { 1, 99, "A Mercado" },
                    { 2, 49, "StartStop" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordem");
        }
    }
}
