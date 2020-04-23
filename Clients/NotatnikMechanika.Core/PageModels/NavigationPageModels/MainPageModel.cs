using MvvmPackage.Core;
using PropertyChanged;
using Xamarin.MVVMPackage;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageModel : PageModelBase
    {
        //private readonly IMvxNavigationService _navigationService;

        //public MainPageModel(IMvxNavigationService navigationService)
        //{
        //    _navigationService = navigationService;
        //}

        //public override async void ViewAppearing()
        //{
        //    base.ViewAppearing();
        //    await _navigationService.Navigate<MenuViewModel>();
        //    await _navigationService.Navigate<OrdersViewModel>();
        //}
    }
}