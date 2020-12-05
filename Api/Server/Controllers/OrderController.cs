using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Api.Controllers.Base;
using NotatnikMechanika.Api.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using static NotatnikMechanika.Shared.ResponseBuilder;
using System.Security.Claims;
using NotatnikMechanika.Api.Extensions;

namespace NotatnikMechanika.Api.Controllers
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
            return Ok(await _orderService.AllExtendedAsync(User.Id(), archived));
        }

        [HttpGet(OrderPaths.ExtendedOrderPath)]
        public async Task<ActionResult<Response<OrderExtendedModel>>> ExtendedAsync(int orderId)
        {
            return Ok(await _orderService.ExtendedAsync(User.Id(), orderId, false));
        }

        [HttpPost(OrderPaths.AddServiceToOrderPath)]
        public async Task<ActionResult<Response>> AddServiceToOrder(int orderId, int serviceId)
        {
            return Ok(await _orderService.AddServiceToOrder(User.Id(), orderId, serviceId));
        }

        [HttpPost(OrderPaths.AddCommodityToOrderPath)]
        public async Task<ActionResult<Response>> AddCommodityToOrder(int orderId, int commodityId)
        {
            return Ok(await _orderService.AddCommodityToOrder(User.Id(), orderId, commodityId));
        }

        [HttpDelete(OrderPaths.DeleteServiceFromOrderPath)]
        public async Task<ActionResult<Response>> DeleteServiceFromOrder(int orderId, int serviceId)
        {
            return Ok(await _orderService.DeleteServiceFromOrder(User.Id(), orderId, serviceId));
        }

        [HttpDelete(OrderPaths.DeleteCommodityFromOrderPath)]
        public async Task<ActionResult<Response>> DeleteCommodityFromOrder(int orderId, int commodityId)
        {
            return Ok(await _orderService.DeleteCommodityFromOrder(User.Id(), orderId, commodityId));
        }
    }
}
