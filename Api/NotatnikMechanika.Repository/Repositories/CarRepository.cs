using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Car;

namespace NotatnikMechanika.Repository.Repositories
{
    public class CarRepository : RepositoryBase<CarModel, Car>, ICarRepository
    {
        public CarRepository(NotatnikMechanikaDbContext dbContext) : base(dbContext)
        {

        }
    }
}
