using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using PropertyChanged;

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
            NavigateCommand = new MvxCommand<string>(NavigateTo);
        }

        public void NavigateTo(string viewName)
        {
            switch (viewName)
            {
                case "Orders":
                    _navigationService.Navigate<OrdersViewModel>();
                    break;
                case "Clients":
                    _navigationService.Navigate<ClientsViewModel>();
                    break;
                case "Services":

                    break;
                case "Archives":

                    break;
                case "Invoices":

                    break;
                case "Magazine":

                    break;
            }
        }


    }
}
