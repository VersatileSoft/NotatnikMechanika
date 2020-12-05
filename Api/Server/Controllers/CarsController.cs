using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Api.Controllers.Base;
using NotatnikMechanika.Api.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Api.Controllers
{
    [Authorize]
    [Route(CarPaths.Name)]
    public class CarsController : AbstractControllerBase<CarModel>
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService) : base(carService)
        {
            _carService = carService;
        }

        [HttpGet(CarPaths.ByCustomerPath)]
        public async Task<ActionResult<Response<IEnumerable<CarModel>>>> ByCustomerAsync(int customerId)
        {
            if (User.Identity == null)
            {
                return Unauthorized();
            }

            return Ok(await _carService.ByCustomerAsync(User.Identity.Name, customerId));
        }
    }
}
