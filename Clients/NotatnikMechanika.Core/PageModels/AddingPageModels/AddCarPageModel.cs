using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Car;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddCarPageModel : AddingPageModelBase<CarModel>
    {
        public AddCarPageModel(MvvmPackage.Core.Services.Interfaces.IMvNavigationService navigationService) : base(navigationService)
        {
        }
        // public override string SuccesMessage { get; set; } = "Samochód został dodany pomyślnie.";

        //public AddCarViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
        //    : base(httpRequestService, navigationService, messageDialogService)
        //{
        //}

        //public override void Prepare(int customerId)
        //{
        //    Model.CustomerId = customerId;
        //}
    }
}