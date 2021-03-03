using MvvmPackage.Core;
using MvvmPackage.Core.Commands;
using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Customer;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

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
            if (await _httpRequestService.Delete<CustomerModel>(id, "Błąd podczas usuwania klienta"))
            {
                Customers.Remove(Customers.Single(c => c.Id == id));
                _messageDialogService.ShowMessageDialog("Pomyślnie usunięto klienta", MessageDialogType.Success);
            }
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            var customers = await _httpRequestService.All<CustomerModel>("Błąd podczas ładowania klientów");
            if (customers != null)
            {
                Customers.Clear();
                customers.ForEach(c => Customers.Add(c));
            }

            IsLoading = false;
        }
    }
}