using System.Collections.Generic;
using System.Threading.Tasks;
using NotatnikMechanika.Core.Models;
using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Order;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IOrderService : IServiceBase<OrderModel>
    {
        Task<IEnumerable<OrderExtendedModel>> GetAllExtendedAsync(string userId);
    }
}
