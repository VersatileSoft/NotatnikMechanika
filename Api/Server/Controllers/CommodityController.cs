using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Server.Controllers.Base;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

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

        [HttpGet(CommodityPaths.GetAllForOrderPath)]
        public async Task<ActionResult<Response<IEnumerable<CommodityForOrderModel>>>> GetCommoditiesForOrder(int orderId)
        {
            return Ok(await _commodityService.GetCommoditiesForOrder(User.Identity.Name, orderId));
        }

        [HttpGet(CommodityPaths.GetAllInOrderPath)]
        public async Task<ActionResult<Response<IEnumerable<CommodityModel>>>> GetCommoditiesInOrder(int orderId)
        {
            return Ok(await _commodityService.GetCommoditiesInOrder(User.Identity.Name, orderId));
        }
    }
}
