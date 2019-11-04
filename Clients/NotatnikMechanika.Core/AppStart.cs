using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.ViewModels;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core
{
    public class AppStart : MvxAppStart
    {
        private readonly ISettingsService _settingsService;

        public AppStart(IMvxApplication application, IMvxNavigationService navigationService, ISettingsService settingsService) : base(application, navigationService)
        {
            _settingsService = settingsService;
        }

        protected override async Task NavigateToFirstViewModel(object hint = null)
        {
            bool isAuthenticated = !string.IsNullOrEmpty(_settingsService.Token);

            if (isAuthenticated)
            {
                await NavigationService.Navigate<MainPageViewModel>();
            }
            else
            {
                await NavigationService.Navigate<LoginViewModel>();
            }
        }
    }
}