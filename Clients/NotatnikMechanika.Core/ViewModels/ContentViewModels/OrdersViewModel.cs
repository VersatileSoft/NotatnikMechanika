using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Order;
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
        public IEnumerable<OrderModel> Orders { get; set; }
        public ICommand AddOrderCommand { get; set; }
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvxNavigationService _navigationService;
        public OrdersViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        {
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            AddOrderCommand = new MvxAsyncCommand(AddOrderAction);
        }
        
        private async Task AddOrderAction()
        {
            await _navigationService.Navigate<AddOrderViewModel>();
        }

        public override async Task Initialize()
        {
            Response<List<OrderModel>> response = await _httpRequestService.SendGet<List<OrderModel>>(new OrderPaths().GetFullPath(CRUDPaths.GetAllPath), true);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Orders = response.Content;
            }
        }
    }
}
