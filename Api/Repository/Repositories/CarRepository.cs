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

        public async Task<IEnumerable<CarModel>> ByCustomerAsync(string userId, int customerId)
        {
            return Mapper.Map<IEnumerable<CarModel>>(
                await DbContext.Cars.
                    Where(a => a.UserId == userId).
                    Where(a => a.CustomerId == customerId).
                    ToListAsync()
            );
        }
    }
}
