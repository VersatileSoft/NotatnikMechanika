using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface IServiceRepository : IRepositoryBase<ServiceModel>
    {
        Task<IEnumerable<ServiceModel>> AllAsync(string userId, int orderId);
        Task<IEnumerable<ServiceModel>> ByOrderAsync(string userId, int orderId);
    }
}
