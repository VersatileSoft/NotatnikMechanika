using AutoMapper;
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
        public CarRepository(NotatnikMechanikaDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        { }

        public async Task<IEnumerable<CarModel>> GetCarsByCustomerAsync(string userId, int customerId)
        {
            return _mapper.Map<IEnumerable<CarModel>>(await _dbContext.Cars.Where(a => a.UserId == userId).Where(a => a.CustomerId == customerId).ToListAsync());
        }
    }
}
