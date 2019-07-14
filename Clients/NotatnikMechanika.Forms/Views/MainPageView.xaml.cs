using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using NotatnikMechanika.Core.ViewModels;
using NotatnikMechanika.Forms.Views.CustomViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotatnikMechanika.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ShellPage(ViewModelType = typeof(MainPageViewModel), ViewType = typeof(MainPageView))]
    public partial class MainPageView : MvxShell<MainPageViewModel>
    {
        
        public MainPageView()
        {
            InitializeComponent();
        }
    }
}