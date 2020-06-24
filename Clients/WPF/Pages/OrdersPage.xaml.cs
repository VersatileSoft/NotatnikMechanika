using MvvmPackage.Wpf.Pages;
using NotatnikMechanika.Core.PageModels;

namespace NotatnikMechanika.WPF.Pages
{
    // [MasterDetailPage(Position = MasterDetailPageAttribute.MasterDetailPosition.Detail)]
    public partial class OrdersPage : MvWpfPage<OrdersPageModel>
    {
        public OrdersPage()
        {
            InitializeComponent();
        }
        private void ListPage_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            //OrderExtendedModel model = (sender as ListPage).SelectedItem as OrderExtendedModel;
            //(PageModel as OrdersPageModel).OrderSelectedCommand.Execute(model);
        }
    }
}