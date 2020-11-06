using Blazored.LocalStorage;
using NotatnikMechanika.Core.Interfaces;
using System.Threading.Tasks;

namespace NotatnikMechanika.Client.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ILocalStorageService _localStorage;

        public SettingsService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public Task SetToken(string token)
        {
            return _localStorage.SetItemAsync("token", token).AsTask();
        }

        public async Task<string> GetToken()
        {
            return (await _localStorage.ContainKeyAsync("token")) ? await _localStorage.GetItemAsync<string>("token") : "";
        }
    }
}
