using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        public Task<bool> CheckIfUserMatch(int userId, int Id)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(int userId, ServiceModel value)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ServiceModel>> GetAllAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceModel> GetAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int Id, ServiceModel value)
        {
            throw new NotImplementedException();
        }
    }
}
