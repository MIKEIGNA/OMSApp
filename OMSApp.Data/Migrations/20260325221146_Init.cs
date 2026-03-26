using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OMSApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    IdBasket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.IdBasket);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IdProduct);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    IdBasketItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBasket = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BasketIdBasket = table.Column<int>(type: "int", nullable: false),
                    ProductIdProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.IdBasketItem);
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_BasketIdBasket",
                        column: x => x.BasketIdBasket,
                        principalTable: "Baskets",
                        principalColumn: "IdBasket",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductIdProduct",
                        column: x => x.ProductIdProduct,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "IdBasket", "CustomerName" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "IdProduct", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, 1000m, "Laptop" },
                    { 2, 20m, "Mouse" },
                    { 3, 50m, "Keyboard" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketIdBasket",
                table: "BasketItems",
                column: "BasketIdBasket");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductIdProduct",
                table: "BasketItems",
                column: "ProductIdProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
