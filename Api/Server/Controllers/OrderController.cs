using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Server.Controllers.Base;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Server.Controllers
{
    [Authorize]
    [Route(OrderPaths.Name)]
    public class OrdersController : AbstractControllerBase<OrderModel>
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService) : base(orderService)
        {
            _orderService = orderService;
        }

        [HttpGet(OrderPaths.ExtendedOrdersPath)]
        public Task<ActionResult<IEnumerable<OrderExtendedModel>>> AllExtendedAsync(bool archived = false)
        {
            return _orderService.AllExtendedAsync(archived);
        }

        [HttpGet(OrderPaths.ExtendedOrderPath)]
        public Task<ActionResult<OrderExtendedModel>> ExtendedAsync(int orderId)
        {
            return _orderService.ExtendedAsync(orderId, false);
        }

        [HttpPost(OrderPaths.AddExtendedOrderPath)]
        public Task<ActionResult> AddExtendedAsync([FromBody] AddOrderModel addOrderModel)
        {
            return _orderService.AddExtendedAsync(addOrderModel);
        }

        [HttpPut(OrderPaths.UpdateServiceStatusPath)]
        public Task<ActionResult> UpdateServiceStatusAsync(int orderId, int serviceId, bool finished)
        {
            return _orderService.UpdateServiceStatusAsync(orderId, serviceId, finished);
        }

        [HttpPut(OrderPaths.UpdateCommodityStatusPath)]
        public Task<ActionResult> UpdateCommodityStatusAsync(int orderId, int commodityId, bool finished)
        {
            return _orderService.UpdateCommodityStatusAsync(orderId, commodityId, finished);
        }
    }
}
