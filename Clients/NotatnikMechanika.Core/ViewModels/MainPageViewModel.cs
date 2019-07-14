using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using PropertyChanged;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel : MvxViewModel
    {

        private readonly IMvxNavigationService _navigationService;

        public MainPageViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            Task.Run(async () =>
            {
                await _navigationService.Navigate<MenuViewModel>();
                await _navigationService.Navigate<OrdersViewModel>();
            });
        }

    }
}