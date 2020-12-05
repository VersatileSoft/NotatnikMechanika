using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Api.Data;
using NotatnikMechanika.Api.Data.Models;
using NotatnikMechanika.Api.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotatnikMechanika.Api.Repository.Repositories
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        { }

        public async Task<IEnumerable<CarModel>> ByCustomerAsync(int customerId)
        {
            return Mapper.Map<IEnumerable<CarModel>>(
                await DbContext.Cars.
                    Where(a => a.CustomerId == customerId).
                    ToListAsync()
            );
        }
    }
}
