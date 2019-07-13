using MvvmCross.Forms.Views;
using NotatnikMechanika.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotatnikMechanika.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ShellContentPage(Title = "Zamówienia", Icon = "OrdersIcon.xml")]
    public partial class OrdersView : MvxContentPage<OrdersViewModel>
    {
        public OrdersView()
        {
            InitializeComponent();
        }
    }
}