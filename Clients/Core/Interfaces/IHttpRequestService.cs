using NotatnikMechanika.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.Interfaces
{
    public interface IHttpRequestService
    {
        event EventHandler<Response> Authorize;
        Task<Response<ResponseModel>> SendGet<ResponseModel>(string path) where ResponseModel : new();
        Task<Response<ResponseModel>> SendPost<SendModel, ResponseModel>(SendModel model, string path) where ResponseModel : new() where SendModel : ValidateModelBase;
        Task<Response> SendPost<SendModel>(SendModel model, string path) where SendModel : ValidateModelBase;
        Task<Response> SendPost(string path);
        Task<Response> SendUpdate<SendModel>(SendModel model, string path) where SendModel : ValidateModelBase;
        Task<Response> SendDelete(string path);
        
        // CRUD shortcut
        public Task<Response<ResponseModel>> ById<ResponseModel>(int id) where ResponseModel : new() =>
            SendGet<ResponseModel>(CrudPaths.ById<ResponseModel>(id));
        
        public Task<Response<List<ResponseModel>>> All<ResponseModel>() where ResponseModel : new() =>
            SendGet<List<ResponseModel>>(CrudPaths.All<ResponseModel>());
        
        public Task<Response> Create<SendModel>(SendModel model) where SendModel : ValidateModelBase =>
            SendPost(model, CrudPaths.Create<SendModel>());
        
        public Task<Response> Update<SendModel>(SendModel model, int id) where SendModel : ValidateModelBase =>
            SendUpdate(model, CrudPaths.Update<SendModel>(id));
        
        public Task<Response> Delete<DeleteModel>(int id) =>
            SendDelete(CrudPaths.Delete<DeleteModel>(id));
    }
}