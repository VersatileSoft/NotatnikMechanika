using NotatnikMechanika.Core.ViewModels;
using NotatnikMechanika.Forms.Views.CustomViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotatnikMechanika.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageView : MvxShell<MainPageViewModel>
    {
        public MainPageView()
        {
            InitializeComponent();
        }
    }
}