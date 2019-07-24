using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using NotatnikMechanika.Core.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotatnikMechanika.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(NoHistory = true, WrapInNavigationPage = false)]
    public partial class LoginView : MvxContentPage<LoginViewModel>
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private async void StartAnimation()
        {
            await Task.Delay(230);

            _ = await Task.WhenAll(
                appIcon.TranslateTo(0, -250, 1100, Easing.CubicOut),
                //appIcon.ScaleTo(0.75, 1100, Easing.CubicOut),
                loginPanel.FadeTo(100, 1300, Easing.CubicIn)
                );

            _ = await Task.WhenAll(
                appTitle.TranslateTo(0, -35, 400, Easing.SinOut),
                appTitle.FadeTo(100, 400, Easing.CubicOut)
                );
        }
        protected override void OnAppearing()
        {
            StartAnimation();
        }
    }
}