using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IOrderService : IServiceBase<OrderModel>
    {
        Task<Response<IEnumerable<OrderExtendedModel>>> AllExtendedAsync(bool archived);
        Task<Response> AddServiceToOrder(int orderId, int serviceId);
        Task<Response> AddCommodityToOrder(int orderId, int commodityId);
        Task<Response> DeleteServiceFromOrder(int orderId, int serviceId);
        Task<Response> DeleteCommodityFromOrder(int orderId, int commodityId);
        Task<Response<OrderExtendedModel>> ExtendedAsync(int orderId, bool archived);
    }
}
