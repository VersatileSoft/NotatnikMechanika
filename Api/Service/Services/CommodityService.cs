using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Services
{
    public class CommodityService : ServiceBase<CommodityModel, Commodity>, ICommodityService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICommodityRepository _commodityRepository;

        public CommodityService(ICommodityRepository commodityRepository, IOrderRepository orderRepository, IMapper mapper) : base(commodityRepository, mapper)
        {
            _orderRepository = orderRepository;
            _commodityRepository = commodityRepository;
        }
        public async Task<ActionResult<IEnumerable<CommodityModel>>> ByOrderAsync(int orderId)
        {
            var order = await _orderRepository.ByIdAsync(orderId);

            if (!AuthorizeResources(out var res, order))
            {
                return res;
            }

            return new OkObjectResult(await _commodityRepository.ByOrderAsync(orderId));
        }
    }
}
