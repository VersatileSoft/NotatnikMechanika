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
        public override string ErrorMessage { get; set; } = "Błąd podczas dodawania usługi.";
        public override string SuccesMessage { get; set; } = "Usługa została dodana pomyślnie.";

        public AddServiceViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
            : base(httpRequestService, navigationService, messageDialogService)
        {

        }
    }
}
