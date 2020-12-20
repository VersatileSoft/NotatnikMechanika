using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface ICommodityService : IServiceBase<CommodityModel>
    {
        Task<ActionResult<IEnumerable<CommodityModel>>> ByOrderAsync(int orderId);
    }
}
