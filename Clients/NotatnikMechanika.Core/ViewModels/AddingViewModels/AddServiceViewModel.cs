using MvvmCross.Navigation;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Core.ViewModels
{
    class AddServiceViewModel : AddingViewModelBase<ServiceModel>
    {
        protected override string errorMessage { get; set; } = "Błąd podczas dodawania usługi.";
        protected override string succesMessage { get; set; } = "Usługa została dodana pomyślnie.";

        public AddServiceViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
            : base(httpRequestService, navigationService, messageDialogService)
        {

        }
    }
}
