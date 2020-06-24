using MvvmPackage.Wpf.Pages;
using NotatnikMechanika.Core.PageModels;
using System.Windows;

namespace NotatnikMechanika.WPF.Pages
{
    /// <summary>
    /// Interaction logic for CommoditiesPage.xaml
    /// </summary>
    //[MasterDetailPage(Position = MasterDetailPageAttribute.MasterDetailPosition.Detail)]
    public partial class CommoditiesPage : MvWpfPage<CommoditiesPageModel>
    {
        public CommoditiesPage()
        {
            InitializeComponent();
        }

        private void ListPage_Selected(object sender, RoutedEventArgs e)
        {
            //int id = ((sender as ListPage).SelectedItem as CommodityModel).Id;
            //(PageModel as CommoditiesPageModel).CommoditySelectedCommand.Execute(id);
        }
    }
}