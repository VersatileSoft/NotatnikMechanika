using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using PropertyChanged;
using System.Windows.Input;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrdersPageModel : PageModelBase
    {
        //  public IEnumerable<OrderExtendedModel> Orders { get; set; }
        //  public bool IsLoading { get; set; }
        public ICommand AddOrderCommand { get; set; }
        //   public ICommand OrderSelectedCommand { get; set; }

        // private readonly IHttpRequestService _httpRequestService;
        private readonly IMvNavigationService _navigationService;
        public OrdersPageModel(IMvNavigationService navigationService)
        {
            //  _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            AddOrderCommand = new AsyncCommand(() => _navigationService.NavigateToAsync<AddOrderPageModel>());
            //  OrderSelectedCommand = new MvxAsyncCommand<OrderExtendedModel>((order) => _navigationService.Navigate<OrderViewModel, OrderExtendedModel>(order));
        }

        //public override async Task Initialize()
        //{
        //    IsLoading = true;
        //    Response<List<OrderExtendedModel>> response = await _httpRequestService.SendGet<List<OrderExtendedModel>>(new OrderPaths().GetFullPath(OrderPaths.GetExtendedOrders), true);

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        Orders = response.Content;
        //    }

        //    IsLoading = false;
        //}
    }
}