// Interfaces/IOMSService.cs
public interface IOMSService
{
    List<Basket> GetBaskets();
    List<BasketItem> GetBasketItems(int basketId);
    List<Product> GetProducts();

    bool AddBasketItem(BasketItem item, out string message);

}