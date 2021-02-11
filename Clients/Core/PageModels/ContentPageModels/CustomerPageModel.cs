using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.Car;
using NotatnikMechanika.Shared.Models.Customer;
using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using NotatnikMechanika.Shared;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class CustomerPageModel : PageModelBase
    {
        public CustomerModel CustomerModel { get; private set; }
        public ObservableCollection<CarModel> Cars { get; }
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
            Cars = new ObservableCollection<CarModel>();
        }

        private async Task RemoveCarAction(int id)
        {
            if (await _httpRequestService.Delete<CarModel>(id, "Błąd podczasu usuwania samochodu"))
            {
                Cars.Remove(Cars.Single(c => c.Id == id));
                _messageDialogService.ShowMessageDialog("Pomyślnie usunięto samochód", MessageDialogType.Success);
            }
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            CustomerModel.Id = Parameter ?? 0;

            var customer = await _httpRequestService.ById<CustomerModel>(CustomerModel.Id, "Błąd ładowania klienta");
            if (customer != null)
            {
                CustomerModel = customer;
            }

            var cars = await _httpRequestService.SendGet<List<CarModel>>(CarPaths.ByCustomer(CustomerModel.Id), "Błąd ładowania samochodów klienta");
            if (cars != null)
            {
                Cars.Clear();
                cars.ForEach(c => Cars.Add(c));
            }

            IsLoading = false;
        }
    }
}