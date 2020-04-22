using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.Core.Models;
using NotatnikMechanika.Core.PageModels;
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
            OrderExtendedModel model = (sender as ListView).SelectedItem as OrderExtendedModel;
            (ViewModel as OrdersViewModel).OrderSelectedCommand.Execute(model);
        }
    }
}