// Entities/Basket.cs
public class Basket
{
    public int IdBasket { get; set; }
    public int IdShopper { get; set; }
    public int Quantity { get; set; }
    public decimal SubTotal { get; set; }
    public DateTime OrderDate { get; set; }

    public Shopper Shopper { get; set; } = null!;
    public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();

    // Display text for ComboBox: "email IdBasket"
    public string DisplayText => $"{Shopper?.Email} {IdBasket}";
}
