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

        [HttpGet(CommodityPaths.AllPath)]
        public async Task<ActionResult<Response<IEnumerable<CommodityModel>>>> AllAsync(int orderId)
        {
            return Ok(await _commodityService.AllAsync(orderId));
        }
        
        [HttpGet(CommodityPaths.ByOrderPath)]
        public async Task<ActionResult<Response<IEnumerable<CommodityModel>>>> ByOrderAsync(int orderId)
        {
            if (User.Identity == null)
                return Unauthorized();
            
            return Ok(await _commodityService.ByOrderAsync(orderId));
        }
    }
}
