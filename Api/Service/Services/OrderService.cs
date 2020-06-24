using NotatnikMechanika.Core.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Exception;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Services
{
    public class OrderService : ServiceBase<OrderModel>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly ICommodityRepository _commodityRepository;

        public OrderService(IOrderRepository orderRepository, IServiceRepository serviceRepository, ICommodityRepository commodityRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
            _serviceRepository = serviceRepository;
            _commodityRepository = commodityRepository;
        }

        public async Task AddCommodityToOrder(string userId, int orderId, int commodityId)
        {
            if (!await _orderRepository.CheckIfUserMatch(userId, orderId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "Zlecenie nie jest twoje");
            }

            if (!await _commodityRepository.CheckIfUserMatch(userId, commodityId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "Towar nie jest twój");
            }

            if (await _orderRepository.CheckIfOrderToCommodityExsist(orderId, commodityId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "Towar jest już dodany do zlecenia");
            }

            await _orderRepository.AddCommodityToOrder(orderId, commodityId);
        }

        public async Task AddServiceToOrder(string userId, int orderId, int serviceId)
        {
            if (!await _orderRepository.CheckIfUserMatch(userId, orderId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "Zlecenie nie jest twoje");
            }

            if (!await _serviceRepository.CheckIfUserMatch(userId, serviceId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "Usługa nie jest twoja");
            }

            if (await _orderRepository.CheckIfOrderToServiceExsist(orderId, serviceId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "Usługa jest już dodana do zlecenia");
            }

            await _orderRepository.AddServiceToOrder(orderId, serviceId);
        }

        public async Task DeleteCommodityFromOrder(string userId, int orderId, int commodityId)
        {
            if (!await _orderRepository.CheckIfUserMatch(userId, orderId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "Zlecenie nie jest twoje");
            }

            if (!await _commodityRepository.CheckIfUserMatch(userId, commodityId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "Towar nie jest twój");
            }

            if (!await _orderRepository.CheckIfOrderToCommodityExsist(orderId, commodityId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "Towar nie jest dodany do zlecenia");
            }

            await _orderRepository.DeleteCommodityFromOrder(orderId, commodityId);
        }

        public async Task DeleteServiceFromOrder(string userId, int orderId, int serviceId)
        {
            if (!await _orderRepository.CheckIfUserMatch(userId, orderId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "Zlecenie nie jest twoje");
            }

            if (!await _serviceRepository.CheckIfUserMatch(userId, serviceId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "Usługa nie jest twoja");
            }

            if (!await _orderRepository.CheckIfOrderToServiceExsist(orderId, serviceId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "Usługa nie jest dodana do zlecenia");
            }

            await _orderRepository.DeleteServiceFromOrder(orderId, serviceId);
        }

        public Task<IEnumerable<OrderExtendedModel>> GetAllExtendedAsync(string userId, bool archived)
        {
            return _orderRepository.GetAllExtendedAsync(userId, archived);
        }
    }
}
