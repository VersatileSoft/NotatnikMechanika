using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using NotatnikMechanika.Core.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotatnikMechanika.Forms.Views
{
    [MvxContentPagePresentation(NoHistory = false, WrapInNavigationPage = true)]
    public partial class RegistrationView : MvxContentPage<RegistrationViewModel>
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        private async void StartAnimation()
        {
            await Task.Delay(230);
            await pageGrid.FadeTo(100, 1500, Easing.SinIn);
        }

        protected override void OnAppearing()
        {
            StartAnimation();
        }
    }
}