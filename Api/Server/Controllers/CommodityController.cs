using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Api.Controllers.Base;
using NotatnikMechanika.Api.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Api.Controllers
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
            if (User.Identity == null)
            {
                return Unauthorized();
            }

            return Ok(await _commodityService.AllAsync(User.Identity.Name, orderId));
        }
        
        [HttpGet(CommodityPaths.ByOrderPath)]
        public async Task<ActionResult<Response<IEnumerable<CommodityModel>>>> ByOrderAsync(int orderId)
        {
            if (User.Identity == null)
            {
                return Unauthorized();
            }

            return Ok(await _commodityService.ByOrderAsync(User.Identity.Name, orderId));
        }
    }
}
