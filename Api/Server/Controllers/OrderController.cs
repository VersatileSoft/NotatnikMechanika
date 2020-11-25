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
        [HttpGet(OrderPaths.ExtendedOrdersPath)]
        public async Task<ActionResult<Response<IEnumerable<OrderExtendedModel>>>> AllExtendedAsync(bool archived = false)
        {
            return Ok(await _orderService.AllExtendedAsync(User.Identity.Name, archived));
        }

        [HttpGet(OrderPaths.ExtendedOrderPath)]
        public async Task<ActionResult<Response<OrderExtendedModel>>> ExtendedAsync(int orderId)
        {
            return Ok(await _orderService.ExtendedAsync(User.Identity.Name, orderId, false));
        }

        [HttpPost(OrderPaths.AddServiceToOrderPath)]
        public async Task<ActionResult<Response>> AddServiceToOrder(int orderId, int serviceId)
        {
            return Ok(await _orderService.AddServiceToOrder(User.Identity.Name, orderId, serviceId));
        }

        [HttpPost(OrderPaths.AddCommodityToOrderPath)]
        public async Task<ActionResult<Response>> AddCommodityToOrder(int orderId, int commodityId)
        {
            return Ok(await _orderService.AddCommodityToOrder(User.Identity.Name, orderId, commodityId));
        }

        [HttpDelete(OrderPaths.DeleteServiceFromOrderPath)]
        public async Task<ActionResult<Response>> DeleteServiceFromOrder(int orderId, int serviceId)
        {
            return Ok(await _orderService.DeleteServiceFromOrder(User.Identity.Name, orderId, serviceId));
        }

        [HttpDelete(OrderPaths.DeleteCommodityFromOrderPath)]
        public async Task<ActionResult<Response>> DeleteCommodityFromOrder(int orderId, int commodityId)
        {
            return Ok(await _orderService.DeleteCommodityFromOrder(User.Identity.Name, orderId, commodityId));
        }
    }
}
