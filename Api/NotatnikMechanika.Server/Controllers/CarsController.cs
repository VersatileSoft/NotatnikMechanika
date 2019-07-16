using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Server.Controllers
{
    [Authorize]
    [Route(CarPaths.Name)]
    public class CarsController : ControllerBase
    {

        private readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet(CarPaths.GetCarsPath)]
        public async Task<ActionResult<IEnumerable<CarModel>>> GetCarsAsync()
        {
            return Ok(await _carService.GetCarsAsync(int.Parse(User.Identity.Name)));
        }

        [HttpGet(CarPaths.GetCarPath)]
        public async Task<ActionResult<CarModel>> GetCarAsync(int id)
        {
            return Ok(await _carService.GetCarAsync(int.Parse(User.Identity.Name), id));
        }

        [HttpPost(CarPaths.CreatePath)]
        public async Task<ActionResult> CreateCarAsync([FromBody] CarModel value)
        {
            await _carService.CreateAsync(int.Parse(User.Identity.Name), value);
            return Ok();
        }

        [HttpPut(CarPaths.UpdatePath)]
        public async Task<ActionResult> UpdateCarAsync(int id, [FromBody] CarModel value)
        {
            await _carService.UpdateAsync(int.Parse(User.Identity.Name), id, value);
            return Ok();
        }

        [HttpDelete(CarPaths.DeletePath)]
        public async Task<ActionResult> DeleteCarAsync(int id)
        {
            await _carService.DeleteAsync(int.Parse(User.Identity.Name), id);
            return Ok();
        }
    }
}
