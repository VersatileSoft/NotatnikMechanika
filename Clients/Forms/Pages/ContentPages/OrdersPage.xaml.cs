using MvvmPackage.Xamarin.Pages;
using NotatnikMechanika.Core.PageModels;
using NotatnikMechanika.Forms.Pages.ContentViews;

namespace NotatnikMechanika.Forms.Pages
{
    public partial class OrdersPage : MvContentPage<OrdersPageModel>
    {
        public OrdersPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MyAccountPage());
        }
    }
}