using MvvmCross.Navigation;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Customer;

namespace NotatnikMechanika.Core.ViewModels
{
    public class AddCustomerViewModel : AddingViewModelBase<CustomerModel>
    {
        public override string SuccesMessage { get; set; } = "Klient został dodany pomyślnie.";

        public AddCustomerViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
            : base(httpRequestService, navigationService, messageDialogService)
        {
        }
    }
}