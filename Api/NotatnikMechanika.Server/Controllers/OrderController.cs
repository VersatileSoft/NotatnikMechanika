using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Server.Controllers
{
    [Authorize]
    [Route(OrderPaths.Name)]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet(OrderPaths.GetOrdersPath)]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrdersAsync()
        {
            return Ok(await _orderService.GetOrdersAsync(int.Parse(User.Identity.Name)));
        }

        [HttpGet(OrderPaths.GetOrderPath)]
        public async Task<ActionResult<OrderModel>> GetOrderAsync(int id)
        {
            return Ok(await _orderService.GetOrderAsync(int.Parse(User.Identity.Name), id));
        }

        [HttpPost(OrderPaths.CreatePath)]
        public async Task<ActionResult> CreateOrderAsync([FromBody] OrderModel value)
        {
            await _orderService.CreateAsync(int.Parse(User.Identity.Name), value);
            return Ok();
        }

        [HttpPut(OrderPaths.UpdatePath)]
        public async Task<ActionResult> UpdateOrderAsync(int id, [FromBody] OrderModel value)
        {
            await _orderService.UpdateAsync(int.Parse(User.Identity.Name), id, value);
            return Ok();
        }

        [HttpDelete(OrderPaths.DeletePath)]
        public async Task<ActionResult> DeleteOrderAsync(int id)
        {
            await _orderService.DeleteAsync(int.Parse(User.Identity.Name), id);
            return Ok();
        }
    }
}
