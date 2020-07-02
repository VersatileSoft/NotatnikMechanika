using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Model;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Order;
using PropertyChanged;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrdersPageModel : PageModelBase
    {
        public IEnumerable<OrderExtendedModel> Orders { get; set; }
        public bool IsLoading { get; set; }
        public ICommand AddOrderCommand { get; set; }
        public ICommand OrderSelectedCommand { get; set; }

        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvNavigationService _navigationService;

        public OrdersPageModel(IMvNavigationService navigationService, IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            AddOrderCommand = new AsyncCommand(() => _navigationService.NavigateToAsync<AddOrderPageModel>());
            OrderSelectedCommand = new AsyncCommand<OrderExtendedModel>((order) => _navigationService.NavigateToAsync<OrderPageModel, OrderExtendedModel>(order));
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            Response<AllExtendedOrdersResult> response = await _httpRequestService.SendGet<AllExtendedOrdersResult>(new OrderPaths().GetFullPath(OrderPaths.GetExtendedOrders));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Orders = response.Content.Orders;
            }
            IsLoading = false;
        }
    }
}