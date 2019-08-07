using NotatnikMechanika.Core.Services;
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
        Task<Response<ResponseModel>> SendPost<SendModel, ResponseModel>(SendModel model, string path, bool withAutorization) where ResponseModel : new();
        Task<Response> SendPost<SendModel>(SendModel model, string path, bool withAutorization);
        Task<Response> SendPost(string path, bool withAutorization);
        Task<Response> SendDelete(string path, bool withAutorization);
        Task<Response<ResponseModel>> SendGet<ResponseModel>(string path, bool withAutorization) where ResponseModel : new();
    }
}
