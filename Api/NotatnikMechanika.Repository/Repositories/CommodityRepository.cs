using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Commodity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Repositories
{
    public class CommodityRepository : ICommodityRepository
    {
        public Task<bool> CheckIfUserMatch(int userId, int Id)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(int userId, CommodityModel value)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommodityModel>> GetAllAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<CommodityModel> GetAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int Id, CommodityModel value)
        {
            throw new NotImplementedException();
        }
    }
}
