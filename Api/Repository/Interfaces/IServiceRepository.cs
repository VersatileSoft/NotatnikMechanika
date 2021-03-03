using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface IServiceRepository : IRepositoryBase<Service>
    {
        Task<IEnumerable<ServiceModel>> ByOrderAsync(int orderId);
    }
}
