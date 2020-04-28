using MvvmPackage.Wpf.Pages;
using NotatnikMechanika.Core.PageModels;

namespace NotatnikMechanika.WPF.Pages
{
    //[MasterDetailPage(Position = MasterDetailPageAttribute.MasterDetailPosition.Detail)]
    public partial class CustomersPage : MvWpfPage<CustomersPageModel>
    {
        public CustomersPage()
        {
            InitializeComponent();
        }

       private void ListPage_Selected(object sender, System.Windows.RoutedEventArgs e)
       {
           //int id = ((sender as ListPage).SelectedItem as CustomerModel).Id;
           //(PageModel as CustomersPageModel).CustomerSelectedCommand.Execute(id);
       }
    }
}