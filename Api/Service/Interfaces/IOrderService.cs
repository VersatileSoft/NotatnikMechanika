using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IOrderService : IServiceBase<OrderModel>
    {
        Task<Response<IEnumerable<OrderExtendedModel>>> AllExtendedAsync(string userId, bool archived);
        Task<Response> AddServiceToOrder(string userId, int orderId, int serviceId);
        Task<Response> AddCommodityToOrder(string userId, int orderId, int commodityId);
        Task<Response> DeleteServiceFromOrder(string userId, int orderId, int serviceId);
        Task<Response> DeleteCommodityFromOrder(string userId, int orderId, int commodityId);
        Task<Response<OrderExtendedModel>> ExtendedAsync(string userId, int orderId, bool archived);
    }
}
