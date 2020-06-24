using NotatnikMechanika.Shared.Models.Service;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddServicePageModel : AddingPageModelBase<ServiceModel>
    {
        public AddServicePageModel(MvvmPackage.Core.Services.Interfaces.IMvNavigationService navigationService) : base(navigationService)
        {
        }
        //public override string ErrorMessage { get; set; } = "Błąd podczas dodawania usługi.";
        //public override string SuccesMessage { get; set; } = "Usługa została dodana pomyślnie.";

        //public AddServiceViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
        //    : base(httpRequestService, navigationService, messageDialogService)
        //{
        //}
    }
}