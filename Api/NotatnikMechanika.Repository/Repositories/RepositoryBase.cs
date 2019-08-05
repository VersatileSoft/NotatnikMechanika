using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces.Base;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Repositories
{
    public abstract class RepositoryBase<ModelType, EntityType> : IRepositoryBase<ModelType> where ModelType : class, new() where EntityType : EntityBase, new()
    {
        protected readonly NotatnikMechanikaDbContext _dbContext;

        public RepositoryBase(NotatnikMechanikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckIfUserMatch(string userId, int Id)
        {
            return await _dbContext.Set<EntityType>().Where(a => a.UserId == userId).Where(a => a.Id == Id).AnyAsync();
        }

        public async Task CreateAsync(string userId, ModelType value)
        {

            EntityType entity = new EntityType
            {
                UserId = userId
            };

            foreach (PropertyInfo prop in value.GetType().GetProperties())
            {
                if (prop.GetValue(value) == null)
                    continue;

                entity.GetType().GetProperty(prop.Name).SetValue(entity, prop.GetValue(value));
            }

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
            ModelType model = new ModelType();

            EntityType entity = await _dbContext.Set<EntityType>().Where(a => a.Id == Id).FirstOrDefaultAsync();

            foreach (PropertyInfo prop in model.GetType().GetProperties())
            {
                prop.SetValue(model, entity.GetType().GetProperty(prop.Name).GetValue(entity));
            }

            return model;
        }

        public async Task<IEnumerable<ModelType>> GetAllAsync(string userId)
        {
            List<ModelType> list = new List<ModelType>();

            foreach (EntityType entity in await _dbContext.Set<EntityType>().Where(a => a.UserId == userId).ToListAsync())
            {
                ModelType model = new ModelType();

                foreach (PropertyInfo prop in model.GetType().GetProperties())
                {
                    prop.SetValue(model, entity.GetType().GetProperty(prop.Name).GetValue(entity));
                }
                list.Add(model);
            }
            return list;
        }

        public async Task UpdateAsync(int Id, ModelType value)
        {
            EntityType entity = await _dbContext.Set<EntityType>().Where(a => a.Id == Id).FirstOrDefaultAsync();

            foreach (PropertyInfo prop in value.GetType().GetProperties())
            {
                entity.GetType().GetProperty(prop.Name).SetValue(entity, prop.GetValue(value));
            }
            _dbContext.Set<EntityType>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
