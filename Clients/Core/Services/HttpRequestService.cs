using Newtonsoft.Json;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly HttpClient _client;

        public event EventHandler<Response> Authorize;

        public HttpRequestService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Response<ResponseModel>> SendGet<ResponseModel>(string path) where ResponseModel : new()
        {
            var responseMessage = await _client.GetAsync(path);
            var response = await ParseResponse<ResponseModel>(responseMessage).ConfigureAwait(false);
            Authorize?.Invoke(this, response);
            return response;
        }

        public async Task<Response<ResponseModel>> SendPost<SendModel, ResponseModel>(SendModel model, string path) where SendModel : ValidateModelBase where ResponseModel : new()
        {
            if (!model.IsValid)
            {
                return FailureResponse<ResponseModel>(ResponseType.BadModelState);
            }

            var myContent = JsonConvert.SerializeObject(model);
            var content = new StringContent(myContent, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PostAsync(path, content);
            var response = await ParseResponse<ResponseModel>(responseMessage).ConfigureAwait(false);
            Authorize?.Invoke(this, response);
            return response;
        }

        public async Task<Response> SendPost<SendModel>(SendModel model, string path) where SendModel : ValidateModelBase
        {
            if (!model.IsValid)
            {
                return FailureResponse(ResponseType.BadModelState);
            }

            var myContent = JsonConvert.SerializeObject(model);
            var content = new StringContent(myContent, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PostAsync(path, content);
            var response = await ParseResponse(responseMessage).ConfigureAwait(false);
            Authorize?.Invoke(this, response);
            return response;
        }

        public async Task<Response> SendPost(string path)
        {
            var responseMessage = await _client.PostAsync(path, null);
            var response = await ParseResponse(responseMessage).ConfigureAwait(false);
            Authorize?.Invoke(this, response);
            return response;
        }
        
        public async Task<Response> SendUpdate<SendModel>(SendModel model, string path) where SendModel : ValidateModelBase
        {
            if (!model.IsValid)
            {
                return FailureResponse(ResponseType.BadModelState);
            }

            var myContent = JsonConvert.SerializeObject(model);
            var content = new StringContent(myContent, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PutAsync(path, content);
            var response = await ParseResponse(responseMessage).ConfigureAwait(false);
            Authorize?.Invoke(this, response);
            return response;
        }

        public async Task<Response> SendDelete(string path)
        {
            var responseMessage = await _client.DeleteAsync(path);
            var response = await ParseResponse(responseMessage).ConfigureAwait(false);
            Authorize?.Invoke(this, response);
            return response;
        }
    }
}