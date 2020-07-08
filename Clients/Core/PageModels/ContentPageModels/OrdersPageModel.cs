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
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrdersPageModel : PageModelBase
    {
        public IEnumerable<OrderExtendedModel> Orders { get; set; }
        public ICommand AddOrderCommand { get; set; }
        public ICommand OrderSelectedCommand { get; set; }
        public ICommand RemoveOrderCommand { get; set; }

        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvNavigationService _navigationService;

        public OrdersPageModel(IMvNavigationService navigationService, IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            AddOrderCommand = new AsyncCommand(() => _navigationService.NavigateToAsync<AddOrderPageModel>());
            OrderSelectedCommand = new AsyncCommand<int>((id) => _navigationService.NavigateToAsync<OrderPageModel>(id));
            RemoveOrderCommand = new AsyncCommand<int>(RemoveOrderAction);
        }

        private async Task RemoveOrderAction(int id)
        {
            await _httpRequestService.SendDelete(new OrderPaths().GetFullPath(CRUDPaths.DeletePath.Replace("{id}", id.ToString())));
            await Initialize();
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            Response<List<OrderExtendedModel>> response = await _httpRequestService.SendGet<List<OrderExtendedModel>>(new OrderPaths().GetFullPath(OrderPaths.GetExtendedOrders));
            if (response.Successful)
            {
                Orders = response.Content;
            }
            IsLoading = false;
        }
    }
}