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

        public async Task<IEnumerable<CommodityModel>> ByOrderAsync(int orderId)
        {
            Order order = await DbContext.Orders.Include(o => o.Commodities).SingleAsync(o => o.Id == orderId);

            return order.Commodities
                .Select(c => new CommodityModel {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Finished = c.OrderToCommodities.Single(o => o.Order.Id == orderId).Finished
                }).ToList();
        }
    }
}
