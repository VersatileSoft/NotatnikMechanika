using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Car;
using NotatnikMechanika.Shared.Models.Customer;
using PropertyChanged;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels.ContentViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CustomerViewModel : MvxViewModel<int>
    {
        public CustomerModel CustomerModel { get; set; }
        public IEnumerable<CarModel> Cars { get; set; }
        public string ErrorMessage { get; set; }
        public ICommand GoBackCommand { get; set; }
        public ICommand AddCarCommand { get; set; }

        private readonly IHttpRequestService _httpRequestService;

        public CustomerViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        {
            _httpRequestService = httpRequestService;
            CustomerModel = new CustomerModel();
            GoBackCommand = new MvxAsyncCommand(() => navigationService.Navigate<MainPageViewModel>());
            AddCarCommand = new MvxAsyncCommand(() => navigationService.Navigate<AddCarViewModel, int>(CustomerModel.Id));
        }

        public override void Prepare(int customerId)
        {
            CustomerModel.Id = customerId;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            Response<CustomerModel> responseCustomer = await _httpRequestService.SendGet<CustomerModel>(PathsHelper.GetPathsByModel<CustomerModel>().GetFullPath(CustomerModel.Id.ToString()), true);

            if (responseCustomer.StatusCode == HttpStatusCode.OK)
            {
                CustomerModel = responseCustomer.Content;
            }
            else
            {
                ErrorMessage = responseCustomer.ErrorMessage;
                return;
            }

            Response<List<CarModel>> responseCars = await _httpRequestService.SendGet<List<CarModel>>(
                path: PathsHelper.GetPathsByModel<CarModel>().GetFullPath(CarPaths.GetByCustomerPath.Replace("{customerId}", CustomerModel.Id.ToString())),
                withAutorization: true);

            if (responseCars.StatusCode == HttpStatusCode.OK)
            {
                Cars = responseCars.Content;
            }
            else
            {
                ErrorMessage = responseCars.ErrorMessage;
            }
        }
    }
}
