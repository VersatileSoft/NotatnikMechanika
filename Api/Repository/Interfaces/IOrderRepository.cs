using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotatnikMechanika.Data.Models;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<IEnumerable<OrderExtendedModel>> AllExtendedAsync(bool archived);
        Task AddCommodityToOrder(int orderId, Commodity commodity);
        Task AddServiceToOrder(int orderId, Service service);
        Task DeleteServiceFromOrder(int orderId, Service service);
        Task DeleteCommodityFromOrder(int orderId, Commodity commodity);
        Task<bool> IsCommodityInOrder(int orderId, int commodityId);
        Task<bool> IsServiceInOrder(int orderId, int serviceId);
        Task<OrderExtendedModel> ExtendedAsync(int id, bool archived);
        Task UpdateCommodityStatusAsync(int orderId, int commodityId, bool finished);
        Task UpdateServiceStatusAsync(int orderId, int serviceId, bool finished);
    }
}
