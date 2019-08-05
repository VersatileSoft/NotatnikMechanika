using System.Collections.Generic;
using System.Threading.Tasks;
using NotatnikMechanika.Core.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Order;

namespace NotatnikMechanika.Service.Services
{
    public class OrderService : ServiceBase<OrderModel>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<IEnumerable<OrderExtendedModel>> GetAllExtendedAsync(string userId, bool archived)
        {
            return _orderRepository.GetAllExtendedAsync(userId, archived);
        }
    }
}
