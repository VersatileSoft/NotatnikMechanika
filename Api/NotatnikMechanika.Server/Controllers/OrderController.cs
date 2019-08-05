using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Core.Models;
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
        /// <returns></returns>
        [HttpGet(OrderPaths.GetExtendedOrders)]
        public async Task<ActionResult<IEnumerable<OrderExtendedModel>>> GetAllExtendedAsync()
        {
            return Ok(await _orderService.GetAllExtendedAsync(User.Identity.Name, false));
        }

        /// <summary>
        /// Get list of extended Orders only archived
        /// </summary>
        /// <returns></returns>
        [HttpGet(OrderPaths.GetArchivedExtendedOrders)]
        public async Task<ActionResult<IEnumerable<OrderExtendedModel>>> GetAllArchivedExtendedAsync()
        {
            return Ok(await _orderService.GetAllExtendedAsync(User.Identity.Name, true));
        }
    }
}
