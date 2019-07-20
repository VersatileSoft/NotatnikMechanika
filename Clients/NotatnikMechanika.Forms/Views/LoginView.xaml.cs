using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using NotatnikMechanika.Core.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotatnikMechanika.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(Animated = true, NoHistory = true, WrapInNavigationPage = false)]
    public partial class LoginView : MvxContentPage<LoginViewModel>
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private async void SplashAnimation()
        {
            await Task.Delay(230);

            await Task.WhenAll(
                appIcon.TranslateTo(0, -250, 1100, Easing.CubicOut),
                appIcon.ScaleTo(0.75, 1100, Easing.CubicOut),
                loginPanel.FadeTo(100, 1300, Easing.CubicIn)
                );
        }
        protected override void OnAppearing()
        {
            SplashAnimation();
        }
    }
}