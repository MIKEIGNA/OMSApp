// Services/OMSService.cs
using Microsoft.EntityFrameworkCore;

public class OMSService : IOMSService
{
    public List<Basket> GetBaskets()
    {
        using var db = new OMSDbContext();
        return db.Baskets.ToList();
    }

    public List<BasketItem> GetBasketItems(int basketId)
    {
        using var db = new OMSDbContext();

        return db.BasketItems
            .Where(x => x.IdBasket == basketId)
            .Include(x => x.Product)
            .ToList();
    }

    public List<Product> GetProducts()
    {
        using var db = new OMSDbContext();
        return db.Products.ToList();
    }


    public bool AddBasketItem(BasketItem item, out string message)
    {
        try
        {
            using var db = new OMSDbContext();

            db.BasketItems.Add(item);
            db.SaveChanges();

            message = "Item saved successfully!";
            return true;
        }
        catch (Exception ex)
        {
            message = ex.InnerException?.Message ?? ex.Message;
            return false;
        }
    }
}