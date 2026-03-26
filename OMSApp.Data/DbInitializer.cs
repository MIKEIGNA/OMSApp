// DbInitializer.cs
using Microsoft.EntityFrameworkCore;

public static class DbInitializer
{
    public static void Initialize()
    {
        using var db = new OMSDbContext();

        // Create the database if it doesn't exist
        db.Database.EnsureCreated();

        // If there's already data, skip seeding
        if (db.Shoppers.Any()) return;

        // ── Shoppers ──────────────────────────────────────────────
        var shoppers = new[]
        {
            new Shopper { IdShopper = 1, Email = "crackjack@aol.com", FirstName = "Jack",   LastName = "Crack",  Address = "123 Main St",  City = "New York",     StateProvince = "NY", Country = "USA", ZipCode = "10001" },
            new Shopper { IdShopper = 2, Email = "marg5@infi.net",    FirstName = "Marg",   LastName = "Smith",  Address = "456 Oak Ave",  City = "Chicago",      StateProvince = "IL", Country = "USA", ZipCode = "60601" },
            new Shopper { IdShopper = 3, Email = "ratboy@msn.net",    FirstName = "Rat",    LastName = "Boy",    Address = "789 Pine Rd",  City = "Houston",      StateProvince = "TX", Country = "USA", ZipCode = "77001" },
            new Shopper { IdShopper = 4, Email = "kids2@xis.net",     FirstName = "Kids",   LastName = "Two",    Address = "321 Elm St",   City = "Phoenix",      StateProvince = "AZ", Country = "USA", ZipCode = "85001" },
            new Shopper { IdShopper = 5, Email = "scott1@odu.edu",    FirstName = "Scott",  LastName = "One",    Address = "654 Maple Dr", City = "Philadelphia", StateProvince = "PA", Country = "USA", ZipCode = "19101" },
            new Shopper { IdShopper = 6, Email = "spider@web.net",    FirstName = "Spider", LastName = "Web",    Address = "987 Cedar Ln", City = "San Antonio",  StateProvince = "TX", Country = "USA", ZipCode = "78201" },
        };
        db.Shoppers.AddRange(shoppers);
        db.SaveChanges();

        // ── Products ──────────────────────────────────────────────
        var products = new[]
        {
            new Product { IdProduct = 1,  ProductName = "Capressobar Model #351",    Description = "Espresso machine model 351",      Price = 29.50m },
            new Product { IdProduct = 2,  ProductName = "Capresso Ultima",           Description = "Ultima espresso machine",         Price = 49.99m },
            new Product { IdProduct = 3,  ProductName = "Eileen 4-cup French Press", Description = "4-cup French press coffee maker", Price = 19.99m },
            new Product { IdProduct = 4,  ProductName = "Coffee Grinder",            Description = "Electric coffee grinder",         Price = 28.50m },
            new Product { IdProduct = 5,  ProductName = "Sumatra",                   Description = "Sumatra coffee beans 1lb",        Price = 12.99m },
            new Product { IdProduct = 6,  ProductName = "Guatamala",                 Description = "Guatemala coffee beans 1lb",      Price = 10.00m },
            new Product { IdProduct = 7,  ProductName = "Columbia",                  Description = "Colombia coffee beans 1lb",       Price = 11.50m },
            new Product { IdProduct = 8,  ProductName = "Brazil",                    Description = "Brazil coffee beans 1lb",         Price = 10.80m },
            new Product { IdProduct = 9,  ProductName = "Ethiopia",                  Description = "Ethiopia coffee beans 1lb",       Price = 13.00m },
            new Product { IdProduct = 10, ProductName = "Espresso",                  Description = "Espresso blend coffee beans 1lb", Price = 11.00m },
        };
        db.Products.AddRange(products);
        db.SaveChanges();

        // ── Baskets ───────────────────────────────────────────────
        var baskets = new[]
        {
            new Basket { IdBasket = 3,  IdShopper = 1, Quantity = 2, SubTotal = 20.80m, OrderDate = new DateTime(2024, 1, 10) },
            new Basket { IdBasket = 4,  IdShopper = 1, Quantity = 1, SubTotal = 28.50m, OrderDate = new DateTime(2024, 1, 15) },
            new Basket { IdBasket = 5,  IdShopper = 2, Quantity = 3, SubTotal = 42.98m, OrderDate = new DateTime(2024, 2,  5) },
            new Basket { IdBasket = 6,  IdShopper = 2, Quantity = 1, SubTotal = 10.00m, OrderDate = new DateTime(2024, 2, 20) },
            new Basket { IdBasket = 7,  IdShopper = 3, Quantity = 2, SubTotal = 21.80m, OrderDate = new DateTime(2024, 3,  1) },
            new Basket { IdBasket = 8,  IdShopper = 3, Quantity = 1, SubTotal = 12.99m, OrderDate = new DateTime(2024, 3, 12) },
            new Basket { IdBasket = 9,  IdShopper = 3, Quantity = 2, SubTotal = 23.99m, OrderDate = new DateTime(2024, 3, 25) },
            new Basket { IdBasket = 10, IdShopper = 4, Quantity = 1, SubTotal = 10.80m, OrderDate = new DateTime(2024, 4,  3) },
            new Basket { IdBasket = 11, IdShopper = 4, Quantity = 2, SubTotal = 22.00m, OrderDate = new DateTime(2024, 4, 18) },
            new Basket { IdBasket = 12, IdShopper = 5, Quantity = 1, SubTotal = 29.50m, OrderDate = new DateTime(2024, 5,  7) },
            new Basket { IdBasket = 15, IdShopper = 6, Quantity = 3, SubTotal = 33.99m, OrderDate = new DateTime(2024, 5, 22) },
            new Basket { IdBasket = 16, IdShopper = 6, Quantity = 2, SubTotal = 21.60m, OrderDate = new DateTime(2024, 6,  1) },
        };
        db.Baskets.AddRange(baskets);
        db.SaveChanges();

        // ── BasketItems ───────────────────────────────────────────
        var items = new[]
        {
            new BasketItem { IdBasketItem = 15, IdBasket = 3,  IdProduct = 6,  Quantity = 1 },
            new BasketItem { IdBasketItem = 16, IdBasket = 3,  IdProduct = 8,  Quantity = 2 },
            new BasketItem { IdBasketItem = 17, IdBasket = 4,  IdProduct = 4,  Quantity = 1 },
            new BasketItem { IdBasketItem = 18, IdBasket = 5,  IdProduct = 3,  Quantity = 1 },
            new BasketItem { IdBasketItem = 19, IdBasket = 5,  IdProduct = 5,  Quantity = 1 },
            new BasketItem { IdBasketItem = 20, IdBasket = 5,  IdProduct = 6,  Quantity = 1 },
            new BasketItem { IdBasketItem = 21, IdBasket = 6,  IdProduct = 6,  Quantity = 1 },
            new BasketItem { IdBasketItem = 22, IdBasket = 7,  IdProduct = 7,  Quantity = 1 },
            new BasketItem { IdBasketItem = 23, IdBasket = 7,  IdProduct = 8,  Quantity = 1 },
            new BasketItem { IdBasketItem = 24, IdBasket = 8,  IdProduct = 5,  Quantity = 1 },
            new BasketItem { IdBasketItem = 25, IdBasket = 9,  IdProduct = 2,  Quantity = 1 },
            new BasketItem { IdBasketItem = 26, IdBasket = 9,  IdProduct = 6,  Quantity = 1 },
            new BasketItem { IdBasketItem = 27, IdBasket = 10, IdProduct = 8,  Quantity = 1 },
            new BasketItem { IdBasketItem = 28, IdBasket = 11, IdProduct = 9,  Quantity = 1 },
            new BasketItem { IdBasketItem = 29, IdBasket = 11, IdProduct = 10, Quantity = 1 },
            new BasketItem { IdBasketItem = 30, IdBasket = 12, IdProduct = 1,  Quantity = 1 },
            new BasketItem { IdBasketItem = 31, IdBasket = 15, IdProduct = 3,  Quantity = 1 },
            new BasketItem { IdBasketItem = 32, IdBasket = 15, IdProduct = 5,  Quantity = 1 },
            new BasketItem { IdBasketItem = 33, IdBasket = 15, IdProduct = 6,  Quantity = 1 },
            new BasketItem { IdBasketItem = 34, IdBasket = 16, IdProduct = 7,  Quantity = 1 },
            new BasketItem { IdBasketItem = 35, IdBasket = 16, IdProduct = 8,  Quantity = 1 },
        };
        db.BasketItems.AddRange(items);
        db.SaveChanges();
    }
}
