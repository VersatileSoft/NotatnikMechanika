using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Repositories
{
    public class CommodityRepository : RepositoryBase<Commodity>, ICommodityRepository
    {
        public CommodityRepository(NotatnikMechanikaDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(dbContext, mapper, httpContextAccessor)
        {
        }
        
        public async Task<IEnumerable<CommodityModel>> AllAsync(int orderId)
        {
            return await DbContext.Commodities
                .OwnedByUser(CurrentUserId)
                .Select(a => 
                    new CommodityModel
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Price = a.Price,
                        IsInOrder = a.Orders.Any(o => o.Id == orderId),
                    }
                ).ToListAsync();
        }

        public async Task<IEnumerable<CommodityModel>> ByOrderAsync(int orderId)
        {
            return await DbContext.Commodities
                .OwnedByUser(CurrentUserId)
                .Where(c => c.Orders.Any(o => o.Id == orderId))
                .Select(c => 
                    new CommodityModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Price = c.Price,
                        IsInOrder = true,
                        Finished = c.OrderToCommodities.FirstOrDefault(o => o.Order.Id == orderId).Finished
                    }).
                ToListAsync();
        }
    }
}
