using MvvmPackage.Wpf.Pages;
using NotatnikMechanika.Core.Models;
using NotatnikMechanika.Core.PageModels;
using System.Windows;
using System.Windows.Controls;

namespace NotatnikMechanika.WPF.Pages
{
    /// <summary>
    /// Interaction logic for ArchivedOrdersPage.xaml
    /// </summary>
   // [MasterDetailPage(Position = MasterDetailPageAttribute.MasterDetailPosition.Detail)]
    public partial class ArchivedOrdersPage : MvWpfPage<ArchivedOrdersPageModel>
    {
        public ArchivedOrdersPage()
        {
            InitializeComponent();
        }

        private void ListPage_Selected(object sender, RoutedEventArgs e)
        {
            //OrderExtendedModel model = (sender as ListPage).SelectedItem as OrderExtendedModel;
            //(PageModel as ArchivedOrdersPageModel).ArchivedOrderSelectedCommand.Execute(model);
        }
    }
}