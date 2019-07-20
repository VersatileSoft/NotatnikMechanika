using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Service.Exception;
using NotatnikMechanika.Service.Interfaces.Base;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Services.Base
{
    public abstract class ServiceBase<T> : IServiceBase<T>
    {
        private readonly IRepositoryBase<T> _repositoryBase;

        protected string errorMessage = "This item is not yours or not exsists";
        public ServiceBase(IRepositoryBase<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task CreateAsync(int userId, T value)
        {
            await _repositoryBase.CreateAsync(userId, value);
        }

        public async Task DeleteAsync(int userId, int Id)
        {
            if (await _repositoryBase.CheckIfUserMatch(userId, Id))
            {
                await _repositoryBase.DeleteAsync(Id);
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, errorMessage);
            }
        }

        public async Task<T> GetAsync(int userId, int Id)
        {
            if (await _repositoryBase.CheckIfUserMatch(userId, Id))
            {
                return await _repositoryBase.GetAsync(Id);
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, errorMessage);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(int userId)
        {
            return await _repositoryBase.GetAllAsync(userId);
        }

        public async Task UpdateAsync(int userId, int Id, T value)
        {
            if (await _repositoryBase.CheckIfUserMatch(userId, Id))
            {
                await _repositoryBase.UpdateAsync(Id, value);
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, errorMessage);
            }
        }
    }
}
