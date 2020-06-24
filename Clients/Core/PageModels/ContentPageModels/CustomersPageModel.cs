using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class CustomersPageModel : PageModelBase
    {
        //public IEnumerable<CustomerModel> Customers { get; set; }
        public ICommand AddCustomerCommand { get; set; }
        //public ICommand CustomerSelectedCommand { get; set; }
        //public bool IsLoading { get; set; }


        //private readonly IHttpRequestService _httpRequestService;
        private readonly IMvNavigationService _navigationService;

        public CustomersPageModel(IMvNavigationService navigationService)
        {
            _navigationService = navigationService;
            //    _httpRequestService = httpRequestService;

            AddCustomerCommand = new AsyncCommand(AddCustomerAction);
            //    CustomerSelectedCommand = new MvxAsyncCommand<int>(CustomerSelectedAction);
        }

        private async Task AddCustomerAction()
        {
            await _navigationService.NavigateToAsync<AddCustomerPageModel>();
        }

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