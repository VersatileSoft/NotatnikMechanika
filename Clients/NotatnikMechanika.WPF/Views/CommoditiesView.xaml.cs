using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.Core.ViewModels.ContentViewModels;
using NotatnikMechanika.Shared.Models.Commodity;
using NotatnikMechanika.WPF.Presenters.Attributes;
using System.Windows;
using System.Windows.Controls;

namespace NotatnikMechanika.WPF.Views
{
    /// <summary>
    /// Interaction logic for CommoditiesView.xaml
    /// </summary>
    [MasterDetailPage(Position = MasterDetailPageAttribute.MasterDetailPosition.Detail)]
    public partial class CommoditiesView : MvxWpfView
    {
        public CommoditiesView()
        {
            InitializeComponent();
        }

        private void ListView_Selected(object sender, RoutedEventArgs e)
        {
            int id = ((sender as ListView).SelectedItem as CommodityModel).Id;

            (ViewModel as CommoditiesViewModel).CommoditySelectedCommand.Execute(id);
        }
    }
}
