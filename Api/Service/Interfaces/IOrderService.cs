using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IOrderService : IServiceBase<OrderModel>
    {
        Task<AllExtendedOrdersResult> GetAllExtendedAsync(string userId, bool archived);
        Task AddServiceToOrder(string userId, int orderId, int serviceId);
        Task AddCommodityToOrder(string userId, int orderId, int commodityId);
        Task DeleteServiceFromOrder(string userId, int orderId, int serviceId);
        Task DeleteCommodityFromOrder(string userId, int orderId, int commodityId);
    }
}
