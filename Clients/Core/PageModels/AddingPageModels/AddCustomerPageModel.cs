using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Shared.Models.Customer;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddCustomerPageModel : AddingPageModelBase<CustomerModel>
    {
        public AddCustomerPageModel(IMvNavigationService navigationService) : base(navigationService)
        {
        }
        //public override string SuccesMessage { get; set; } = "Klient został dodany pomyślnie.";

        //public AddCustomerViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
        //    : base(httpRequestService, navigationService, messageDialogService)
        //{
        //}
    }
}