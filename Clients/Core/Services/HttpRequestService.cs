using Newtonsoft.Json;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Model;
using NotatnikMechanika.Shared;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly HttpClient _client;

        public HttpRequestService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Response<ResponseModel>> SendGet<ResponseModel>(string path) where ResponseModel : new()
        {
            HttpResponseMessage response = await _client.GetAsync(path);
            return await ParseResponse<ResponseModel>(response);
        }

        public async Task<Response<ResponseModel>> SendPost<SendModel, ResponseModel>(SendModel model, string path) where ResponseModel : new()
        {
            if (!model.IsModelValid(out Response<ResponseModel> errorResponse))
            {
                return errorResponse;
            }

            string myContent = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(myContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(path, content);
            return await ParseResponse<ResponseModel>(response);
        }

        public async Task<Response> SendPost<SendModel>(SendModel model, string path)
        {
            if (!model.IsModelValid(out Response errorResponse))
            {
                return errorResponse;
            }

            string myContent = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(myContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(path, content);
            return await ParseResponse(response);
        }

        public async Task<Response> SendPost(string path)
        {
            HttpResponseMessage response = await _client.PostAsync(path, null);
            return await ParseResponse(response);
        }

        public async Task<Response> SendDelete(string path)
        {
            HttpResponseMessage response = await _client.DeleteAsync(path);
            return await ParseResponse(response);
        }
    }
}