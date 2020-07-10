using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Services
{
    public class ServiceService : ServiceBase<ServiceModel>, IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository) : base(serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Response<IEnumerable<ServiceForOrderModel>>> GetServicesForOrder(string userId, int orderId)
        {
            return CreateResponse(await _serviceRepository.GetServicesForOrder(userId, orderId));
        }

        public async Task<Response<IEnumerable<ServiceModel>>> GetServicesInOrder(string userId, int orderId)
        {

            return CreateResponse(await _serviceRepository.GetServicesInOrder(userId, orderId));
        }
    }
}
