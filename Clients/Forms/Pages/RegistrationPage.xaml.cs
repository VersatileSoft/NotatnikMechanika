using MvvmPackage.Xamarin.Pages;
using NotatnikMechanika.Core.PageModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotatnikMechanika.Forms.Pages
{
    public partial class RegistrationPage : MvContentPage<RegistrationPageModel>
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