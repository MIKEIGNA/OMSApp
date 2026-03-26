// Interfaces/IOMSService.cs
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IOMSService
{
    Task<List<Basket>> GetBasketsAsync();
    Task<List<BasketItem>> GetBasketItemsAsync(int basketId);
    Task<List<Product>> GetProductsAsync();
    Task<bool> AddBasketItemAsync(int basketId, int productId, int quantity);
}
