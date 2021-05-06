using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Car;
using NotatnikMechanika.Shared.Models.Commodity;
using NotatnikMechanika.Shared.Models.Customer;
using NotatnikMechanika.Shared.Models.Order;
using NotatnikMechanika.Shared.Models.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddOrderPageModel : AddingPageModelBase<OrderModel>
    {
        public override string? SuccessMessage { get; set; } = "Zlecenie zostało dodane pomyślnie.";

        public new AddOrderModel Model { get; set; }
        public ObservableCollection<CustomerModel> Customers { get; set; }
        public ObservableCollection<CarModel> Cars { get; set; }
        public ObservableCollection<ServiceModel> Services { get; set; }
        public ObservableCollection<CommodityModel> Commodities { get; set; }
        public bool CarsLoading { get; set; }

        private CustomerModel? _selectedCustomer;

        public CustomerModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                _ = SelectedCustomerChanged();
            }
        }

        private CarModel? _selectedCar;

        public CarModel? SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                Model.CarId = _selectedCar?.Id ?? 0;
            }
        }

        public AddOrderPageModel(IMvNavigationService navigationService, IHttpRequestService httpRequestService, IMessageDialogService messageDialogService) :
            base(navigationService, httpRequestService, messageDialogService)
        {
            Model = new AddOrderModel
            {
                AcceptDate = DateTime.Now,
                FinishDate = DateTime.Now,
                Services = new List<int>(),
                Commodities = new List<int>()
            };

            Services = new ObservableCollection<ServiceModel>();
            Commodities = new ObservableCollection<CommodityModel>();
            Customers = new ObservableCollection<CustomerModel>();
            Cars = new ObservableCollection<CarModel>();
        }

        protected override async Task AddAction()
        {
            IsLoading = true;
            if (!Commodities.Any(c => c.Finished) && !Services.Any(s => s.Finished))
            {
                base.Model = Model;
                await base.AddAction();
                return;
            }

            Model.Services = Services.Where(s => s.Finished).Select(s => s.Id).ToList();
            Model.Commodities = Commodities.Where(c => c.Finished).Select(c => c.Id).ToList();

            if (await HttpRequestService.SendPost(Model, OrderPaths.AddExtended()) && SuccessMessage != null)
            {
                MessageDialogService.ShowMessageDialog(SuccessMessage, MessageDialogType.Success, "Pomyślnie dodano zlecnie");
                await NavigationService.NavigateToAsync<MainPageModel>();
            }
            IsLoading = false;
        }

        private async Task SelectedCustomerChanged()
        {
            CarsLoading = true;
            var cars = await GetCars();
            if (cars != null)
            {
                Cars.Clear();
                cars.ForEach(c => Cars.Add(c));
            }

            SelectedCar = Cars.FirstOrDefault();

            CarsLoading = false;
        }

        private Task<List<CarModel>> GetCars()
        {
            string path = CarPaths.ByCustomer(SelectedCustomer.Id);
            return HttpRequestService.SendGet<List<CarModel>>(path);
        }

        public override async Task Initialize()
        {
            IsLoading = true;

            var customers = await HttpRequestService.All<CustomerModel>();
            if (customers != null)
            {
                Customers.Clear();
                customers.ForEach(c => Customers.Add(c));
            }

            var services = await HttpRequestService.All<ServiceModel>();
            if (services != null)
            {
                Services.Clear();
                services.ForEach(s => Services.Add(s));
            }

            var commodities = await HttpRequestService.All<CommodityModel>();
            if (commodities != null)
            {
                Commodities.Clear();
                commodities.ForEach(c => Commodities.Add(c));
            }

            if (Customers.Any())
            {
                SelectedCustomer = Customers.FirstOrDefault();
            }

            IsLoading = false;
        }
    }
}