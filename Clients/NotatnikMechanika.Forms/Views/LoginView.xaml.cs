using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using NotatnikMechanika.Core.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotatnikMechanika.Forms.Views
{
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
                appLogo.TranslateTo(0, -250, 1100, Easing.CubicOut),
                loginPanel.FadeTo(100, 1300, Easing.CubicIn)
                );

            await appTitle.FadeTo(100, 1000, Easing.CubicIn);
        }
        protected override void OnAppearing()
        {
            StartAnimation();
        }
    }
}