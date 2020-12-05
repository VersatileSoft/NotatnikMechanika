using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Api.Data;
using NotatnikMechanika.Api.Data.Models;
using NotatnikMechanika.Api.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotatnikMechanika.Api.Repository.Repositories
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<ServiceModel>> AllAsync(string userId, int orderId)
        {
            return await DbContext.Services.
                Where(a => a.UserId == userId).
                Select(a => 
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
            return await DbContext.Services.
                Where(c => c.Orders.Any(o => o.Id == orderId)).
                Select(c => 
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
