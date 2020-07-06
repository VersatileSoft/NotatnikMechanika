using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Car;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddCarPageModel : AddingPageModelBase<CarModel>
    {
        
         public override string SuccesMessage { get; set; } = "Samochód został dodany pomyślnie.";

        public AddCarPageModel(
            IHttpRequestService httpRequestService,
            IMvNavigationService navigationService,
            IMessageDialogService messageDialogService)
            : base(navigationService, httpRequestService, messageDialogService)
        {
        }

        public override Task Initialize()
        {
            Model.CustomerId = Parameter;
            return Task.CompletedTask;
        }
    }
}