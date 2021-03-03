using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Services
{
    public class OrderService : ServiceBase<OrderModel, Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly ICommodityRepository _commodityRepository;

        public OrderService(IOrderRepository orderRepository, IServiceRepository serviceRepository, ICommodityRepository commodityRepository, IMapper mapper) : base(orderRepository, mapper)
        {
            _orderRepository = orderRepository;
            _serviceRepository = serviceRepository;
            _commodityRepository = commodityRepository;
        }

        public async Task<ActionResult<IEnumerable<OrderExtendedModel>>> AllExtendedAsync(bool archived)
        {
            return new OkObjectResult(await _orderRepository.AllExtendedAsync(archived));
        }

        public async Task<ActionResult<OrderExtendedModel>> ExtendedAsync(int id, bool archived)
        {
            var order = await _orderRepository.ByIdAsync(id);

            if (!AuthorizeResources(out var res, order))
            {
                return res;
            }

            return await _orderRepository.ExtendedAsync(id, archived);
        }

        public async Task<ActionResult> AddExtendedAsync(AddOrderModel addOrderModel)
        {
            return (await _orderRepository.Transaction(async () =>
            {
                var orderResponse = await CreateAsync(addOrderModel).ConfigureAwait(false);

                if (orderResponse is CreatedResult r && r.Value is Order order)
                {
                    order.Services = new List<Data.Models.Service>();
                    order.Commodities = new List<Commodity>();
                    foreach (int serviceId in addOrderModel.Services)
                    {
                        var service = await _serviceRepository.ByIdAsync(serviceId);

                        if (!AuthorizeResources(out var res, service))
                        {
                            throw new Exception(res.ToString());
                        }

                        order.Services.Add(service);
                    }

                    foreach (int commodityId in addOrderModel.Commodities)
                    {
                        var commodity = await _commodityRepository.ByIdAsync(commodityId);

                        if (!AuthorizeResources(out var res, commodity))
                        {
                            throw new Exception(res.ToString());
                        }

                        order.Commodities.Add(commodity);
                    }

                    await _orderRepository.UpdateAsync(order);
                }
            })) ? new OkResult() : new BadRequestObjectResult("Coś poszło nie tak");
        }

        public async Task<ActionResult> UpdateServiceStatusAsync(int orderId, int serviceId, bool finished)
        {
            var service = await _serviceRepository.ByIdAsync(serviceId);
            var order = await _orderRepository.ByIdAsync(orderId);

            if (!AuthorizeResources(out var res, service, order))
            {
                return res;
            }
            /* if (!order.Services.Any(s => s.Id == service.Id))
    return new BadRequestObjectResult("Usługa nie jest dodana do zlecenia");*/

            await _orderRepository.UpdateServiceStatusAsync(order, service, finished);
            return new OkResult();
        }

        public async Task<ActionResult> UpdateCommodityStatusAsync(int orderId, int commodityId, bool finished)
        {
            var commodity = await _commodityRepository.ByIdAsync(commodityId);
            var order = await _orderRepository.ByIdAsync(orderId);

            if (!AuthorizeResources(out var res, commodity, order))
            {
                return res;
            }
            /* if (!order.Commodities.Any(s => s.Id == commodity.Id))
    return new BadRequestObjectResult("Towar nie jest dodany do zlecenia");*/

            await _orderRepository.UpdateCommodityStatusAsync(order, commodity, finished);
            return new OkResult();
        }
    }
}
