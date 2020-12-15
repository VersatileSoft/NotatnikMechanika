﻿using Microsoft.AspNetCore.Authorization;
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

        [HttpGet(OrderPaths.ExtendedOrdersPath)]
        public async Task<ActionResult<Response<IEnumerable<OrderExtendedModel>>>> AllExtendedAsync(bool archived = false)
        {
            return Ok(await _orderService.AllExtendedAsync(archived));
        }

        [HttpGet(OrderPaths.ExtendedOrderPath)]
        public async Task<ActionResult<Response<OrderExtendedModel>>> ExtendedAsync(int orderId)
        {           
            return Ok(await _orderService.ExtendedAsync(orderId, false));
        }

        [HttpPost(OrderPaths.AddExtendedOrderPath)]
        public async Task<ActionResult<Response<OrderExtendedModel>>> AddExtendedAsync([FromBody] AddOrderModel addOrderModel)
        {
            return Ok(await _orderService.AddExtendedAsync(addOrderModel));
        }

        [HttpPost(OrderPaths.AddServiceToOrderPath)]
        public async Task<ActionResult<Response>> AddServiceToOrder(int orderId, int serviceId)
        {
            return Ok(await _orderService.AddServiceToOrder(orderId, serviceId));
        }

        [HttpPost(OrderPaths.AddCommodityToOrderPath)]
        public async Task<ActionResult<Response>> AddCommodityToOrder(int orderId, int commodityId)
        {
            return Ok(await _orderService.AddCommodityToOrder(orderId, commodityId));
        }

        [HttpPut(OrderPaths.UpdateServiceStatusPath)]
        public async Task<ActionResult<Response>> UpdateServiceStatusAsync(int orderId, int serviceId, bool finished)
        {
            return Ok(await _orderService.UpdateServiceStatusAsync(orderId, serviceId, finished));
        }

        [HttpPut(OrderPaths.UpdateCommodityStatusPath)]
        public async Task<ActionResult<Response>> UpdateCommodityStatusAsync(int orderId, int commodityId, bool finished)
        {
            return Ok(await _orderService.UpdateCommodityStatusAsync(orderId, commodityId, finished));
        }


        [HttpDelete(OrderPaths.DeleteServiceFromOrderPath)]
        public async Task<ActionResult<Response>> DeleteServiceFromOrder(int orderId, int serviceId)
        {
            return Ok(await _orderService.DeleteServiceFromOrder(orderId, serviceId));
        }

        [HttpDelete(OrderPaths.DeleteCommodityFromOrderPath)]
        public async Task<ActionResult<Response>> DeleteCommodityFromOrder(int orderId, int commodityId)
        {
            return Ok(await _orderService.DeleteCommodityFromOrder(orderId, commodityId));
        }
    }
}
