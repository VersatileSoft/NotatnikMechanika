using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotatnikMechanika.Forms.Pages
{
    public partial class RegistrationPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void StartAnimation()
        {
            await Task.Delay(250);
            await pageGrid.FadeTo(100, 1500, Easing.CubicIn);
        }

        protected override void OnAppearing()
        {
            StartAnimation();
        }
    }
}