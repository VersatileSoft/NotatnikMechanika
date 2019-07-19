using Newtonsoft.Json;
using NotatnikMechanika.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly HttpClient client;
        private readonly ISettingsService _settingsService;

        public HttpRequestService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
            client = new HttpClient();
        }

        public async Task<Response<ResponseModel>> SendGet<ResponseModel>(string path, bool withAutorization) where ResponseModel : new()
        {

            if (withAutorization)
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settingsService.Token);
            else
                client.DefaultRequestHeaders.Authorization = null;
            
            HttpResponseMessage response = await client.GetAsync("https://notatnikmechanika.ml/" + path);

            var responseString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
                return new Response<ResponseModel> { StatusCode = HttpStatusCode.OK, Content = JsonConvert.DeserializeObject<ResponseModel>(responseString) };
            else return new Response<ResponseModel> { StatusCode = response.StatusCode, Content = new ResponseModel() };
        }

        public async Task<Response<ResponseModel>> SendPost<SendModel, ResponseModel>(SendModel model, string path, bool withAutorization) where ResponseModel : new()
        {

            if (withAutorization)
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settingsService.Token);
            else
                client.DefaultRequestHeaders.Authorization = null;

            var myContent = JsonConvert.SerializeObject(model);

            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync("https://notatnikmechanika.ml/" + path, byteContent);

            var responseString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
                return new Response<ResponseModel> { StatusCode = HttpStatusCode.OK, Content = JsonConvert.DeserializeObject<ResponseModel>(responseString) };
            else if (response.StatusCode == HttpStatusCode.BadRequest)
                return new Response<ResponseModel> { StatusCode = response.StatusCode, ErrorMessage = response.Content.ToString() };
            else return new Response<ResponseModel> { StatusCode = response.StatusCode, Content = new ResponseModel() };
        }

        public async Task<Response> SendPost<SendModel>(SendModel model, string path, bool withAutorization)
        {
            if (withAutorization)
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settingsService.Token);
            else
                client.DefaultRequestHeaders.Authorization = null;

            var myContent = JsonConvert.SerializeObject(model);

            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync("https://notatnikmechanika.ml/" + path, byteContent);

            return new Response { StatusCode = response.StatusCode, ErrorMessage = response.Content.ToString() }; ;
        }
    }

    public class Response<T> : Response
    {
        public T Content { get; set; }
    }

    public class Response
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
