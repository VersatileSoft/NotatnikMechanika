using MvvmPackage.Xamarin.Pages;
using NotatnikMechanika.Core.PageModels;

namespace NotatnikMechanika.Forms.Pages
{
    public partial class CustomersPage : MvContentPage<CustomersPageModel>
    {
        public CustomersPage()
        {
            InitializeComponent();
        }

        //private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    int id = ((sender as CollectionView).SelectedItem as CustomerModel).Id;

        //    (ViewModel as CustomersViewModel).CustomerSelectedCommand.Execute(id);
        //}
    }
}