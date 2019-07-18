using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Server.Controllers.Base;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;

namespace NotatnikMechanika.Server.Controllers
{
    [Authorize]
    [Route(CommodityPaths.Name)]
    public class CommodityController : AbstractControllerBase<CommodityModel>
    {
        public CommodityController(ICommodityService commodityService) : base(commodityService)
        { }
    }
}
