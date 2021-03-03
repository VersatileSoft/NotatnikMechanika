using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Services
{
    public class ServiceService : ServiceBase<ServiceModel, Data.Models.Service>, IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IOrderRepository _orderRepository;

        public ServiceService(IServiceRepository serviceRepository, IOrderRepository orderRepository, IMapper mapper) : base(serviceRepository, mapper)
        {
            _serviceRepository = serviceRepository;
            _orderRepository = orderRepository;
        }

        public async Task<ActionResult<IEnumerable<ServiceModel>>> ByOrderAsync(int orderId)
        {
            var order = await _orderRepository.ByIdAsync(orderId);

            if (!AuthorizeResources(out var res, order))
            {
                return res;
            }

            return new OkObjectResult(await _serviceRepository.ByOrderAsync(orderId));
        }
    }
}
