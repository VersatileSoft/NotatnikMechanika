using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.Core.ViewModels;
using NotatnikMechanika.Shared.Models.Customer;
using NotatnikMechanika.WPF.Presenters.Attributes;
using System.Windows.Controls;

namespace NotatnikMechanika.WPF.Views
{
    [MasterDetailPage(Position = MasterDetailPageAttribute.MasterDetailPosition.Detail)]
    public partial class CustomersView : MvxWpfView
    {
        public CustomersView()
        {
            InitializeComponent();
        }

        private void ListView_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            int id = ((sender as ListView).SelectedItem as CustomerModel).Id;
            (ViewModel as CustomersViewModel).CustomerSelectedCommand.Execute(id);
        }
    }
}