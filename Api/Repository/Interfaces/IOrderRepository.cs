using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<IEnumerable<OrderExtendedModel>> AllExtendedAsync(bool archived);
        Task<OrderExtendedModel> ExtendedAsync(int id, bool archived);
        Task UpdateCommodityStatusAsync(Order order, Commodity commodity, bool finished);
        Task UpdateServiceStatusAsync(Order order, Service service, bool finished);
    }
}
