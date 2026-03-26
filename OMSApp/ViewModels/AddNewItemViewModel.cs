// ViewModels/AddNewItemViewModel.cs
using System;
using System.Collections.ObjectModel;
using System.Windows;

public class AddNewItemViewModel : BaseViewModel
{
    private readonly OMSService _service = new OMSService();

    public Action? OnSaved { get; set; }
    public Action? OnCancelled { get; set; }

    public ObservableCollection<Basket> Baskets { get; set; } = new();
    public ObservableCollection<Product> Products { get; set; } = new();

    private Basket? _selectedBasket;
    public Basket? SelectedBasket
    {
        get => _selectedBasket;
        set { _selectedBasket = value; OnPropertyChanged(nameof(SelectedBasket)); }
    }

    private Product? _selectedProduct;
    public Product? SelectedProduct
    {
        get => _selectedProduct;
        set { _selectedProduct = value; OnPropertyChanged(nameof(SelectedProduct)); }
    }

    private int _quantity;
    public int Quantity
    {
        get => _quantity;
        set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
    }

    public RelayCommand SaveCommand { get; }
    public RelayCommand CancelCommand { get; }

    public AddNewItemViewModel()
    {
        SaveCommand = new RelayCommand(async () => await SaveAsync());
        CancelCommand = new RelayCommand(() => OnCancelled?.Invoke());
        _ = LoadDataAsync();
    }

    private async System.Threading.Tasks.Task LoadDataAsync()
    {
        var baskets = await _service.GetBasketsAsync();
        Baskets = new ObservableCollection<Basket>(baskets);
        OnPropertyChanged(nameof(Baskets));

        var products = await _service.GetProductsAsync();
        Products = new ObservableCollection<Product>(products);
        OnPropertyChanged(nameof(Products));
    }

    private async System.Threading.Tasks.Task SaveAsync()
    {
        if (SelectedBasket == null || SelectedProduct == null || Quantity <= 0)
        {
            MessageBox.Show("Please select a basket, a product, and enter a valid quantity.",
                            "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        await _service.AddBasketItemAsync(SelectedBasket.IdBasket, SelectedProduct.IdProduct, Quantity);
        OnSaved?.Invoke();
    }
}
