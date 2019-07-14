using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using PropertyChanged;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MenuViewModel : MvxViewModel
    {
        public IMvxCommand NavigateCommand { get; set; }
        private readonly IMvxNavigationService _navigationService;
        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new MvxAsyncCommand<string>(NavigateTo);
        }

        public async Task NavigateTo(string viewName)
        {
            switch (viewName)
            {
                case "Orders":
                    await _navigationService.Navigate<OrdersViewModel>();
                    break;
                case "Clients":
                    await _navigationService.Navigate<RegularClientsViewModel>();
                    break;
                case "Services":

                    break;
                case "Archives":

                    break;
                case "Receipts":

                    break;
                case "Warehouse":

                    break;
            }
        }
    }
}
