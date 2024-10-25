using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Mappings.Migrations
{
    /// <inheritdoc />
    public partial class ColorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    colorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productcolor",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    colorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productcolor", x => new { x.ProductsId, x.colorsId });
                    table.ForeignKey(
                        name: "FK_Productcolor_colors_colorsId",
                        column: x => x.colorsId,
                        principalTable: "colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productcolor_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productcolor_colorsId",
                table: "Productcolor",
                column: "colorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productcolor");

            migrationBuilder.DropTable(
                name: "colors");
        }
    }
}
