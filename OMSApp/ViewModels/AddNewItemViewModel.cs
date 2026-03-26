// ViewModels/AddNewItemModel.cs

using System.Collections.ObjectModel;
using System.Windows;

public class AddNewItemViewModel : BaseViewModel
{
    private readonly OMSService _service = new OMSService();

    public int BasketId { get; }

    public ObservableCollection<Product> Products { get; set; }

    public Product SelectedProduct { get; set; }


    private int _quantity;
    public int Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            OnPropertyChanged(nameof(Quantity));
        }
    }

    public RelayCommand SaveCommand { get; }

    public AddNewItemViewModel(int basketId)
    {
        BasketId = basketId;
        Products = new ObservableCollection<Product>(_service.GetProducts());

        SaveCommand = new RelayCommand(Save);
    }

    private void Save()
    {
        if (SelectedProduct == null || Quantity <= 0)
        {
            System.Windows.MessageBox.Show("Select product and enter valid quantity!");
            return;
        }


        var item = new BasketItem
        {
            IdBasket = BasketId,
            IdProduct = SelectedProduct.IdProduct,
            Quantity = Quantity
        };


        var success = _service.AddBasketItem(item, out string msg);

        System.Windows.MessageBox.Show(msg);

        if (success)
        {
            System.Windows.Application.Current.Windows
                .OfType<System.Windows.Window>()
                .SingleOrDefault(w => w.IsActive)
                ?.Close();
        }
    }
}