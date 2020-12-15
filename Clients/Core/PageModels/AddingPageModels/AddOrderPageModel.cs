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
using static NotatnikMechanika.Shared.ResponseBuilder;

// ReSharper disable once CheckNamespace
namespace NotatnikMechanika.Core.PageModels
{
    public class AddOrderPageModel : AddingPageModelBase<OrderModel>
    {
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
        }

        public override string SuccesMessage { get; set; } = "Zlecenie zostało dodane pomyślnie.";

        public new AddOrderModel Model { get; set; }
        public ObservableCollection<CustomerModel> Customers { get; set; }
        public ObservableCollection<CarModel> Cars { get; set; }
        public ObservableCollection<ServiceModel> Services { get; set; }
        public ObservableCollection<CommodityModel> Commodities { get; set; }

        private CustomerModel _selectedCustomer;

        public CustomerModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                Task.Run(SelectedCustomerChanged);
            }
        }

        private CarModel _selectedCar;

        public CarModel SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                Model.CarId = _selectedCar.Id;
            }
        }

        protected override async Task AddAction()
        {
            IsLoading = true;
            if (!Model.Commodities.Any() && !Model.Services.Any())
            {
                base.Model = Model;
                await base.AddAction();
                return;
            }

            var response = await HttpRequestService.SendPost(Model, OrderPaths.AddExtended());

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    await MessageDialogService.ShowMessageDialog(SuccesMessage, MessageDialogType.Success, "Operacja powiodła się");
                    await NavigationService.NavigateToAsync<MainPageModel>();
                    break;

                case ResponseType.Failure:
                    ErrorMessage = response.ErrorMessages?.FirstOrDefault();
                    await MessageDialogService.ShowMessageDialog(ErrorMessage, MessageDialogType.Error, "Wystąpił błąd");
                    break;

                case ResponseType.BadModelState:
                    await MessageDialogService.ShowMessageDialog("Wypełnij formularz poprawnie", MessageDialogType.Error);
                    break;
                case ResponseType.Unauthorized:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            IsLoading = false;
        }

        private async Task SelectedCustomerChanged()
        {
            IsLoading = true;
            
            var path = CarPaths.ByCustomer(SelectedCustomer.Id);
            var carsResponse = await HttpRequestService.SendGet<List<CarModel>>(path);

            switch (carsResponse.ResponseType)
            {
                case ResponseType.Successful:
                    Cars = new ObservableCollection<CarModel>(carsResponse.Content);
                    break;

                case ResponseType.Failure:
                    await MessageDialogService.ShowMessageDialog(carsResponse.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania samochodów klienta");
                    break;
                case ResponseType.Unauthorized:
                case ResponseType.BadModelState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (Cars?.Any() ?? false)
            {
                SelectedCar = Cars?.FirstOrDefault();
            }
            IsLoading = false;
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            var customersResponse = await HttpRequestService.All<CustomerModel>();

            switch (customersResponse.ResponseType)
            {
                case ResponseType.Successful:
                    Customers = new ObservableCollection<CustomerModel>(customersResponse.Content);
                    break;

                case ResponseType.Failure:
                    await MessageDialogService.ShowMessageDialog(customersResponse.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania klientów");
                    break;
                case ResponseType.Unauthorized:
                case ResponseType.BadModelState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (Customers?.Any() ?? false)
            {
                SelectedCustomer = Customers?.FirstOrDefault();
            }

            var servicesResponse = await HttpRequestService.All<ServiceModel>();

            switch (servicesResponse.ResponseType)
            {
                case ResponseType.Successful:
                    Services = new ObservableCollection<ServiceModel>(servicesResponse.Content);
                    break;

                case ResponseType.Failure:
                    await MessageDialogService.ShowMessageDialog(servicesResponse.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania klientów");
                    break;
                case ResponseType.Unauthorized:
                case ResponseType.BadModelState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var commoditiesResponse = await HttpRequestService.All<CommodityModel>();

            switch (commoditiesResponse.ResponseType)
            {
                case ResponseType.Successful:
                    Commodities = new ObservableCollection<CommodityModel>(commoditiesResponse.Content);
                    break;

                case ResponseType.Failure:
                    await MessageDialogService.ShowMessageDialog(commoditiesResponse.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania klientów");
                    break;
                case ResponseType.Unauthorized:
                case ResponseType.BadModelState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            IsLoading = false;
        }
    }
}