using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Car;

namespace NotatnikMechanika.Service.Services
{
    public class CarService : ServiceBase<CarModel>, ICarService
    {
        public CarService(ICarRepository carRepository) : base(carRepository)
        {
        }
    }
}
