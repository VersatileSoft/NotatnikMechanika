using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using PropertyChanged;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel : MvxViewModel
    {

        private IMvxNavigationService _navigationService;

        public MainPageViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            ShowMenu();
        }

        public void ShowMenu()
        {
            _navigationService.Navigate<MenuViewModel>();
            _navigationService.Navigate<ContentViewModel>();
        }
    }
}