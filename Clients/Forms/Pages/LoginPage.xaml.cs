using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotatnikMechanika.Forms.Pages
{
    public partial class LoginPage
    {
        public LoginPage()
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