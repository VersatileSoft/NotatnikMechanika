using AutoMapper;
using NotatnikMechanika.Api.Data.Models;
using NotatnikMechanika.Api.Repository.Interfaces;
using NotatnikMechanika.Api.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Api.Service.Services
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

            if (await _orderRepository.IsCommodityInOrder(orderId, commodityId))
            {
                errors.Add("Towar jest już dodany do zlecenia");
            }

            if (errors.Count > 0)
            {
                return FailureResponse(ResponseType.Failure, errors);
            }

            var commodity = await _commodityRepository.ByIdAsync(commodityId);
            await _orderRepository.AddCommodityToOrder(orderId, commodity);
            return SuccessResponse();
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

            if (await _orderRepository.IsServiceInOrder(orderId, serviceId))
            {
                errors.Add("Usługa jest już dodana do zlecenia");
            }

            if (errors.Count > 0)
            {
                return FailureResponse(ResponseType.Failure, errors);
            }

            var service = await _serviceRepository.ByIdAsync(serviceId);
            await _orderRepository.AddServiceToOrder(orderId, service);
            return SuccessResponse();
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

            if (!await _orderRepository.IsCommodityInOrder(orderId, commodityId))
            {
                errors.Add("Towar nie jest dodany do zlecenia");
            }

            if (errors.Count > 0)
            {
                return FailureResponse(ResponseType.Failure, errors);
            }

            var commodity = await _commodityRepository.ByIdAsync(commodityId);
            await _orderRepository.DeleteCommodityFromOrder(orderId, commodity);
            return SuccessResponse();
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

            if (!await _orderRepository.IsServiceInOrder(orderId, serviceId))
            {
                errors.Add("Usługa nie jest dodana do zlecenia");
            }

            if (errors.Count > 0)
            {
                return FailureResponse(ResponseType.Failure, errors);
            }

            var service = await _serviceRepository.ByIdAsync(serviceId);
            await _orderRepository.DeleteServiceFromOrder(orderId, service);
            return SuccessResponse();
        }

        public async Task<Response<IEnumerable<OrderExtendedModel>>> AllExtendedAsync(string userId, bool archived)
        {
            return SuccessResponse(await _orderRepository.AllExtendedAsync(userId, archived));
        }

        public async Task<Response<OrderExtendedModel>> ExtendedAsync(string userId, int id, bool archived)
        {
            if (!await _orderRepository.CheckIfUserMatch(userId, id))
            {
                return FailureResponse<OrderExtendedModel>(ResponseType.Failure, new List<string> {NotAllowedError});
            }

            return SuccessResponse(await _orderRepository.ExtendedAsync(id, archived));
        }
    }
}
