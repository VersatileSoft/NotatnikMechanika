using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
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
    public class CustomersPageModel : PageModelBase
    {
        public IEnumerable<CustomerModel> Customers { get; set; }
        public ICommand AddCustomerCommand { get; set; }
        public ICommand RemoveCustomerCommand { get; set; }
        public ICommand CustomerSelectedCommand { get; set; }

        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvNavigationService _navigationService;
        private readonly IMessageDialogService _messageDialogService;

        public CustomersPageModel(IMvNavigationService navigationService, IHttpRequestService httpRequestService, IMessageDialogService messageDialogService)
        {
            _navigationService = navigationService;
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;

            AddCustomerCommand = new AsyncCommand(AddCustomerAction);
            RemoveCustomerCommand = new AsyncCommand<int>(RemoveCustomerAction);
            CustomerSelectedCommand = new AsyncCommand<int>(CustomerSelectedAction);
        }

        private async Task AddCustomerAction()
        {
            await _navigationService.NavigateToAsync<AddCustomerPageModel>();
        }

        private async Task RemoveCustomerAction(int id)
        {
            Response response = await _httpRequestService.SendDelete(new CustomerPaths().GetFullPath(id.ToString()));
            if (response.Successful)
            {
                await _messageDialogService.ShowMessageDialog("Pomyślnie usunięto klienta", MessageDialogType.Success);
            }
            else
            {
                await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Success, "Błąd podczas usuwania klienta");
            }

            await Initialize();
        }

        private async Task CustomerSelectedAction(int customerId)
        {
            await _navigationService.NavigateToAsync<CustomerPageModel>(customerId);
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            Response<List<CustomerModel>> response = await _httpRequestService.SendGet<List<CustomerModel>>(new CustomerPaths().GetFullPath(CRUDPaths.GetAllPath));
            if (response.Successful)
            {
                Customers = response.Content;
            }
            else
            {
                await _messageDialogService.ShowMessageDialog("Błąd podczas ładowania klientów", MessageDialogType.Error);
            }
            IsLoading = false;
        }
    }
}