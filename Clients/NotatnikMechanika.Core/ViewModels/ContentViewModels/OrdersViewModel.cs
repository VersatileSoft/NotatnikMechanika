using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Models;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Core.ViewModels.ContentViewModels;
using NotatnikMechanika.Shared;
using PropertyChanged;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrdersViewModel : MvxViewModel
    {
        public IEnumerable<OrderExtendedModel> Orders { get; set; }
        public bool IsLoading { get; set; }
        public ICommand AddOrderCommand { get; set; }
        public ICommand OrderSelectedCommand { get; set; }

        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvxNavigationService _navigationService;
        public OrdersViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        {
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            AddOrderCommand = new MvxAsyncCommand(() => _navigationService.Navigate<AddOrderViewModel>());
            OrderSelectedCommand = new MvxAsyncCommand<OrderExtendedModel>((order) => _navigationService.Navigate<OrderViewModel, OrderExtendedModel>(order));
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            Response<List<OrderExtendedModel>> response = await _httpRequestService.SendGet<List<OrderExtendedModel>>(new OrderPaths().GetFullPath(OrderPaths.GetExtendedOrders), true);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Orders = response.Content;
            }

            IsLoading = false;
        }
    }
}