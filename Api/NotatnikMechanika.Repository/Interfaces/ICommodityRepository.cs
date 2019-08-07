using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface ICommodityRepository : IRepositoryBase<CommodityModel>
    {
        Task<IEnumerable<CommodityForOrderModel>> GetCommoditiesForOrder(string userId, int orderId);
        Task<IEnumerable<CommodityModel>> GetCommoditiesInOrder(string userId, int orderId);
    }
}
