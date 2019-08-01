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

        public override string ErrorMessage { get; set; } = "Błąd podczas dodawania zlecenia. ";
        public override string SuccesMessage { get; set; } = "Zlecenie zostało dodane pomyślnie.";
        public AddOrderViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
            : base(httpRequestService, navigationService, messageDialogService)
        {
        }
    }
}
