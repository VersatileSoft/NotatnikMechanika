using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IServiceService : IServiceBase<ServiceModel>
    {
        Task<IEnumerable<ServiceForOrderModel>> GetServicesForOrder(string userId, int orderId);
        Task<IEnumerable<ServiceModel>> GetServicesInOrder(string userId, int orderId);
    }
}
