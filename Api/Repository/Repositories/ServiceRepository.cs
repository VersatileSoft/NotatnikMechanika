using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(NotatnikMechanikaDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(dbContext, mapper, httpContextAccessor)
        {
        }

        public async Task<IEnumerable<ServiceModel>> AllAsync(int orderId)
        {
            return await DbContext.Services
                .OwnedByUser(CurrentUserId)
                .Select(a => 
                    new ServiceModel
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Price = a.Price,
                        IsInOrder = a.Orders.Any(o => o.Id == orderId),
                    }
                ).ToListAsync();
        }

        public async Task<IEnumerable<ServiceModel>> ByOrderAsync(int orderId)
        {
            return await DbContext.Services
                .Where(c => c.Orders.Any(o => o.Id == orderId))
                .Select(c => 
                    new ServiceModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Price = c.Price,
                        IsInOrder = true,
                        Finished = c.OrderToServices.FirstOrDefault(o => o.Order.Id == orderId).Finished
                    }).
                ToListAsync();
        }
    }
}
