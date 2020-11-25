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
    public abstract class RepositoryBase<ModelType, EntityType> : IRepositoryBase<ModelType> where ModelType : class, new() where EntityType : EntityBase, new()
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

        public async Task CreateAsync(string userId, ModelType value)
        {
            var entity = Mapper.Map<EntityType>(value);
            entity.UserId = userId;

            await DbContext.Set<EntityType>().AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            DbContext.Set<EntityType>().Remove(await DbContext.Set<EntityType>().Where(a => a.Id == id).FirstOrDefaultAsync());
            await DbContext.SaveChangesAsync();
        }

        public async Task<ModelType> ByIdAsync(int id)
        {
            var entity = await DbContext.Set<EntityType>().Where(a => a.Id == id).FirstOrDefaultAsync();
            return Mapper.Map<ModelType>(entity);
        }

        public async Task<IEnumerable<ModelType>> AllAsync(string userId)
        {
            var result = await DbContext.Set<EntityType>().Where(a => a.UserId == userId).ToListAsync();
            return Mapper.Map<List<EntityType>, List<ModelType>>(result);
        }

        public async Task UpdateAsync(int id, ModelType value)
        {
            var entity = await DbContext.Set<EntityType>().Where(a => a.Id == id).FirstOrDefaultAsync();
            Mapper.Map(value, entity);
            entity.Id = id;

            DbContext.Set<EntityType>().Update(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
