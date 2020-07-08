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
            Response<List<CarModel>> carsResponse = await _httpRequestService.SendGet<List<CarModel>>(new CarPaths().GetFullPath(
                CarPaths.GetByCustomerPath.Replace("{customerId}", SelectedCustomer.Id.ToString())));

            if (carsResponse.Successful)
            {
                Cars = carsResponse.Content;
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
            Response<List<CustomerModel>> customersResponse = await _httpRequestService.SendGet<List<CustomerModel>>(new CustomerPaths().GetFullPath(CRUDPaths.GetAllPath));

            if (customersResponse.Successful)
            {
                Customers = customersResponse.Content;
            }

            if (Customers?.Any() ?? false)
            {
                SelectedCustomer = Customers?.FirstOrDefault();
            }
            IsLoading = false;
        }
    }
}