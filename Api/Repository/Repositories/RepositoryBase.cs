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
        protected readonly NotatnikMechanikaDbContext _dbContext;
        protected readonly IMapper _mapper;

        protected RepositoryBase(NotatnikMechanikaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<bool> CheckIfUserMatch(string userId, int Id)
        {
            return _dbContext.Set<EntityType>().Where(a => a.UserId == userId).Where(a => a.Id == Id).AnyAsync();
        }

        public async Task CreateAsync(string userId, ModelType value)
        {
            EntityType entity = _mapper.Map<EntityType>(value);
            entity.UserId = userId;

            await _dbContext.Set<EntityType>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            _dbContext.Set<EntityType>().Remove(await _dbContext.Set<EntityType>().Where(a => a.Id == Id).FirstOrDefaultAsync());
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ModelType> GetAsync(int Id)
        {
            EntityType entity = await _dbContext.Set<EntityType>().Where(a => a.Id == Id).FirstOrDefaultAsync();
            return _mapper.Map<ModelType>(entity);
        }

        public async Task<IEnumerable<ModelType>> GetAllAsync(string userId)
        {
            List<EntityType> result = await _dbContext.Set<EntityType>().Where(a => a.UserId == userId).ToListAsync();
            return _mapper.Map<List<EntityType>, List<ModelType>>(result);
        }

        public async Task UpdateAsync(int id, ModelType value)
        {
            EntityType entity = await _dbContext.Set<EntityType>().Where(a => a.Id == id).FirstOrDefaultAsync();
            _mapper.Map(value, entity);
            entity.Id = id;

            _dbContext.Set<EntityType>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
