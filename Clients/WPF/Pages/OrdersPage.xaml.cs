using MvvmPackage.Wpf.Pages;
using NotatnikMechanika.Core.PageModels;
using NotatnikMechanika.Shared.Models.Order;
using System.Windows.Controls;

namespace NotatnikMechanika.WPF.Pages
{
    public partial class OrdersPage : MvWpfPage<OrdersPageModel>
    {
        public OrdersPage()
        {
            InitializeComponent();
        }
        private void ListPage_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            OrderExtendedModel model = (sender as ListView).SelectedItem as OrderExtendedModel;
            PageModel.OrderSelectedCommand.Execute(model);
        }
    }
}