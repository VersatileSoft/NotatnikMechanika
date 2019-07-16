using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface ICarRepository
    {
        Task CreateAsync(int userId, CarModel value);
        Task<bool> CheckIfUserMatch(int userId, int carId);
        Task DeleteAsync(int carId);
        Task<CarModel> GetCarAsync(int carId);
        Task<IEnumerable<CarModel>> GetCarsAsync(int userId);
        Task UpdateAsync(int carId, CarModel value);
    }
}
