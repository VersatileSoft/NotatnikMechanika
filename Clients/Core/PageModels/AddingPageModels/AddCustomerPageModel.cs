using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Customer;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddCustomerPageModel : AddingPageModelBase<CustomerModel>
    {
        public override string SuccesMessage { get; set; } = "Klient został dodany pomyślnie.";

        public AddCustomerPageModel(
            IHttpRequestService httpRequestService,
            IMvNavigationService navigationService,
            IMessageDialogService messageDialogService)
            : base(navigationService, httpRequestService, messageDialogService)
        {
        }
    }
}