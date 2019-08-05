using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.Core.ViewModels;
using NotatnikMechanika.Shared.Models.Order;
using NotatnikMechanika.WPF.Presenters.Attributes;
using System.Windows.Controls;

namespace NotatnikMechanika.WPF.Views
{
    [MasterDetailPage(Position = MasterDetailPageAttribute.MasterDetailPosition.Detail)]
    public partial class OrdersView : MvxWpfView
    {
        public OrdersView()
        {
            InitializeComponent();
        }
        private void ListView_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            int id = ((sender as ListView).SelectedItem as OrderModel).Id;

            (ViewModel as OrdersViewModel).OrderSelectedCommand.Execute(id);
        }
    }
}