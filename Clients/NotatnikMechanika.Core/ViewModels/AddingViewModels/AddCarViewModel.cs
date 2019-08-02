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
        public override string SuccesMessage { get; set; } = "Samochód został dodany pomyślnie.";

        public AddCarViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
            : base(httpRequestService, navigationService, messageDialogService)
        {

        }

        public override void Prepare(int customerId)
        {
            Model.CustomerId = customerId;
        }
    }
}
