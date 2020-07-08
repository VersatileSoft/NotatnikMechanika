using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Server.Controllers.Base;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Server.Controllers
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

        [HttpGet(CarPaths.GetByCustomerPath)]
        public async Task<ActionResult<Response<IEnumerable<CarModel>>>> GetCarsByCustomerAsync(int customerId)
        {
            return Ok(await _carService.GetCarsByCustomerAsync(User.Identity.Name, customerId));
        }
    }
}
