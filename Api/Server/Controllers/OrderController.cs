using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Server.Controllers.Base;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

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
        public async Task<ActionResult<Response<IEnumerable<OrderExtendedModel>>>> GetAllExtendedAsync()
        {
            return Ok(await _orderService.GetAllExtendedAsync(User.Identity.Name, false));
        }

        [HttpGet(OrderPaths.GetExtendedOrder)]
        public async Task<ActionResult<Response<OrderExtendedModel>>> GetExtendedAsync(int orderId)
        {
            return Ok(await _orderService.GetExtendedAsync(User.Identity.Name, orderId, false));
        }

        /// <summary>
        /// Get list of extended Orders only archived
        /// </summary>
        [HttpGet(OrderPaths.GetArchivedExtendedOrders)]
        public async Task<ActionResult<Response<IEnumerable<OrderExtendedModel>>>> GetAllArchivedExtendedAsync()
        {
            return Ok(await _orderService.GetAllExtendedAsync(User.Identity.Name, true));
        }

        [HttpPost(OrderPaths.AddServiceToOrder)]
        public async Task<ActionResult<Response>> AddServiceToOrder(int orderId, int serviceId)
        {
            return Ok(await _orderService.AddServiceToOrder(User.Identity.Name, orderId, serviceId));
        }

        [HttpPost(OrderPaths.AddCommodityToOrder)]
        public async Task<ActionResult<Response>> AddCommodityToOrder(int orderId, int commodityId)
        {
            return Ok(await _orderService.AddCommodityToOrder(User.Identity.Name, orderId, commodityId));
        }

        [HttpDelete(OrderPaths.DeleteServiceFromOrder)]
        public async Task<ActionResult<Response>> DeleteServiceFromOrder(int orderId, int serviceId)
        {
            return Ok(await _orderService.DeleteServiceFromOrder(User.Identity.Name, orderId, serviceId));
        }

        [HttpDelete(OrderPaths.DeleteCommodityFromOrder)]
        public async Task<ActionResult<Response>> DeleteCommodityFromOrder(int orderId, int commodityId)
        {
            return Ok(await _orderService.DeleteCommodityFromOrder(User.Identity.Name, orderId, commodityId));
        }
    }
}
