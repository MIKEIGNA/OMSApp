// ViewModels/MainViewModel.cs
using System.Windows;

public class MainViewModel : BaseViewModel
{
    private object _currentView;
    public object CurrentView
    {
        get => _currentView;
        set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
    }

    public RelayCommand ShowListOrderDetailsCommand { get; }
    public RelayCommand ShowAddNewItemCommand { get; }
    public RelayCommand ExitCommand { get; }

    private ListOrderDetailsViewModel _listOrderDetailsVM;

    public MainViewModel()
    {
        _listOrderDetailsVM = new ListOrderDetailsViewModel();

        ShowListOrderDetailsCommand = new RelayCommand(ShowListOrderDetails);
        ShowAddNewItemCommand = new RelayCommand(ShowAddNewItem);
        ExitCommand = new RelayCommand(() => Application.Current.Shutdown());

        // Default view
        ShowListOrderDetails();
    }

    private void ShowListOrderDetails()
    {
        CurrentView = _listOrderDetailsVM;
    }

    private void ShowAddNewItem()
    {
        var vm = new AddNewItemViewModel();
        vm.OnSaved = () =>
        {
            // Refresh list and navigate back
            _listOrderDetailsVM.RefreshBasketItems();
            ShowListOrderDetails();
        };
        vm.OnCancelled = ShowListOrderDetails;
        CurrentView = vm;
    }
}
