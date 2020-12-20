using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IOrderService : IServiceBase<OrderModel>
    {
        Task<ActionResult<IEnumerable<OrderExtendedModel>>> AllExtendedAsync(bool archived);
        Task<ActionResult<OrderExtendedModel>> ExtendedAsync(int orderId, bool archived);
        Task<ActionResult> AddExtendedAsync(AddOrderModel addOrderModel);
        Task<ActionResult> UpdateServiceStatusAsync(int orderId, int serviceId, bool finished);
        Task<ActionResult> UpdateCommodityStatusAsync(int orderId, int commodityId, bool finished);
    }
}
