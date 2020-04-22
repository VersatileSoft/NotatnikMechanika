using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.PageModels.ContentViewModels;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Customer;
using PropertyChanged;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.MVVMPackage;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class CustomersViewModel : PageModelBase
    {
        //public IEnumerable<CustomerModel> Customers { get; set; }
        //public ICommand AddCustomerCommand { get; set; }
        //public ICommand CustomerSelectedCommand { get; set; }
        //public bool IsLoading { get; set; }


        //private readonly IHttpRequestService _httpRequestService;
        //private readonly IMvxNavigationService _navigationService;

        //public CustomersViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        //{
        //    _navigationService = navigationService;
        //    _httpRequestService = httpRequestService;

        //    AddCustomerCommand = new MvxAsyncCommand(AddCustomerAction);
        //    CustomerSelectedCommand = new MvxAsyncCommand<int>(CustomerSelectedAction);
        //}

        //private async Task AddCustomerAction()
        //{
        //    await _navigationService.Navigate<AddCustomerViewModel>();
        //}

        //private async Task CustomerSelectedAction(int customerId)
        //{
        //    await _navigationService.Navigate<CustomerViewModel, int>(customerId);
        //}

        //public override async Task Initialize()
        //{
        //    IsLoading = true;
        //    Response<List<CustomerModel>> response = await _httpRequestService.SendGet<List<CustomerModel>>(new CustomerPaths().GetFullPath(CRUDPaths.GetAllPath), true);
        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        Customers = response.Content;
        //    }
        //    IsLoading = false;
        //}
    }
}