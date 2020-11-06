using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Service.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Services.Base
{
    public abstract class ServiceBase<TModel> : IServiceBase<TModel>
    {
        private readonly IRepositoryBase<TModel> _repositoryBase;

        protected string errorMessage = "This item is not yours or not exsists";
        protected ServiceBase(IRepositoryBase<TModel> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<Response> CreateAsync(string userId, TModel value)
        {
            await _repositoryBase.CreateAsync(userId, value);
            return SuccessResponse();
        }

        public async Task<Response> DeleteAsync(string userId, int Id)
        {
            if (await _repositoryBase.CheckIfUserMatch(userId, Id))
            {
                await _repositoryBase.DeleteAsync(Id);
                return SuccessResponse();
            }
            else
            {
                return FailureResponse(ResponseType.Failure, new List<string> { errorMessage });
            }
        }

        public async Task<Response<TModel>> GetAsync(string userId, int Id)
        {
            if (await _repositoryBase.CheckIfUserMatch(userId, Id))
            {
                return SuccessResponse(await _repositoryBase.GetAsync(Id));
            }
            else
            {
                return FailureResponse<TModel>(ResponseType.Failure, new List<string> { errorMessage });
            }
        }

        public async Task<Response<IEnumerable<TModel>>> GetAllAsync(string userId)
        {
            return SuccessResponse(await _repositoryBase.GetAllAsync(userId));
        }

        public async Task<Response> UpdateAsync(string userId, int Id, TModel value)
        {
            if (await _repositoryBase.CheckIfUserMatch(userId, Id))
            {
                await _repositoryBase.UpdateAsync(Id, value);
                return SuccessResponse();
            }
            else
            {
                return FailureResponse(ResponseType.Failure, new List<string> { errorMessage });
            }
        }
    }
}
