using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(NotatnikMechanikaDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(dbContext, mapper, httpContextAccessor)
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
