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
    public class CommodityRepository : ICommodityRepository
    {
        private readonly NotatnikMechanikaDbContext _dbContext;
        public CommodityRepository(NotatnikMechanikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckIfUserMatch(int userId, int Id)
        {
            return await _dbContext.Commodities.Where(a => a.UserId == userId).Where(a => a.Id == Id).AnyAsync();
        }

        public async Task CreateAsync(int userId, CommodityModel value)
        {
            await _dbContext.Commodities.AddAsync(new Commodity
            {
                UserId = userId,
                Name = value.Name,
                Price = value.Price
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            _dbContext.Commodities.Remove(await _dbContext.Commodities.Where(a => a.Id == Id).FirstOrDefaultAsync());
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CommodityModel>> GetAllAsync(int userId)
        {
            return await _dbContext.Commodities.Where(a => a.UserId == userId).Select(value => new CommodityModel
            {
                Name = value.Name,
                Price = value.Price
            }).ToListAsync();
        }

        public async Task<CommodityModel> GetAsync(int Id)
        {
            return await _dbContext.Commodities.Where(a => a.Id == Id).Select(value => new CommodityModel
            {
                Name = value.Name,
                Price = value.Price
            }).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(int Id, CommodityModel value)
        {
            Commodity commodity = await _dbContext.Commodities.Where(a => a.Id == Id).FirstOrDefaultAsync();

            commodity.Name = value.Name;
            commodity.Price = value.Price;

            _dbContext.Commodities.Update(commodity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
