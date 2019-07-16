using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using NotatnikMechanika.Core.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotatnikMechanika.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(Animated = false, NoHistory = true, WrapInNavigationPage = false)]
    public partial class LoginView : MvxContentPage<LoginViewModel>
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private async void IconAnimation()
        {
            // await appIcon.TranslateTo(0, 0, 230);
            await Task.Delay(230);

            await Task.WhenAll(
                appIcon.TranslateTo(0, -250, 1100, Easing.CubicOut),
                loginPanel.FadeTo(100, 1300, Easing.CubicIn)
                );
            //await appIcon.TranslateTo(0, -250, 1150, Easing.CubicOut);
            //await loginPanel.FadeTo(100, 500, Easing.CubicIn);
        }
        protected override void OnAppearing()
        {
            IconAnimation();
        }
    }
}