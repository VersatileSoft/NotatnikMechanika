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

        public async Task<IEnumerable<ServiceModel>> ByOrderAsync(int orderId)
        {
            var order = await DbContext.Orders.Include(o => o.Services).SingleAsync(o => o.Id == orderId);

            return order.Services
                .Select(c => new ServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Finished = c.OrderToServices.Single(o => o.Order.Id == orderId).Finished
                }).ToList();
        }
    }
}
