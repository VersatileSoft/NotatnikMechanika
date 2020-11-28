using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Repositories
{
    public abstract class RepositoryBase<EntityType> : IRepositoryBase<EntityType> where EntityType : EntityBase, new()
    {
        protected readonly NotatnikMechanikaDbContext DbContext;
        protected readonly IMapper Mapper;

        protected RepositoryBase(NotatnikMechanikaDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public Task<bool> CheckIfUserMatch(string userId, int id)
        {
            return DbContext.Set<EntityType>().Where(a => a.UserId == userId).Where(a => a.Id == id).AnyAsync();
        }

        public async Task CreateAsync(string userId, EntityType value)
        {
            var entity = Mapper.Map<EntityType>(value);
            entity.UserId = userId;

            await DbContext.Set<EntityType>().AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(EntityType entity)
        {
            DbContext.Set<EntityType>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public Task<EntityType> ByIdAsync(int id)
        {
            return DbContext.Set<EntityType>().SingleAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<EntityType>> AllAsync(string userId)
        {
            return await DbContext.Set<EntityType>().Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task UpdateAsync(EntityType value)
        {
            DbContext.Set<EntityType>().Update(value);
            await DbContext.SaveChangesAsync();
        }
    }
}
