using MvvmCross.Navigation;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Car;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Core.ViewModels
{
    class AddCarViewModel : AddingViewModelBase<CarModel>
    {
        protected override string errorMessage { get; set; } = "Błąd podczas dodawania samochodu.";
        protected override string succesMessage { get; set; } = "Samochód został dodany pomyślnie.";

        public AddCarViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
            : base(httpRequestService, navigationService, messageDialogService)
        {

        }
    }
}
