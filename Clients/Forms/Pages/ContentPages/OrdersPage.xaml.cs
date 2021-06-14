using NotatnikMechanika.Forms.Pages.ContentViews;

namespace NotatnikMechanika.Forms.Pages
{
    public partial class OrdersPage
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