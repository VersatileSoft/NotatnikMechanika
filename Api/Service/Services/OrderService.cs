using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

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

        public async Task<Response> AddCommodityToOrder(string userId, int orderId, int commodityId)
        {
            var errors = new List<string>();

            if (!await _orderRepository.CheckIfUserMatch(userId, orderId))
            {
                errors.Add("Zlecenie nie jest twoje");
            }

            if (!await _commodityRepository.CheckIfUserMatch(userId, commodityId))
            {
                errors.Add("Towar nie jest twój");
            }

            if (await _orderRepository.CheckIfOrderToCommodityExsist(orderId, commodityId))
            {
                errors.Add("Towar jest już dodany do zlecenia");
            }

            if (errors.Count > 0)
            {
                return FailureResponse(ResponseType.Failure, errors);
            }

            await _orderRepository.AddCommodityToOrder(orderId, commodityId);
            return SuccessResponse();
        }

        public async Task<Response> AddServiceToOrder(string userId, int orderId, int serviceId)
        {
            var errors = new List<string>();

            if (!await _orderRepository.CheckIfUserMatch(userId, orderId))
            {
                errors.Add("Zlecenie nie jest twoje");
            }

            if (!await _serviceRepository.CheckIfUserMatch(userId, serviceId))
            {
                errors.Add("Usługa nie jest twoja");
            }

            if (await _orderRepository.CheckIfOrderToServiceExsist(orderId, serviceId))
            {
                errors.Add("Usługa jest już dodana do zlecenia");
            }

            if (errors.Count > 0)
            {
                return FailureResponse(ResponseType.Failure, errors);
            }

            await _orderRepository.AddServiceToOrder(orderId, serviceId);
            return SuccessResponse();
        }

        public async Task<Response> DeleteCommodityFromOrder(string userId, int orderId, int commodityId)
        {
            var errors = new List<string>();

            if (!await _orderRepository.CheckIfUserMatch(userId, orderId))
            {
                errors.Add("Zlecenie nie jest twoje");
            }

            if (!await _commodityRepository.CheckIfUserMatch(userId, commodityId))
            {
                errors.Add("Towar nie jest twój");
            }

            if (!await _orderRepository.CheckIfOrderToCommodityExsist(orderId, commodityId))
            {
                errors.Add("Towar nie jest dodany do zlecenia");
            }

            if (errors.Count > 0)
            {
                return FailureResponse(ResponseType.Failure, errors);
            }

            await _orderRepository.DeleteCommodityFromOrder(orderId, commodityId);
            return SuccessResponse();
        }

        public async Task<Response> DeleteServiceFromOrder(string userId, int orderId, int serviceId)
        {
            var errors = new List<string>();

            if (!await _orderRepository.CheckIfUserMatch(userId, orderId))
            {
                errors.Add("Zlecenie nie jest twoje");
            }

            if (!await _serviceRepository.CheckIfUserMatch(userId, serviceId))
            {
                errors.Add("Usługa nie jest twoja");
            }

            if (!await _orderRepository.CheckIfOrderToServiceExsist(orderId, serviceId))
            {
                errors.Add("Usługa nie jest dodana do zlecenia");
            }

            if (errors.Count > 0)
            {
                return FailureResponse(ResponseType.Failure, errors);
            }

            await _orderRepository.DeleteServiceFromOrder(orderId, serviceId);
            return SuccessResponse();
        }

        public async Task<Response<IEnumerable<OrderExtendedModel>>> AllExtendedAsync(string userId, bool archived)
        {
            return SuccessResponse(await _orderRepository.AllExtendedAsync(userId, archived));
        }

        public async Task<Response<OrderExtendedModel>> ExtendedAsync(string userId, int id, bool archived)
        {
            return SuccessResponse(await _orderRepository.ExtendedAsync(userId, id, archived));
        }
    }
}
