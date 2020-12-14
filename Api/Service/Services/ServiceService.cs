using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using static NotatnikMechanika.Shared.ResponseBuilder;

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

        public async Task<Response<IEnumerable<ServiceModel>>> AllAsync(int orderId)
        {
            return SuccessResponse(await _serviceRepository.AllAsync(orderId));
        }

        public async Task<Response<IEnumerable<ServiceModel>>> ByOrderAsync(int orderId)
        {
            if (!await _orderRepository.CheckIfUserMatch(orderId))
                return FailureResponse<IEnumerable<ServiceModel>>(ResponseType.Failure, new List<string> {NotAllowedError});
            
            return SuccessResponse(await _serviceRepository.ByOrderAsync(orderId));
        }
    }
}
