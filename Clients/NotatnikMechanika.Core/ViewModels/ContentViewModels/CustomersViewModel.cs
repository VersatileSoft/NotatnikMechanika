using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Core.ViewModels.ContentViewModels;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Customer;
using PropertyChanged;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CustomersViewModel : MvxViewModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }
        public ICommand AddCustomerCommand { get; set; }
        public ICommand CustomerSelectedCommand { get; set; }


        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvxNavigationService _navigationService;

        public CustomersViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _httpRequestService = httpRequestService;

            AddCustomerCommand = new MvxAsyncCommand(AddCustomerAction);
            CustomerSelectedCommand = new MvxAsyncCommand<int>(CustomerSelectedAction);
        }

        private async Task AddCustomerAction()
        {
            await _navigationService.Navigate<AddCustomerViewModel>();
        }

        private async Task CustomerSelectedAction(int customerId)
        {
            await _navigationService.Navigate<CustomerViewModel, int>(customerId);
        }

        public override async Task Initialize()
        {
            Response<List<CustomerModel>> response = await _httpRequestService.SendGet<List<CustomerModel>>(new CustomerPaths().GetFullPath(CRUDPaths.GetAllPath), true);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Customers = response.Content;
            }
        }
    }
}
