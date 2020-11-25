using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Car;
using NotatnikMechanika.Shared.Models.Customer;
using NotatnikMechanika.Shared.Models.Order;
using System;
using System.Collections.Generic;
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
            Model.AcceptDate = DateTime.Now;
            Model.FinishDate = DateTime.Now;
        }

        public override string SuccesMessage { get; set; } = "Zlecenie zostało dodane pomyślnie.";

        public IEnumerable<CustomerModel> Customers { get; set; }
        public IEnumerable<CarModel> Cars { get; set; }

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

        private async Task SelectedCustomerChanged()
        {
            IsLoading = true;
            
            var path = CarPaths.ByCustomer(SelectedCustomer.Id);
            var carsResponse = await HttpRequestService.SendGet<List<CarModel>>(path);

            switch (carsResponse.ResponseType)
            {
                case ResponseType.Successful:
                    Cars = carsResponse.Content;
                    break;

                case ResponseType.Failure:
                    await MessageDialogService.ShowMessageDialog(carsResponse.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania samochodów klienta");
                    break;
                case ResponseType.Unauthorized:
                    break;
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
                    Customers = customersResponse.Content;
                    break;

                case ResponseType.Failure:
                    await MessageDialogService.ShowMessageDialog(customersResponse.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania klientów");
                    break;
                case ResponseType.Unauthorized:
                    break;
                case ResponseType.BadModelState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (Customers?.Any() ?? false)
            {
                SelectedCustomer = Customers?.FirstOrDefault();
            }
            IsLoading = false;
        }
    }
}