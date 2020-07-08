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

        public async Task<IEnumerable<CommodityForOrderModel>> GetCommoditiesForOrder(string userId, int orderId)
        {
            return await _dbContext.Commodities.Where(a => a.UserId == userId).Include(commodity => commodity.OrderToCommodities).Select(a => new CommodityForOrderModel
            {
                Id = a.Id,
                Name = a.Name,
                Price = a.Price,
                IsInOrder = a.OrderToCommodities.Where(b => b.OrderId == orderId).Any()
            }).ToListAsync();
        }

        public async Task<IEnumerable<CommodityModel>> GetCommoditiesInOrder(string userId, int orderId)
        {
            return await _dbContext.Commodities.Include(commodity => commodity.OrderToCommodities).Where(a => a.UserId == userId).Where(a => a.OrderToCommodities.Where(a => a.OrderId == orderId).Any()).Select(a => new CommodityModel
            {
                Id = a.Id,
                Name = a.Name,
                Price = a.Price
            }).ToListAsync();
        }
    }
}
