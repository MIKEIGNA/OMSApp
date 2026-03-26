// ViewModels/ListOrderDetailsViewModel.cs
using System.Collections.ObjectModel;

public class ListOrderDetailsViewModel : BaseViewModel
{
    private readonly OMSService _service = new OMSService();

    public ObservableCollection<Basket> Baskets { get; set; } = new();
    public ObservableCollection<BasketItem> BasketItems { get; set; } = new();

    private Basket? _selectedBasket;
    public Basket? SelectedBasket
    {
        get => _selectedBasket;
        set
        {
            _selectedBasket = value;
            OnPropertyChanged(nameof(SelectedBasket));
            _ = LoadBasketItemsAsync();
        }
    }

    public ListOrderDetailsViewModel()
    {
        _ = LoadBasketsAsync();
    }

    private async System.Threading.Tasks.Task LoadBasketsAsync()
    {
        var baskets = await _service.GetBasketsAsync();
        Baskets = new ObservableCollection<Basket>(baskets);
        OnPropertyChanged(nameof(Baskets));
    }

    private async System.Threading.Tasks.Task LoadBasketItemsAsync()
    {
        if (_selectedBasket == null) return;
        var items = await _service.GetBasketItemsAsync(_selectedBasket.IdBasket);
        BasketItems = new ObservableCollection<BasketItem>(items);
        OnPropertyChanged(nameof(BasketItems));
    }

    public void RefreshBasketItems()
    {
        _ = LoadBasketItemsAsync();
    }
}
