using Autofac;
using MvvmPackage.Core;
using Newtonsoft.Json;
using NotatnikMechanika.Core.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly HttpClient _client;
        private readonly IMessageDialogService _messageDialogService;

        public HttpRequestService(HttpClient client, IMessageDialogService messageDialogService)
        {
            _client = client;
            _messageDialogService = messageDialogService;
        }

        public async Task<TContent> SendGet<TContent>(string path, string onErrorTitle) where TContent : class
        {
            return await HandleResponse<TContent>(await _client.GetAsync(path), onErrorTitle);
        }

        public async Task<bool> SendPost(object model, string path, string onErrorTitle)
        {
            string myContent = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(myContent, Encoding.UTF8, "application/json");
            return await HandleResponse(await _client.PostAsync(path, content), onErrorTitle);
        }

        public async Task<TContent> SendPost<TContent>(object model, string path, string onErrorTitle = null) where TContent : class
        {
            string myContent = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(myContent, Encoding.UTF8, "application/json");
            return await HandleResponse<TContent>(await _client.PostAsync(path, content), onErrorTitle);
        }

        public async Task<bool> SendUpdate(object model, string path, string onErrorTitle)
        {
            string myContent = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(myContent, Encoding.UTF8, "application/json");
            return await HandleResponse(await _client.PutAsync(path, content), onErrorTitle);
        }

        public async Task<bool> SendUpdate(string path, string onErrorTitle)
        {
            return await HandleResponse(await _client.PutAsync(path, null), onErrorTitle);
        }

        public async Task<bool> SendDelete(string path, string onErrorTitle)
        {
            return await HandleResponse(await _client.DeleteAsync(path), onErrorTitle);
        }

        private async Task<TContent> HandleResponse<TContent>(HttpResponseMessage response, string onErrorTitle) where TContent : class
        {
            string responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    return JsonConvert.DeserializeObject<TContent>(responseString);
                }
                catch (Exception)
                {
                    throw new Exception("Validation error");
                }
            }

            await HandleError(response, responseString, onErrorTitle);

            return null;
        }

        private async Task<bool> HandleResponse(HttpResponseMessage response, string onErrorTitle)
        {
            if (response.IsSuccessStatusCode)
                return true;

            await HandleError(response, await response.Content.ReadAsStringAsync(), onErrorTitle);

            return false;
        }

        private async Task HandleError(HttpResponseMessage response, string errorDesc, string onErrorTitle)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    await IoC.Container.Resolve<IAuthService>().LogoutAsync();
                    break;

                case HttpStatusCode.InternalServerError:
                    _messageDialogService.ShowMessageDialog("Błąd wewnętrzny serwera", MessageDialogType.Error, onErrorTitle);
                    break;

                default:
                    _messageDialogService.ShowMessageDialog(errorDesc, MessageDialogType.Error, onErrorTitle);
                    break;
            }
        }
    }
}