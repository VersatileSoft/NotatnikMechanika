using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Order;
using PropertyChanged;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrdersViewModel : MvxViewModel
    {
        public IEnumerable<OrderModel> Orders { get; set; }
        private readonly IHttpRequestService _httpRequestService;
        public OrdersViewModel(IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
        }

        public override async Task Initialize()
        {
            Response<List<OrderModel>> response = await _httpRequestService.SendGet<List<OrderModel>>(OrderPaths.GetFullPath(CRUDPaths.GetAllPath), true);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Orders = response.Content;
            }
        }
    }
}
