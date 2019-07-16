using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarModel>> GetCarsAsync(int userId);
        Task<CarModel> GetCarAsync(int userId, int carId);
        Task CreateAsync(int userId, CarModel value);
        Task UpdateAsync(int userId, int carId, CarModel value);
        Task DeleteAsync(int userId, int carId);
    }
}
