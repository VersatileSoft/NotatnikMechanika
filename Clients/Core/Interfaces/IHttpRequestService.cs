using NotatnikMechanika.Core.Model;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Interfaces
{
    public interface IHttpRequestService
    {
        /// <summary>
        /// Send request to server
        /// </summary>
        /// <typeparam name="SendModel">Type of Model to send</typeparam>
        /// <typeparam name="ResponseModel">Type of Response Model</typeparam>
        /// <param name="model">Model to send</param>
        /// <param name="path">Path to api</param>
        /// <returns>Response Model</returns>
        Task<Response<ResponseModel>> SendPost<SendModel, ResponseModel>(SendModel model, string path) where ResponseModel : new();
        Task<Response<ResultBase>> SendPost<SendModel>(SendModel model, string path);
        Task<Response<object>> SendPost(string path);
        Task<Response<object>> SendDelete(string path);
        Task<Response<ResponseModel>> SendGet<ResponseModel>(string path) where ResponseModel : new();
    }
}