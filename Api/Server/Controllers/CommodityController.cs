using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Server.Controllers.Base;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Server.Controllers
{
    [Authorize]
    [Route(CommodityPaths.Name)]
    public class CommodityController : AbstractControllerBase<CommodityModel>
    {
        private readonly ICommodityService _commodityService;

        public CommodityController(ICommodityService commodityService) : base(commodityService)
        {
            _commodityService = commodityService;
        }

        [HttpGet(CommodityPaths.ByOrderPath)]
        public Task<ActionResult<IEnumerable<CommodityModel>>> ByOrderAsync(int orderId)
        {
            return _commodityService.ByOrderAsync(orderId);
        }
    }
}
