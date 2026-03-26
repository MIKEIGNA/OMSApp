// ViewModels/MainViewModel.cs
using System.Collections.ObjectModel;
using OMSApp.Views;
public class MainViewModel : BaseViewModel
{
    private readonly OMSService _service = new OMSService();

    public ObservableCollection<Basket> Baskets { get; set; }
    public ObservableCollection<BasketItem> BasketItems { get; set; }

    private Basket _selectedBasket;
    public Basket SelectedBasket
    {
        get => _selectedBasket;
        set
        {
            _selectedBasket = value;
            OnPropertyChanged(nameof(SelectedBasket));
            LoadItems();
        }
    }

    public RelayCommand AddItemCommand { get; }

    public MainViewModel()
    {
        LoadBaskets();
        BasketItems = new ObservableCollection<BasketItem>();
        AddItemCommand = new RelayCommand(OpenAddItem);
    }

    private void LoadBaskets()
    {
        Baskets = new ObservableCollection<Basket>(_service.GetBaskets());
    }

    private void LoadItems()
    {
        if (SelectedBasket == null) return;

        BasketItems = new ObservableCollection<BasketItem>(
            _service.GetBasketItems(SelectedBasket.IdBasket)
        );

        OnPropertyChanged(nameof(BasketItems));
    }

    private void OpenAddItem()
    {
        if (SelectedBasket == null)
        {
            System.Windows.MessageBox.Show("Select a basket first!");
            return;
        }

        var window = new AddNewItemView(SelectedBasket.IdBasket);
        window.ShowDialog();

        LoadItems();
    }
}