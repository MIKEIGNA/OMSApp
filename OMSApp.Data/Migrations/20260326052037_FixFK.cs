using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMSApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Baskets_BasketIdBasket",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Products_ProductIdProduct",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_BasketIdBasket",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_ProductIdProduct",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "BasketIdBasket",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "ProductIdProduct",
                table: "BasketItems");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_IdBasket",
                table: "BasketItems",
                column: "IdBasket");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_IdProduct",
                table: "BasketItems",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Baskets_IdBasket",
                table: "BasketItems",
                column: "IdBasket",
                principalTable: "Baskets",
                principalColumn: "IdBasket",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Products_IdProduct",
                table: "BasketItems",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Baskets_IdBasket",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Products_IdProduct",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_IdBasket",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_IdProduct",
                table: "BasketItems");

            migrationBuilder.AddColumn<int>(
                name: "BasketIdBasket",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductIdProduct",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketIdBasket",
                table: "BasketItems",
                column: "BasketIdBasket");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductIdProduct",
                table: "BasketItems",
                column: "ProductIdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Baskets_BasketIdBasket",
                table: "BasketItems",
                column: "BasketIdBasket",
                principalTable: "Baskets",
                principalColumn: "IdBasket",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Products_ProductIdProduct",
                table: "BasketItems",
                column: "ProductIdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
