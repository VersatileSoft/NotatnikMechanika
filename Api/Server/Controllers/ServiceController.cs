using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Server.Controllers.Base;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Server.Controllers
{
    [Authorize]
    [Route(ServicePaths.Name)]
    public class ServiceController : AbstractControllerBase<ServiceModel>
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService) : base(serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet(ServicePaths.AllPath)]
        public async Task<ActionResult<Response<IEnumerable<ServiceModel>>>> AllAsync(int orderId)
        {
            if (User.Identity == null)
                return Unauthorized();
            
            return Ok(await _serviceService.AllAsync(User.Identity.Name, orderId));
        }

        [HttpGet(ServicePaths.ByOrderPath)]
        public async Task<ActionResult<Response<IEnumerable<ServiceModel>>>> ByOrderAsync(int orderId)
        {
            if (User.Identity == null)
                return Unauthorized();
            
            return Ok(await _serviceService.ByOrderAsync(User.Identity.Name, orderId));
        }
    }
}
