using NotatnikMechanika.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Interfaces
{
    public interface IHttpRequestService
    {
        Task<TContent> SendGet<TContent>(string path, string onErrorTitle = null) where TContent : class;
        Task<TContent> SendPost<TContent>(object model, string path, string onErrorTitle = null) where TContent : class;
        Task<bool> SendPost(object model, string path, string onErrorTitle = null);
        Task<bool> SendUpdate(object model, string path, string onErrorTitle = null);
        Task<bool> SendUpdate(string path, string onErrorTitle = null);
        Task<bool> SendDelete(string path, string onErrorTitle = null);

        // CRUD shortcut
        public Task<TContent> ById<TContent>(int id, string onErrorTitle = null) where TContent : class =>
            SendGet<TContent>(CrudPaths.ById<TContent>(id), onErrorTitle);

        public Task<List<TContent>> All<TContent>(string onErrorTitle = null) where TContent : class =>
            SendGet<List<TContent>>(CrudPaths.All<TContent>(), onErrorTitle);

        public Task<bool> Create<TContent>(TContent model, string onErrorTitle = null) =>
            SendPost(model, CrudPaths.Create<TContent>(), onErrorTitle);

        public Task<bool> Update<TContent>(TContent model, int id, string onErrorTitle = null) =>
            SendUpdate(model, CrudPaths.Update<TContent>(id), onErrorTitle);

        public Task<bool> Delete<TContent>(int id, string onErrorTitle = null) =>
            SendDelete(CrudPaths.Delete<TContent>(id), onErrorTitle);
    }
}