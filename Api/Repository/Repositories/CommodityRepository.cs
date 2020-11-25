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
    public class CommodityRepository : RepositoryBase<CommodityModel, Commodity>, ICommodityRepository
    {
        public CommodityRepository(NotatnikMechanikaDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        
        public async Task<IEnumerable<CommodityModel>> AllAsync(string userId, int orderId)
        {
            return await DbContext.Commodities.
                Where(a => a.UserId == userId).
                Include(commodity => commodity.OrderToCommodities).
                Select(a => 
                    new CommodityModel
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Price = a.Price,
                        IsInOrder = a.OrderToCommodities.Any(b => b.OrderId == orderId),
                    }
                ).ToListAsync();
        }

        public async Task<IEnumerable<CommodityModel>> ByOrderAsync(string userId, int orderId)
        {
            return await DbContext.Commodities.
                Include(commodity => commodity.OrderToCommodities).
                Where(a => a.UserId == userId).
                Where(a => a.OrderToCommodities.Any(b => b.OrderId == orderId)).
                Select(a => Mapper.Map<CommodityModel>(a)).
                ToListAsync();
        }
    }
}
