using NotatnikMechanika.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
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
        Task<Response<ResponseModel>> SendRequest<SendModel, ResponseModel>(SendModel model, string path) where ResponseModel : new();
    }
}
