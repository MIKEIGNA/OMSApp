// Services/OMSService.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class OMSService : IOMSService
{
    public async Task<List<Basket>> GetBasketsAsync()
    {
        using var db = new OMSDbContext();
        return await db.Baskets
            .Include(b => b.Shopper)
            .ToListAsync();
    }

    public async Task<List<BasketItem>> GetBasketItemsAsync(int basketId)
    {
        using var db = new OMSDbContext();
        return await db.BasketItems
            .Where(x => x.IdBasket == basketId)
            .Include(x => x.Product)
            .Include(x => x.Basket)
            .ToListAsync();
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        using var db = new OMSDbContext();
        return await db.Products.ToListAsync();
    }

    public async Task<bool> AddBasketItemAsync(int basketId, int productId, int quantity)
    {
        using var db = new OMSDbContext();

        // IdBasketItem = current max + 1
        int nextId = await db.BasketItems.AnyAsync()
            ? await db.BasketItems.MaxAsync(bi => bi.IdBasketItem) + 1
            : 1;

        var item = new BasketItem
        {
            IdBasketItem = nextId,
            IdBasket = basketId,
            IdProduct = productId,
            Quantity = quantity
        };

        db.BasketItems.Add(item);
        await db.SaveChangesAsync();
        return true;
    }
}
