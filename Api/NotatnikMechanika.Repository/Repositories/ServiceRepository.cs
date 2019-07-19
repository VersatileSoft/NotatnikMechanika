using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly NotatnikMechanikaDbContext _dbContext;
        public ServiceRepository(NotatnikMechanikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckIfUserMatch(int userId, int Id)
        {
            return await _dbContext.Services.Where(a => a.UserId == userId).Where(a => a.Id == Id).AnyAsync();
        }

        public async Task CreateAsync(int userId, ServiceModel value)
        {
            await _dbContext.Services.AddAsync(new Service
            {
                UserId = userId,
                Name = value.Name,
                Price = value.Price
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            _dbContext.Services.Remove(await _dbContext.Services.Where(a => a.Id == Id).FirstOrDefaultAsync());
            await _dbContext.SaveChangesAsync();
        }

        public Task<IEnumerable<ServiceModel>> GetAllAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceModel> GetAsync(int Id)
        {
            return await _dbContext.Services.Where(a => a.Id == Id).Select(value => new ServiceModel
            {
                Name = value.Name,
                Price = value.Price
            }).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(int Id, ServiceModel value)
        {
            Service service = await _dbContext.Services.Where(a => a.Id == Id).FirstOrDefaultAsync();

            service.Name = value.Name;
                service.Price = value.Price;

            _dbContext.Services.Update(service);
            await _dbContext.SaveChangesAsync();
        }
    }
}
