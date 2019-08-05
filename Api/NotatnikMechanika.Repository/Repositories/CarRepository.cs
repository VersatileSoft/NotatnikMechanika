using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Repositories
{
    public class CarRepository : RepositoryBase<CarModel, Car>, ICarRepository
    {
        public CarRepository(NotatnikMechanikaDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<CarModel>> GetCarsByCustomerAsync(string userId, int customerId)
        {
            return await _dbContext.Cars.Where(a => a.UserId == userId).Where(a => a.CustomerId == customerId).Select(a => new CarModel
            {
                Brand = a.Brand,
                Id = a.Id,
                CustomerId = customerId,
                Engine = a.Engine,
                Model = a.Model,
                Plate = a.Plate,
                Power = a.Power,
                Vin = a.Vin
            }).ToListAsync();
        }
    }
}
