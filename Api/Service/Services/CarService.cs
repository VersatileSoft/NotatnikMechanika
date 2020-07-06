using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Services
{
    public class CarService : ServiceBase<CarModel>, ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository) : base(carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<CarsResult> GetCarsByCustomerAsync(string userId, int customerId)
        {
            return new CarsResult
            {
                Successful = true,
                Cars = await _carRepository.GetCarsByCustomerAsync(userId, customerId)
            };
        }
    }
}
