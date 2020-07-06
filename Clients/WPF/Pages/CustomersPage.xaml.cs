using MvvmPackage.Wpf.Pages;
using NotatnikMechanika.Core.PageModels;
using NotatnikMechanika.Shared.Models.Customer;
using System.Windows.Controls;

namespace NotatnikMechanika.WPF.Pages
{
    public partial class CustomersPage : MvWpfPage<CustomersPageModel>
    {
        public CustomersPage()
        {
            InitializeComponent();
        }

        private void ListPage_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            int id = ((sender as ListView)?.SelectedItem as CustomerModel)?.Id ?? 0;
            PageModel.CustomerSelectedCommand.Execute(id);
        }
    }
}