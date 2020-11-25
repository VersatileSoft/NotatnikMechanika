using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Repositories
{
    public class ServiceRepository : RepositoryBase<ServiceModel, Service>, IServiceRepository
    {
        public ServiceRepository(NotatnikMechanikaDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<ServiceModel>> AllAsync(string userId, int orderId)
        {
            return await DbContext.Services.
                Where(a => a.UserId == userId).
                Include(service => service.OrderToServices).
                Select(a => new ServiceModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Price = a.Price,
                    IsInOrder = a.OrderToServices.Any(b => b.OrderId == orderId)
                }).ToListAsync();
        }

        public async Task<IEnumerable<ServiceModel>> ByOrderAsync(string userId, int orderId)
        {
            return await DbContext.Services.
                Include(service => service.OrderToServices).
                Where(a => a.UserId == userId).
                Where(a => a.OrderToServices.Any(b => b.OrderId == orderId)).
                Select(a => Mapper.Map<ServiceModel>(a)).
                ToListAsync();
        }
    }
}
