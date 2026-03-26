// Entities/Product.cs
public class Product
{
    public int IdProduct { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }

    // Display text for ComboBox: "IdProduct ProductName"
    public string DisplayText => $"{IdProduct} {ProductName}";
}
