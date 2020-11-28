using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Service.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NotatnikMechanika.Data.Models;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Services.Base
{
    public abstract class ServiceBase<TModel, TEntity> : IServiceBase<TModel> where TEntity : EntityBase
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;
        private readonly IMapper _mapper;

        protected const string NotAllowedError = "This item is not yours or not exsists";

        protected ServiceBase(IRepositoryBase<TEntity> repositoryBase, IMapper mapper)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }

        public async Task<Response> CreateAsync(string userId, TModel value)
        {
            var entity = _mapper.Map<TEntity>(value);
            entity.UserId = userId;
            
            await _repositoryBase.CreateAsync(userId, entity);
            return SuccessResponse();
        }

        public async Task<Response> DeleteAsync(string userId, int id)
        {
            if (!await _repositoryBase.CheckIfUserMatch(userId, id))
                return FailureResponse(ResponseType.Failure, new List<string> {NotAllowedError});
            
            var entity = await _repositoryBase.ByIdAsync(id);
            await _repositoryBase.DeleteAsync(entity);
            return SuccessResponse();
        }

        public async Task<Response<TModel>> ByIdAsync(string userId, int id)
        {
            if (!await _repositoryBase.CheckIfUserMatch(userId, id))
                return FailureResponse<TModel>(ResponseType.Failure, new List<string> { NotAllowedError });
            
            var model = _mapper.Map<TModel>(await _repositoryBase.ByIdAsync(id));
            return SuccessResponse(model);
        }

        public async Task<Response<IEnumerable<TModel>>> AllAsync(string userId)
        {
            var result = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(await _repositoryBase.AllAsync(userId));
            return SuccessResponse(result);
        }

        public async Task<Response> UpdateAsync(string userId, int id, TModel value)
        {
            if (!await _repositoryBase.CheckIfUserMatch(userId, id))
                return FailureResponse(ResponseType.Failure, new List<string> {NotAllowedError});

            var entity = await _repositoryBase.ByIdAsync(id);
            _mapper.Map(value, entity);
            entity.Id = id;
            
            await _repositoryBase.UpdateAsync(entity);
            return SuccessResponse();
        }
    }
}
