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
            List<string> errors = new List<string>();

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
                return BadRequestResponse(errors);
            }

            await _orderRepository.AddCommodityToOrder(orderId, commodityId);
            return SuccessEmptyResponse;
        }

        public async Task<Response> AddServiceToOrder(string userId, int orderId, int serviceId)
        {
            List<string> errors = new List<string>();

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
                return BadRequestResponse(errors);
            }

            await _orderRepository.AddServiceToOrder(orderId, serviceId);
            return SuccessEmptyResponse;
        }

        public async Task<Response> DeleteCommodityFromOrder(string userId, int orderId, int commodityId)
        {
            List<string> errors = new List<string>();

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
                return BadRequestResponse(errors);
            }

            await _orderRepository.DeleteCommodityFromOrder(orderId, commodityId);
            return SuccessEmptyResponse;
        }

        public async Task<Response> DeleteServiceFromOrder(string userId, int orderId, int serviceId)
        {
            List<string> errors = new List<string>();

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
                return BadRequestResponse(errors);
            }

            await _orderRepository.DeleteServiceFromOrder(orderId, serviceId);
            return SuccessEmptyResponse;
        }

        public async Task<Response<IEnumerable<OrderExtendedModel>>> GetAllExtendedAsync(string userId, bool archived)
        {
            return CreateResponse(await _orderRepository.GetAllExtendedAsync(userId, archived));
        }

        public async Task<Response<OrderExtendedModel>> GetExtendedAsync(string userId, int id, bool archived)
        {
            return CreateResponse(await _orderRepository.GetExtendedAsync(userId, id, archived));
        }
    }
}
