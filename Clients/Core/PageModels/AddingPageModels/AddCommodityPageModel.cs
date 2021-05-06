using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Commodity;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddCommodityPageModel : AddingPageModelBase<CommodityModel>
    {
        public override string? ErrorMessage { get; set; } = "Błąd podczas dodawania towaru.";
        public override string? SuccessMessage { get; set; } = "Towar został dodany pomyślnie.";

        public AddCommodityPageModel(
            IHttpRequestService httpRequestService,
            IMvNavigationService navigationService,
            IMessageDialogService messageDialogService)
            : base(navigationService, httpRequestService, messageDialogService)
        {
        }
    }
}