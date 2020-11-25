using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<OrderModel>
    {
        Task<IEnumerable<OrderExtendedModel>> AllExtendedAsync(string userId, bool archived);
        Task AddCommodityToOrder(int orderId, int commodityId);
        Task AddServiceToOrder(int orderId, int serviceId);
        Task DeleteServiceFromOrder(int orderId, int serviceId);
        Task DeleteCommodityFromOrder(int orderId, int commodityId);
        Task<bool> CheckIfOrderToCommodityExsist(int orderId, int commodityId);
        Task<bool> CheckIfOrderToServiceExsist(int orderId, int serviceId);
        Task<OrderExtendedModel> ExtendedAsync(string userId, int id, bool archived);
    }
}
