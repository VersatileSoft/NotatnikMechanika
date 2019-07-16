using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Exception;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateAsync(int userId, OrderModel value)
        {
            await _orderRepository.CreateAsync(userId, value);
        }

        public async Task DeleteAsync(int userId, int OrderId)
        {
            if (await _orderRepository.CheckIfUserMatch(userId, OrderId))
            {
                await _orderRepository.DeleteAsync(OrderId);
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "This order is not yours or not exsists");
            }
        }

        public async Task<OrderModel> GetOrderAsync(int userId, int OrderId)
        {
            if (await _orderRepository.CheckIfUserMatch(userId, OrderId))
            {
                return await _orderRepository.GetOrderAsync(OrderId);
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "This order is not yours or not exsists");
            }
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersAsync(int userId)
        {
            return await _orderRepository.GetOrdersAsync(userId);
        }

        public async Task UpdateAsync(int userId, int OrderId, OrderModel value)
        {
            if (await _orderRepository.CheckIfUserMatch(userId, OrderId))
            {
                await _orderRepository.UpdateAsync(OrderId, value);
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "This order is not yours or not exsists");
            }
        }
    }
}
