using MvvmCross.Commands;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels
{
    public class AddOrderViewModel : MvxViewModel
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public IEnumerable<int> ServicesIds { get; set; }
        public IEnumerable<int> CommoditiesIds { get; set; }
        public DateTime AcceptDate { get; set; }
        public DateTime FinishDate { get; set; }
        public ICommand AddOrder { get; set; }

        private IHttpRequestService _httpRequestService;

        public AddOrderViewModel(IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
            AddOrder = new MvxAsyncCommand(AddOrderAction);
        }

        private async Task AddOrderAction()
        {
            OrderModel model = new OrderModel
            {
                AcceptDate = AcceptDate,
                CarId = CarId,
                CommoditiesIds = CommoditiesIds,
                CustomerId = CustomerId,
                FinishDate = FinishDate,
                ServicesIds = ServicesIds
            };

            await _httpRequestService.SendPost(model, OrderPaths.GetFullPath(CRUDPaths.CreatePath), true);
        }
    }
}
