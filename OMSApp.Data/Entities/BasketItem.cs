// Entities/BasketItem.cs
public class BasketItem
{
    public int IdBasketItem { get; set; }
    public int IdProduct { get; set; }
    public int Quantity { get; set; }
    public int IdBasket { get; set; }

    public Basket Basket { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
