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

        public async Task<IEnumerable<ServiceForOrderModel>> GetServicesForOrder(string userId, int orderId)
        {
            return await _dbContext.Services.Where(a => a.UserId == userId).Include(service => service.OrderToServices).Select(a => new ServiceForOrderModel
            {
                Id = a.Id,
                Name = a.Name,
                Price = a.Price,
                IsInOrder = a.OrderToServices.Where(b => b.OrderId == orderId).Any()
            }).ToListAsync();
        }

        public async Task<IEnumerable<ServiceModel>> GetServicesInOrder(string userId, int orderId)
        {
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Service, IEnumerable<OrderToService>> i = _dbContext.Services.Include(service => service.OrderToServices);

            return await _dbContext.Services.Include(service => service.OrderToServices).Where(a => a.UserId == userId).Where(a => a.OrderToServices.Where(a => a.OrderId == orderId).Any()).Select(a => new ServiceModel
            {
                Id = a.Id,
                Name = a.Name,
                Price = a.Price
            }).ToListAsync();
        }
    }
}
