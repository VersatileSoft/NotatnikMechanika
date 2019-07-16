using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateAsync(int userId, OrderModel value);
        Task<bool> CheckIfUserMatch(int userId, int orderId);
        Task DeleteAsync(int orderId);
        Task<OrderModel> GetOrderAsync(int orderId);
        Task<IEnumerable<OrderModel>> GetOrdersAsync(int userId);
        Task UpdateAsync(int orderId, OrderModel value);
    }
}
