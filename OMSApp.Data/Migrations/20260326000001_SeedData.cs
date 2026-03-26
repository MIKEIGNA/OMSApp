using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMSApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed Shoppers
            migrationBuilder.InsertData(
                table: "Shopper",
                columns: new[] { "IdShopper", "Email", "FirstName", "LastName", "Address", "City", "StateProvince", "Country", "ZipCode" },
                values: new object[,]
                {
                    { 1, "crackjack@aol.com", "Jack", "Crack", "123 Main St", "New York", "NY", "USA", "10001" },
                    { 2, "marg5@infi.net", "Marg", "Smith", "456 Oak Ave", "Chicago", "IL", "USA", "60601" },
                    { 3, "ratboy@msn.net", "Rat", "Boy", "789 Pine Rd", "Houston", "TX", "USA", "77001" },
                    { 4, "kids2@xis.net", "Kids", "Two", "321 Elm St", "Phoenix", "AZ", "USA", "85001" },
                    { 5, "scott1@odu.edu", "Scott", "One", "654 Maple Dr", "Philadelphia", "PA", "USA", "19101" },
                    { 6, "spider@web.net", "Spider", "Web", "987 Cedar Ln", "San Antonio", "TX", "USA", "78201" }
                });

            // Seed Products
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "IdProduct", "ProductName", "Description", "Price" },
                values: new object[,]
                {
                    { 1, "Capressobar Model #351", "Espresso machine model 351", 29.50m },
                    { 2, "Capresso Ultima", "Ultima espresso machine", 49.99m },
                    { 3, "Eileen 4-cup French Press", "4-cup French press coffee maker", 19.99m },
                    { 4, "Coffee Grinder", "Electric coffee grinder", 28.50m },
                    { 5, "Sumatra", "Sumatra coffee beans 1lb", 12.99m },
                    { 6, "Guatamala", "Guatemala coffee beans 1lb", 10.00m },
                    { 7, "Columbia", "Colombia coffee beans 1lb", 11.50m },
                    { 8, "Brazil", "Brazil coffee beans 1lb", 10.80m },
                    { 9, "Ethiopia", "Ethiopia coffee beans 1lb", 13.00m },
                    { 10, "Espresso", "Espresso blend coffee beans 1lb", 11.00m }
                });

            // Seed Baskets
            migrationBuilder.InsertData(
                table: "Basket",
                columns: new[] { "IdBasket", "IdShopper", "Quantity", "SubTotal", "OrderDate" },
                values: new object[,]
                {
                    { 3,  1, 2, 20.80m, new DateTime(2024, 1, 10) },
                    { 4,  1, 1, 28.50m, new DateTime(2024, 1, 15) },
                    { 5,  2, 3, 42.98m, new DateTime(2024, 2, 5)  },
                    { 6,  2, 1, 10.00m, new DateTime(2024, 2, 20) },
                    { 7,  3, 2, 21.80m, new DateTime(2024, 3, 1)  },
                    { 8,  3, 1, 12.99m, new DateTime(2024, 3, 12) },
                    { 9,  3, 2, 23.99m, new DateTime(2024, 3, 25) },
                    { 10, 4, 1, 10.80m, new DateTime(2024, 4, 3)  },
                    { 11, 4, 2, 22.00m, new DateTime(2024, 4, 18) },
                    { 12, 5, 1, 29.50m, new DateTime(2024, 5, 7)  },
                    { 15, 6, 3, 33.99m, new DateTime(2024, 5, 22) },
                    { 16, 6, 2, 21.60m, new DateTime(2024, 6, 1)  }
                });

            // Seed BasketItems
            migrationBuilder.InsertData(
                table: "BasketItem",
                columns: new[] { "IdBasketItem", "IdBasket", "IdProduct", "Quantity" },
                values: new object[,]
                {
                    { 15, 3,  6, 1 },
                    { 16, 3,  8, 2 },
                    { 17, 4,  4, 1 },
                    { 18, 5,  3, 1 },
                    { 19, 5,  5, 1 },
                    { 20, 5,  6, 1 },
                    { 21, 6,  6, 1 },
                    { 22, 7,  7, 1 },
                    { 23, 7,  8, 1 },
                    { 24, 8,  5, 1 },
                    { 25, 9,  2, 1 },
                    { 26, 9,  6, 1 },
                    { 27, 10, 8, 1 },
                    { 28, 11, 9, 1 },
                    { 29, 11, 10,1 },
                    { 30, 12, 1, 1 },
                    { 31, 15, 3, 1 },
                    { 32, 15, 5, 1 },
                    { 33, 15, 6, 1 },
                    { 34, 16, 7, 1 },
                    { 35, 16, 8, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "BasketItem", keyColumn: "IdBasketItem",
                keyValues: new object[] { 15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35 });
            migrationBuilder.DeleteData(table: "Basket", keyColumn: "IdBasket",
                keyValues: new object[] { 3,4,5,6,7,8,9,10,11,12,15,16 });
            migrationBuilder.DeleteData(table: "Product", keyColumn: "IdProduct",
                keyValues: new object[] { 1,2,3,4,5,6,7,8,9,10 });
            migrationBuilder.DeleteData(table: "Shopper", keyColumn: "IdShopper",
                keyValues: new object[] { 1,2,3,4,5,6 });
        }
    }
}
