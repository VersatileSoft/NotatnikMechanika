﻿using NotatnikMechanika.Shared.Models.Customer;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddCustomerPageModel : AddingPageModelBase<CustomerModel>
    {
        public AddCustomerPageModel(MvvmPackage.Core.Services.Interfaces.IMvNavigationService navigationService) : base(navigationService)
        {
        }
        //public override string SuccesMessage { get; set; } = "Klient został dodany pomyślnie.";

        //public AddCustomerViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
        //    : base(httpRequestService, navigationService, messageDialogService)
        //{
        //}
    }
}