using Newtonsoft.Json;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Model;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly HttpClient _client;

        //TODO put to config file
        //private const string ServerAddress = "https://notatnikmechanika.ml/";
        private const string ServerAddress = "http://localhost:2137/";

        public HttpRequestService(HttpClient client)
        {
            //_settingsService = settingsService;
            _client = client;
        }

        public async Task<Response<ResponseModel>> SendGet<ResponseModel>(string path) where ResponseModel : new()
        {
            HttpResponseMessage response = await _client.GetAsync(path);
            return await Response<ResponseModel>.GetResponse(response);
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
            return await Response<ResponseModel>.GetResponse(response);
        }

        public async Task<Response<object>> SendPost<SendModel>(SendModel model, string path)
        {
            if (!model.IsModelValid(out Response<object> errorResponse))
            {
                return errorResponse;
            }

            string myContent = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(myContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(ServerAddress + path, content);
            return await Response<object>.GetResponse(response);
        }

        public async Task<Response<object>> SendPost(string path)
        {
            HttpResponseMessage response = await _client.PostAsync(ServerAddress + path, null);
            return await Response<object>.GetResponse(response);
        }

        public async Task<Response<object>> SendDelete(string path)
        {
            HttpResponseMessage response = await _client.DeleteAsync(ServerAddress + path);
            return await Response<object>.GetResponse(response);
        }
    }
}