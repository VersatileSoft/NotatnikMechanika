﻿using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NotatnikMechanika.Data.Models;
using System.Linq;
using static NotatnikMechanika.Shared.ResponseBuilder;

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

        public async Task<Response<IEnumerable<OrderExtendedModel>>> AllExtendedAsync(bool archived)
        {
            return SuccessResponse(await _orderRepository.AllExtendedAsync(archived));
        }

        public async Task<Response<OrderExtendedModel>> ExtendedAsync(int id, bool archived)
        {
            if (!await _orderRepository.CheckIfUserMatch(id))
                return FailureResponse<OrderExtendedModel>(ResponseType.Failure, new List<string> { NotAllowedError });

            return SuccessResponse(await _orderRepository.ExtendedAsync(id, archived));
        }

        public async Task<Response> AddExtendedAsync(AddOrderModel addOrderModel)
        {
            Response orderResponse = await CreateAsync(addOrderModel).ConfigureAwait(false);

            if (orderResponse.ResponseType != ResponseType.Successful || !orderResponse.ResourceId.HasValue)
            {
                return FailureResponse(ResponseType.Failure, new List<string>{ "Błąd, spróbuj ponownie" });
            }

            if (addOrderModel.Services.Any()) {

                foreach(int serviceId in addOrderModel.Services)
                {
                    await AddServiceToOrder(orderResponse.ResourceId.Value, serviceId).ConfigureAwait(false);
                }
            }

            if (addOrderModel.Commodities.Any())
            {
                foreach(int commodityId in addOrderModel.Commodities)
                {
                    await AddCommodityToOrder(orderResponse.ResourceId.Value, commodityId).ConfigureAwait(false);
                }
            }

            return SuccessResponse();
        }

        public async Task<Response> AddCommodityToOrder(int orderId, int commodityId)
        {
            var errors = new List<string>();

            if (!await _orderRepository.CheckIfUserMatch(orderId))
            {
                errors.Add("Zlecenie nie jest twoje");
            }

            if (!await _commodityRepository.CheckIfUserMatch(commodityId))
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

        public async Task<Response> AddServiceToOrder(int orderId, int serviceId)
        {
            var errors = new List<string>();

            if (!await _orderRepository.CheckIfUserMatch(orderId))
            {
                errors.Add("Zlecenie nie jest twoje");
            }

            if (!await _serviceRepository.CheckIfUserMatch(serviceId))
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

        public async Task<Response> UpdateServiceStatusAsync(int orderId, int serviceId, bool finished)
        {
            var errors = new List<string>();

            if (!await _orderRepository.CheckIfUserMatch(orderId))
            {
                errors.Add("Zlecenie nie jest twoje");
            }

            if (!await _serviceRepository.CheckIfUserMatch(serviceId))
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

            await _orderRepository.UpdateServiceStatusAsync(orderId, serviceId, finished);
            return SuccessResponse();
        }

        public async Task<Response> UpdateCommodityStatusAsync(int orderId, int commodityId, bool finished)
        {
            var errors = new List<string>();

            if (!await _orderRepository.CheckIfUserMatch(orderId))
            {
                errors.Add("Zlecenie nie jest twoje");
            }

            if (!await _commodityRepository.CheckIfUserMatch(commodityId))
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

            await _orderRepository.UpdateCommodityStatusAsync(orderId, commodityId, finished);
            return SuccessResponse();
        }
        public async Task<Response> DeleteCommodityFromOrder(int orderId, int commodityId)
        {
            var errors = new List<string>();

            if (!await _orderRepository.CheckIfUserMatch(orderId))
            {
                errors.Add("Zlecenie nie jest twoje");
            }

            if (!await _commodityRepository.CheckIfUserMatch(commodityId))
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

        public async Task<Response> DeleteServiceFromOrder(int orderId, int serviceId)
        {
            var errors = new List<string>();

            if (!await _orderRepository.CheckIfUserMatch(orderId))
            {
                errors.Add("Zlecenie nie jest twoje");
            }

            if (!await _serviceRepository.CheckIfUserMatch(serviceId))
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
    }
}
