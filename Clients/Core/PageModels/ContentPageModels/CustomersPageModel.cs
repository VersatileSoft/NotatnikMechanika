using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Customer;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class CustomersPageModel : PageModelBase
    {
        public ObservableCollection<CustomerModel> Customers { get; set; }
        public ICommand AddCustomerCommand { get; }
        public ICommand RemoveCustomerCommand { get; }
        public ICommand CustomerSelectedCommand { get; }

        private readonly IHttpRequestService _httpRequestService;
        private readonly IMessageDialogService _messageDialogService;

        public CustomersPageModel(IMvNavigationService navigationService, IHttpRequestService httpRequestService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;
            Customers = new ObservableCollection<CustomerModel>();
            AddCustomerCommand = new AsyncCommand(navigationService.NavigateToAsync<AddCustomerPageModel>);
            RemoveCustomerCommand = new AsyncCommand<int>(RemoveCustomerAction);
            CustomerSelectedCommand = new AsyncCommand<int>(navigationService.NavigateToAsync<CustomerPageModel>);
        }

        private async Task RemoveCustomerAction(int id)
        {
            Response response = await _httpRequestService.Delete<CustomerModel>(id);

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    await _messageDialogService.ShowMessageDialog("Pomyślnie usunięto klienta", MessageDialogType.Success);
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Success, "Błąd podczas usuwania klienta");
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
            Response<List<CustomerModel>> response = await _httpRequestService.All<CustomerModel>();
            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    Customers.Clear();
                    response.Content.ForEach(item=>Customers.Add(item));
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog("Błąd podczas ładowania klientów", MessageDialogType.Error);
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