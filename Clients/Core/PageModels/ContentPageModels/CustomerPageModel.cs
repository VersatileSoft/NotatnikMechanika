using System;
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
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class CustomerPageModel : PageModelBase
    {
        public CustomerModel CustomerModel { get; private set; }
        public IEnumerable<CarModel> Cars { get; private set; }
        public string ErrorMessage { get; set; }
        public ICommand GoBackCommand { get; }
        public ICommand AddCarCommand { get; }
        public ICommand RemoveCarCommand { get; }

        private readonly IHttpRequestService _httpRequestService;
        private readonly IMessageDialogService _messageDialogService;

        public CustomerPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;
            CustomerModel = new CustomerModel();
            GoBackCommand = new AsyncCommand(navigationService.NavigateToAsync<MainPageModel>);
            AddCarCommand = new AsyncCommand(() => navigationService.NavigateToAsync<AddCarPageModel>(CustomerModel.Id));
            RemoveCarCommand = new AsyncCommand<int>(RemoveCarAction);
        }

        private async Task RemoveCarAction(int id)
        {
            var response = await _httpRequestService.Delete<CarModel>(id);

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    await _messageDialogService.ShowMessageDialog("Pomyślnie usunięto klienta", MessageDialogType.Success);
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd podczasu usuwania klienta");
                    break;
                case ResponseType.Unauthorized:
                    break;
                case ResponseType.BadModelState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            await Initialize();
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            CustomerModel.Id = Parameter;

            var responseCustomer = await _httpRequestService.ById<CustomerModel>(CustomerModel.Id);

            switch (responseCustomer.ResponseType)
            {
                case ResponseType.Successful:
                    CustomerModel = responseCustomer.Content;
                    break;

                case ResponseType.Failure:
                    ErrorMessage = responseCustomer.ErrorMessages?.FirstOrDefault();
                    await _messageDialogService.ShowMessageDialog(responseCustomer.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania klienta");
                    return;
                case ResponseType.Unauthorized:
                    break;
                case ResponseType.BadModelState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var responseCars = await _httpRequestService.All<CarModel>();

            switch (responseCars.ResponseType)
            {
                case ResponseType.Successful:
                    Cars = responseCars.Content;
                    break;

                case ResponseType.Failure:
                    ErrorMessage = responseCars.ErrorMessages?.FirstOrDefault();
                    await _messageDialogService.ShowMessageDialog(responseCars.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania samochodów klienta");
                    break;
                case ResponseType.Unauthorized:
                    break;
                case ResponseType.BadModelState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            IsLoading = false;
        }
    }
}