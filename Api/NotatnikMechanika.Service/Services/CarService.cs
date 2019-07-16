using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Exception;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task CreateAsync(int userId, CarModel value)
        {
            await _carRepository.CreateAsync(userId, value);
        }

        public async Task DeleteAsync(int userId, int CarId)
        {
            if (await _carRepository.CheckIfUserMatch(userId, CarId))
            {
                await _carRepository.DeleteAsync(CarId);
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "This car is not yours or not exsists");
            }
        }

        public async Task<CarModel> GetCarAsync(int userId, int CarId)
        {
            if (await _carRepository.CheckIfUserMatch(userId, CarId))
            {
                return await _carRepository.GetCarAsync(CarId);
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "This car is not yours or not exsists");
            }
        }

        public async Task<IEnumerable<CarModel>> GetCarsAsync(int userId)
        {
            return await _carRepository.GetCarsAsync(userId);
        }

        public async Task UpdateAsync(int userId, int CarId, CarModel value)
        {
            if (await _carRepository.CheckIfUserMatch(userId, CarId))
            {
                await _carRepository.UpdateAsync(CarId, value);
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "This car is not yours or not exsists");
            }
        }
    }
}
