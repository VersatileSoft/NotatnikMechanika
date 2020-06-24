using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Server.Controllers.Base;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

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


        [HttpGet(ServicePaths.GetAllForOrderPath)]
        public async Task<ActionResult<IEnumerable<ServiceForOrderModel>>> GetServicesForOrder(int orderId)
        {
            return Ok(await _serviceService.GetServicesForOrder(User.Identity.Name, orderId));
        }

        [HttpGet(ServicePaths.GetAllInOrderPath)]
        public async Task<ActionResult<IEnumerable<ServiceModel>>> GetServicesInOrder(int orderId)
        {
            return Ok(await _serviceService.GetServicesInOrder(User.Identity.Name, orderId));
        }
    }
}
