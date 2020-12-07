using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface ICommodityService : IServiceBase<CommodityModel>
    {
        Task<Response<IEnumerable<CommodityModel>>> AllAsync(int orderId);
        Task<Response<IEnumerable<CommodityModel>>> ByOrderAsync(int orderId);
    }
}
