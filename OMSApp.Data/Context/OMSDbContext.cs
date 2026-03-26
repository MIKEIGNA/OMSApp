// Context/OMSDbContext.cs
using Microsoft.EntityFrameworkCore;

public class OMSDbContext : DbContext
{
    public DbSet<Shopper> Shoppers { get; set; }
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
        modelBuilder.Entity<Shopper>().HasKey(s => s.IdShopper);
        modelBuilder.Entity<Basket>().HasKey(b => b.IdBasket);
        modelBuilder.Entity<Product>().HasKey(p => p.IdProduct);
        modelBuilder.Entity<BasketItem>().HasKey(bi => bi.IdBasketItem);

        modelBuilder.Entity<Basket>()
            .HasOne(b => b.Shopper)
            .WithMany(s => s.Baskets)
            .HasForeignKey(b => b.IdShopper)
            .OnDelete(DeleteBehavior.Cascade);

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

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Basket>()
            .Property(b => b.SubTotal)
            .HasPrecision(18, 2);

        // Map to the OMS.sql table names
        modelBuilder.Entity<Shopper>().ToTable("Shopper");
        modelBuilder.Entity<Basket>().ToTable("Basket");
        modelBuilder.Entity<Product>().ToTable("Product");
        modelBuilder.Entity<BasketItem>().ToTable("BasketItem");
    }
}
