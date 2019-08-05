using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.ViewModels.ContentViewModels;
using PropertyChanged;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MenuViewModel : MvxViewModel
    {
        public IMvxCommand NavigateCommand { get; set; }
        public IMvxCommand LogoutCommand { get; set; }
        private readonly IMvxNavigationService _navigationService;
        private readonly ISettingsService _settingsService;


        public MenuViewModel(IMvxNavigationService navigationService, ISettingsService settingsService)
        {
            _navigationService = navigationService;
            _settingsService = settingsService;
            NavigateCommand = new MvxAsyncCommand<string>(NavigateTo);
            LogoutCommand = new MvxAsyncCommand(LogoutAction);
        }

        public async Task LogoutAction()
        {
            _settingsService.Token = "";
            await _navigationService.Navigate<LoginViewModel>();
        }

        public async Task NavigateTo(string viewName)
        {
            switch (viewName)
            {
                case "Orders":
                    await _navigationService.Navigate<OrdersViewModel>();
                    break;
                case "Clients":
                    await _navigationService.Navigate<CustomersViewModel>();
                    break;
                case "Services":
                    await _navigationService.Navigate<ServicesViewModel>();
                    break;
                case "Archives":
                    await _navigationService.Navigate<ArchivedOrdersViewModel>();
                    break;
                case "Receipts":

                    break;
                case "Warehouse":
                    await _navigationService.Navigate<CommoditiesViewModel>();
                    break;
            }
        }
    }
}
