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

        private const string ErrorMessage = "This item is not yours or not exsists";

        protected ServiceBase(IRepositoryBase<TModel> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<Response> CreateAsync(string userId, TModel value)
        {
            await _repositoryBase.CreateAsync(userId, value);
            return SuccessResponse();
        }

        public async Task<Response> DeleteAsync(string userId, int id)
        {
            if (!await _repositoryBase.CheckIfUserMatch(userId, id))
                return FailureResponse(ResponseType.Failure, new List<string> {ErrorMessage});
            
            await _repositoryBase.DeleteAsync(id);
            return SuccessResponse();
        }

        public async Task<Response<TModel>> ByIdAsync(string userId, int id)
        {
            if (!await _repositoryBase.CheckIfUserMatch(userId, id))
                return FailureResponse<TModel>(ResponseType.Failure, new List<string> { ErrorMessage });
            
            return SuccessResponse(await _repositoryBase.ByIdAsync(id));
        }

        public async Task<Response<IEnumerable<TModel>>> AllAsync(string userId)
        {
            return SuccessResponse(await _repositoryBase.AllAsync(userId));
        }

        public async Task<Response> UpdateAsync(string userId, int id, TModel value)
        {
            if (!await _repositoryBase.CheckIfUserMatch(userId, id))
                return FailureResponse(ResponseType.Failure, new List<string> {ErrorMessage});
            
            await _repositoryBase.UpdateAsync(id, value);
            return SuccessResponse();
        }
    }
}
