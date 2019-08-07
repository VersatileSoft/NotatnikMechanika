using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Services
{
    public class ServiceService : ServiceBase<ServiceModel>, IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository) : base(serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public Task<IEnumerable<ServiceForOrderModel>> GetServicesForOrder(string userId, int orderId)
        {
            return _serviceRepository.GetServicesForOrder(userId, orderId);
        }

        public Task<IEnumerable<ServiceModel>> GetServicesInOrder(string userId, int orderId)
        {
            return _serviceRepository.GetServicesInOrder(userId, orderId);
        }
    }
}
