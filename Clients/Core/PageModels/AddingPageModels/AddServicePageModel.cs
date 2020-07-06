using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Service;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddServicePageModel : AddingPageModelBase<ServiceModel>
    {
        public override string ErrorMessage { get; set; } = "Błąd podczas dodawania usługi.";
        public override string SuccesMessage { get; set; } = "Usługa została dodana pomyślnie.";

        public AddServicePageModel(
            IHttpRequestService httpRequestService,
            IMvNavigationService navigationService,
            IMessageDialogService messageDialogService)
            : base(navigationService, httpRequestService, messageDialogService)
        {
        }
    }
}