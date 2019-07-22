using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Order;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels
{
    public class AddOrderViewModel : AddingViewModelBase<OrderModel>
    {

        protected override string errorMessage { get; set; } = "Błąd podczas dodawania zlecenia. ";
        protected override string succesMessage { get; set; } = "Zlecenie zostało dodane pomyślnie.";
        public AddOrderViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
            : base(httpRequestService, navigationService, messageDialogService)
        {
        }
    }
}
