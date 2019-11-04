using MvvmCross.Navigation;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Commodity;

namespace NotatnikMechanika.Core.ViewModels
{
    internal class AddCommodityViewModel : AddingViewModelBase<CommodityModel>
    {
        public override string ErrorMessage { get; set; } = "Błąd podczas dodawania towaru.";
        public override string SuccesMessage { get; set; } = "Towar został dodany pomyślnie.";

        public AddCommodityViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
            : base(httpRequestService, navigationService, messageDialogService)
        {
        }
    }
}