using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Customer;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

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
