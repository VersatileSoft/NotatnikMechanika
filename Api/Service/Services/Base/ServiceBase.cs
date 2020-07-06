using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Service.Exception;
using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Services.Base
{
    public abstract class ServiceBase<T> : IServiceBase<T>
    {
        private readonly IRepositoryBase<T> _repositoryBase;

        protected string errorMessage = "This item is not yours or not exsists";
        protected ServiceBase(IRepositoryBase<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<ResultBase> CreateAsync(string userId, T value)
        {
            await _repositoryBase.CreateAsync(userId, value);
            return new ResultBase
            {
                Successful = true
            };
        }

        public async Task DeleteAsync(string userId, int Id)
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

        public async Task<T> GetAsync(string userId, int Id)
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

        public async Task<GetAllResult<T>> GetAllAsync(string userId)
        {
            return new GetAllResult<T>
            {
                Successful = true,
                Models = await _repositoryBase.GetAllAsync(userId)
            };
        }

        public async Task UpdateAsync(string userId, int Id, T value)
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
