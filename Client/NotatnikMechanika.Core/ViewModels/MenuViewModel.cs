using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MenuViewModel : MvxViewModel
    {
        public IMvxCommand NavigateCommand { get; set; }
        private IMvxNavigationService _navigationService;
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
