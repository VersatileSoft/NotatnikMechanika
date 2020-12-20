using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Services
{
    public class CarService : ServiceBase<CarModel, Car>, ICarService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository, ICustomerRepository customerRepository, IMapper mapper) : base(carRepository, mapper)
        {
            _customerRepository = customerRepository;
            _carRepository = carRepository;
        }

        public async Task<ActionResult<IEnumerable<CarModel>>> ByCustomerAsync(int customerId)
        {
            Customer customer = await _customerRepository.ByIdAsync(customerId);

            if (!AuthorizeResources(out ActionResult res, customer))
                return res;

            return new OkObjectResult(await _carRepository.ByCustomerAsync(customerId));
        }
    }
}
