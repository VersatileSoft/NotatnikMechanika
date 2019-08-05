using System.Collections.Generic;
using System.Threading.Tasks;
using NotatnikMechanika.Core.Models;
using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Order;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<OrderModel>
    {
        Task<IEnumerable<OrderExtendedModel>> GetAllExtendedAsync(string userId, bool archived);
    }
}
