using MvvmPackage.Wpf.Pages;
using NotatnikMechanika.Core.PageModels;

namespace NotatnikMechanika.WPF.Pages
{
    /// <summary>
    /// Interaction logic for ServicesPage.xaml
    /// </summary>
   // [MasterDetailPage(Position = MasterDetailPageAttribute.MasterDetailPosition.Detail)]
    public partial class ServicesPage : MvWpfPage<ServicesPageModel>
    {
        public ServicesPage()
        {
            InitializeComponent();
        }

        private void ListPage_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            //int id = ((sender as ListPage).SelectedItem as ServiceModel).Id;
            //(PageModel as ServicesPageModel).ServiceSelectedCommand.Execute(id);
        }
    }
}