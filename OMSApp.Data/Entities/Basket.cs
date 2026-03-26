// Entities/Basket.cs

public class Basket
{
    public int IdBasket { get; set; }
    public string CustomerName { get; set; }
    public string DisplayText => $"{CustomerName} (ID: {IdBasket})";
    public ICollection<BasketItem> BasketItems { get; set; }
}