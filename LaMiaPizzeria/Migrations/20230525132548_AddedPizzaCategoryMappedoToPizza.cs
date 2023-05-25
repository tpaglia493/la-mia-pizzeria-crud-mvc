using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaMiaPizzeria.Migrations
{
    /// <inheritdoc />
    public partial class AddedPizzaCategoryMappedoToPizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pizzaCategoryId",
                table: "Pizze",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "pizzaCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizzaCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizze_pizzaCategoryId",
                table: "Pizze",
                column: "pizzaCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_pizzaCategories_pizzaCategoryId",
                table: "Pizze",
                column: "pizzaCategoryId",
                principalTable: "pizzaCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_pizzaCategories_pizzaCategoryId",
                table: "Pizze");

            migrationBuilder.DropTable(
                name: "pizzaCategories");

            migrationBuilder.DropIndex(
                name: "IX_Pizze_pizzaCategoryId",
                table: "Pizze");

            migrationBuilder.DropColumn(
                name: "pizzaCategoryId",
                table: "Pizze");
        }
    }
}
