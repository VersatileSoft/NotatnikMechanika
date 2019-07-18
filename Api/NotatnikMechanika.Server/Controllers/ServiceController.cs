using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Server.Controllers.Base;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Service;

namespace NotatnikMechanika.Server.Controllers
{
    [Authorize]
    [Route(ServicePaths.Name)]
    public class ServiceController : AbstractControllerBase<ServiceModel>
    {
        public ServiceController(IServiceService serviceService) : base(serviceService)
        { }
    }
}
