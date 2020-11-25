using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface ICommodityService : IServiceBase<CommodityModel>
    {
        Task<Response<IEnumerable<CommodityModel>>> AllAsync(string userId, int orderId);
        Task<Response<IEnumerable<CommodityModel>>> ByOrderAsync(string userId, int orderId);
    }
}
