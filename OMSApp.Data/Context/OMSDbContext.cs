// Context/OMSDbContext.cs
using Microsoft.EntityFrameworkCore;

public class OMSDbContext : DbContext
{
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "Server=(localdb)\\MSSQLLocalDB;Database=OMS_DB;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ========================
        // PRIMARY KEYS
        // ========================
        modelBuilder.Entity<Basket>()
            .HasKey(b => b.IdBasket);

        modelBuilder.Entity<Product>()
            .HasKey(p => p.IdProduct);

        modelBuilder.Entity<BasketItem>()
            .HasKey(bi => bi.IdBasketItem);

        // ========================
        // RELATIONSHIPS (CRITICAL FIX)
        // ========================
        modelBuilder.Entity<BasketItem>()
            .HasOne(bi => bi.Basket)
            .WithMany(b => b.BasketItems)
            .HasForeignKey(bi => bi.IdBasket)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BasketItem>()
            .HasOne(bi => bi.Product)
            .WithMany()
            .HasForeignKey(bi => bi.IdProduct)
            .OnDelete(DeleteBehavior.Restrict);

        // ========================
        // PROPERTY CONFIG
        // ========================
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

        // ========================
        // SEED DATA
        // ========================
        modelBuilder.Entity<Basket>().HasData(
            new Basket { IdBasket = 1, CustomerName = "John Doe" },
            new Basket { IdBasket = 2, CustomerName = "Jane Smith" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { IdProduct = 1, ProductName = "Laptop", Price = 1000 },
            new Product { IdProduct = 2, ProductName = "Mouse", Price = 20 },
            new Product { IdProduct = 3, ProductName = "Keyboard", Price = 50 }
        );
    }
}