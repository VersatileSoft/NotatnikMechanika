using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Core.Interfaces;
using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.MVVMPackage.Commands;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class MyAccountPageModel : PageModelBase
    {
        private readonly IMvNavigationService _navigationService;
        private readonly ISettingsService _settingsService;

        public ICommand LogoutCommand { get; set; }

        public MyAccountPageModel(IMvNavigationService navigationService, ISettingsService settingsService)
        {
            _navigationService = navigationService;
            _settingsService = settingsService;

            LogoutCommand = new AsyncCommand(LogoutAction);
        }

        private Task LogoutAction()
        {
            _settingsService.Token = null;
            return _navigationService.ReloadMainPage<MainPageService>();
        }
    }
}
