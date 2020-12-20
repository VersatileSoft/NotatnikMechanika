using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Repositories
{
    public abstract class RepositoryBase<EntityType> : IRepositoryBase<EntityType> where EntityType : EntityBase, new()
    {
        protected readonly NotatnikMechanikaDbContext DbContext;
        protected readonly IMapper Mapper;

        public string CurrentUserId =>
            _httpContextAccessor.HttpContext.User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;

        protected readonly IHttpContextAccessor _httpContextAccessor;

        protected RepositoryBase(NotatnikMechanikaDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            DbContext = dbContext;
            Mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateAsync(EntityType value)
        {
            EntityType entity = Mapper.Map<EntityType>(value);
            entity.UserId = CurrentUserId;

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

        public async Task<IEnumerable<EntityType>> AllAsync()
        {
            return await DbContext.Set<EntityType>().OwnedByUser(CurrentUserId).ToListAsync();
        }

        public async Task UpdateAsync(EntityType value)
        {
            DbContext.Set<EntityType>().Update(value);
            await DbContext.SaveChangesAsync();
        }

        public Task<bool> Transaction(Func<Task> action)
        {
            IExecutionStrategy executionStrategy = DbContext.Database.CreateExecutionStrategy();
            return executionStrategy.Execute(async () =>
                {
                    using IDbContextTransaction transaction = DbContext.Database.BeginTransaction();
                    try
                    {
                        await action();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                    return false;
                });
        }
    }
}
