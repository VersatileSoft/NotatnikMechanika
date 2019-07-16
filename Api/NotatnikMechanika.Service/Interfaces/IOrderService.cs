using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderModel>> GetOrdersAsync(int userId);
        Task<OrderModel> GetOrderAsync(int userId, int orderId);
        Task CreateAsync(int userId, OrderModel value);
        Task UpdateAsync(int userId, int orderId, OrderModel value);
        Task DeleteAsync(int userId, int orderId);
    }
}
