using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotatnikMechanika.Data.Models;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface IServiceRepository : IRepositoryBase<Service>
    {
        Task<IEnumerable<ServiceModel>> AllAsync(string userId, int orderId);
        Task<IEnumerable<ServiceModel>> ByOrderAsync(int orderId);
    }
}
