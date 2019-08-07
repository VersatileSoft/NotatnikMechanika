using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface IServiceRepository : IRepositoryBase<ServiceModel>
    {
        Task<IEnumerable<ServiceForOrderModel>> GetServicesForOrder(string userId, int orderId);
        Task<IEnumerable<ServiceModel>> GetServicesInOrder(string userId, int orderId);
    }
}
