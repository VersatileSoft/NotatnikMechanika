using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Model;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Car;
using NotatnikMechanika.Shared.Models.Customer;
using PropertyChanged;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class CustomerPageModel : PageModelBase<int>
    {
        public CustomerModel CustomerModel { get; set; }
        public IEnumerable<CarModel> Cars { get; set; }
        public string ErrorMessage { get; set; }
        public ICommand GoBackCommand { get; set; }
        public ICommand AddCarCommand { get; set; }

        private readonly IHttpRequestService _httpRequestService;

        public bool IsLoading { get; set; }

        public CustomerPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService)
        {
            _httpRequestService = httpRequestService;
            CustomerModel = new CustomerModel();
            GoBackCommand = new AsyncCommand(() => navigationService.NavigateToAsync<MainPageModel>());
            AddCarCommand = new AsyncCommand(() => navigationService.NavigateToAsync<AddCarPageModel, int>(CustomerModel.Id));
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            CustomerModel.Id = Parameter;

            Response<CustomerModel> responseCustomer = await _httpRequestService.SendGet<CustomerModel>(PathsHelper.GetPathsByModel<CustomerModel>().GetFullPath(CustomerModel.Id.ToString()));

            if (responseCustomer.StatusCode == HttpStatusCode.OK)
            {
                CustomerModel = responseCustomer.Content;
            }
            else
            {
                ErrorMessage = responseCustomer.ErrorMessages?.FirstOrDefault();
                return;
            }

            Response<CarsResult> responseCars = await _httpRequestService.SendGet<CarsResult>(
                PathsHelper
                .GetPathsByModel<CarModel>()
                .GetFullPath(CarPaths.GetByCustomerPath.Replace("{customerId}", CustomerModel.Id.ToString())));

            if (responseCars.StatusCode == HttpStatusCode.OK)
            {
                Cars = responseCars.Content.Cars;
            }
            else
            {
                ErrorMessage = responseCars.ErrorMessages?.FirstOrDefault();
            }
            IsLoading = false;
        }
    }
}