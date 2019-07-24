using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Service;

namespace NotatnikMechanika.Repository.Repositories
{
    public class ServiceRepository : RepositoryBase<ServiceModel, Service>, IServiceRepository
    {
        public ServiceRepository(NotatnikMechanikaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
