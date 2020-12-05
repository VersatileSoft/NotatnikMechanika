using NotatnikMechanika.Api.Data.Models;
using NotatnikMechanika.Api.Repository.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Api.Repository.Interfaces
{
    public interface ICommodityRepository : IRepositoryBase<Commodity>
    {
        Task<IEnumerable<CommodityModel>> AllAsync(string userId, int orderId);
        Task<IEnumerable<CommodityModel>> ByOrderAsync(string userId, int orderId);
    }
}
