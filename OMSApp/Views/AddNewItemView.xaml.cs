// Views/AddNewItemView.xaml.cs
using System.Windows;

namespace OMSApp.Views
{
    public partial class AddNewItemView : Window
    {
        public AddNewItemView(int basketId)
        {
            InitializeComponent();
            DataContext = new AddNewItemViewModel(basketId);
        }
    }
}