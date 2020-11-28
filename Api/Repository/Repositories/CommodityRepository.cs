using AutoMapper;
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
        public CommodityRepository(NotatnikMechanikaDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        
        public async Task<IEnumerable<CommodityModel>> AllAsync(string userId, int orderId)
        {
            return await DbContext.Commodities.
                Where(a => a.UserId == userId).
                Select(a => 
                    new CommodityModel
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Price = a.Price,
                        IsInOrder = a.Orders.Any(o => o.Id == orderId),
                    }
                ).ToListAsync();
        }

        public async Task<IEnumerable<CommodityModel>> ByOrderAsync(string userId, int orderId)
        {
            return await DbContext.Commodities.
                Where(a => a.UserId == userId).
                Where(c => c.Orders.Any(o => o.Id == orderId)).
                Select(c => 
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
