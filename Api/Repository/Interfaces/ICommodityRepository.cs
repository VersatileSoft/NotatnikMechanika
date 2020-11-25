using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface ICommodityRepository : IRepositoryBase<CommodityModel>
    {
        Task<IEnumerable<CommodityModel>> AllAsync(string userId, int orderId);
        Task<IEnumerable<CommodityModel>> ByOrderAsync(string userId, int orderId);
    }
}
