using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Car;
using NotatnikMechanika.Shared.Models.Customer;
using PropertyChanged;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class CustomerPageModel : PageModelBase
    {
        public CustomerModel CustomerModel { get; set; }
        public IEnumerable<CarModel> Cars { get; set; }
        public string ErrorMessage { get; set; }
        public ICommand GoBackCommand { get; set; }
        public ICommand AddCarCommand { get; set; }
        public ICommand RemoveCarCommand { get; set; }

        private readonly IHttpRequestService _httpRequestService;
        private readonly IMessageDialogService _messageDialogService;

        public CustomerPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;
            CustomerModel = new CustomerModel();
            GoBackCommand = new AsyncCommand(() => navigationService.NavigateToAsync<MainPageModel>());
            AddCarCommand = new AsyncCommand(() => navigationService.NavigateToAsync<AddCarPageModel>(CustomerModel.Id));
            RemoveCarCommand = new AsyncCommand<int>(RemoveCarAction);
        }

        private async Task RemoveCarAction(int id)
        {
            Response response = await _httpRequestService.SendDelete(new CarPaths().GetFullPath(id.ToString()));
            if (response.Successful)
            {
                await _messageDialogService.ShowMessageDialog("Pomyślnie usunięto klienta", MessageDialogType.Success);
            }
            else
            {
                await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd podczasu usuwania klienta");
            }
            await Initialize();
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            CustomerModel.Id = Parameter;

            Response<CustomerModel> responseCustomer = await _httpRequestService.SendGet<CustomerModel>(PathsHelper.GetPathsByModel<CustomerModel>().GetFullPath(CustomerModel.Id.ToString()));

            if (responseCustomer.Successful)
            {
                CustomerModel = responseCustomer.Content;
            }
            else
            {
                ErrorMessage = responseCustomer.ErrorMessages?.FirstOrDefault();
                await _messageDialogService.ShowMessageDialog(responseCustomer.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania klienta");
                return;
            }

            Response<List<CarModel>> responseCars = await _httpRequestService.SendGet<List<CarModel>>(
                PathsHelper
                .GetPathsByModel<CarModel>()
                .GetFullPath(CarPaths.GetByCustomerPath.Replace("{customerId}", CustomerModel.Id.ToString())));

            if (responseCars.Successful)
            {
                Cars = responseCars.Content;
            }
            else
            {
                ErrorMessage = responseCars.ErrorMessages?.FirstOrDefault();
                await _messageDialogService.ShowMessageDialog(responseCars.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania samochodów klienta");
            }
            IsLoading = false;
        }
    }
}