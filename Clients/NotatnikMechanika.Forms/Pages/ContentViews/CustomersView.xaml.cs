using NotatnikMechanika.Core.PageModels;
using NotatnikMechanika.Shared.Models.Customer;
using Xamarin.Forms;
using Xamarin.MVVMPackage.Pages;

namespace NotatnikMechanika.Forms.Views
{
    public partial class CustomersView : MvContentPage<CustomersViewModel>
    {
        public CustomersView()
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