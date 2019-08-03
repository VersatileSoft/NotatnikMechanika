using MvvmCross.Navigation;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Order;

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
