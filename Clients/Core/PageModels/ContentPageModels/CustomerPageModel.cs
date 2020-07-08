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
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class CustomerPageModel : PageModelBase
    {
        public CustomerModel CustomerModel { get; set; }
        public IEnumerable<CarModel> Cars { get; set; }
        public string ErrorMessage { get; set; }
        public ICommand GoBackCommand { get; set; }
        public ICommand AddCarCommand { get; set; }
        public ICommand RemoveCarCommand { get; set; }

        private readonly IHttpRequestService _httpRequestService;

        public CustomerPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService)
        {
            _httpRequestService = httpRequestService;
            CustomerModel = new CustomerModel();
            GoBackCommand = new AsyncCommand(() => navigationService.NavigateToAsync<MainPageModel>());
            AddCarCommand = new AsyncCommand(() => navigationService.NavigateToAsync<AddCarPageModel>(CustomerModel.Id));
            RemoveCarCommand = new AsyncCommand<int>(RemoveCarAction);
        }

        private async Task RemoveCarAction(int id)
        {
            await _httpRequestService.SendDelete(new CarPaths().GetFullPath(id.ToString()));
            await Initialize();
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            CustomerModel.Id = Parameter;

            Response<CustomerModel> responseCustomer = await _httpRequestService.SendGet<CustomerModel>(PathsHelper.GetPathsByModel<CustomerModel>().GetFullPath(CustomerModel.Id.ToString()));

            if (responseCustomer.Successful)
            {
                CustomerModel = responseCustomer.Content;
            }
            else
            {
                ErrorMessage = responseCustomer.ErrorMessages?.FirstOrDefault();
                return;
            }

            Response<List<CarModel>> responseCars = await _httpRequestService.SendGet<List<CarModel>>(
                PathsHelper
                .GetPathsByModel<CarModel>()
                .GetFullPath(CarPaths.GetByCustomerPath.Replace("{customerId}", CustomerModel.Id.ToString())));

            if (responseCars.Successful)
            {
                Cars = responseCars.Content;
            }
            else
            {
                ErrorMessage = responseCars.ErrorMessages?.FirstOrDefault();
            }
            IsLoading = false;
        }
    }
}