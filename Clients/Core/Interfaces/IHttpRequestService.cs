using NotatnikMechanika.Shared;
using System;
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
        Task<Response> SendDelete(string path);
    }
}