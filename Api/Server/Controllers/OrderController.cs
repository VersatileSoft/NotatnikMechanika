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

        /// <summary>
        /// Get list of extended Orders only not archived
        /// </summary>
        [HttpGet(OrderPaths.GetExtendedOrders)]
        public async Task<ActionResult<AllExtendedOrdersResult>> GetAllExtendedAsync()
        {
            return Ok(await _orderService.GetAllExtendedAsync(User.Identity.Name, false));
        }

        /// <summary>
        /// Get list of extended Orders only archived
        /// </summary>
        [HttpGet(OrderPaths.GetArchivedExtendedOrders)]
        public async Task<ActionResult<AllExtendedOrdersResult>> GetAllArchivedExtendedAsync()
        {
            return Ok(await _orderService.GetAllExtendedAsync(User.Identity.Name, true));
        }

        [HttpPost(OrderPaths.AddServiceToOrder)]
        public async Task<ActionResult> AddServiceToOrder(int orderId, int serviceId)
        {
            await _orderService.AddServiceToOrder(User.Identity.Name, orderId, serviceId);
            return Ok();
        }

        [HttpPost(OrderPaths.AddCommodityToOrder)]
        public async Task<ActionResult> AddCommodityToOrder(int orderId, int commodityId)
        {
            await _orderService.AddCommodityToOrder(User.Identity.Name, orderId, commodityId);
            return Ok();
        }

        [HttpDelete(OrderPaths.DeleteServiceFromOrder)]
        public async Task<ActionResult> DeleteServiceFromOrder(int orderId, int serviceId)
        {
            await _orderService.DeleteServiceFromOrder(User.Identity.Name, orderId, serviceId);
            return Ok();
        }

        [HttpDelete(OrderPaths.DeleteCommodityFromOrder)]
        public async Task<ActionResult> DeleteCommodityFromOrder(int orderId, int commodityId)
        {
            await _orderService.DeleteCommodityFromOrder(User.Identity.Name, orderId, commodityId);
            return Ok();
        }
    }
}
