using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;
using NotatnikMechanika.Core.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotatnikMechanika.Client.Services
{
    public class SettingsService : ISettingsService
    {
        public Task<string> Token
        {
            get => GetTokenAsync();
            set => _localStorage.SetItemAsync("token", value.Result);
        }

        private readonly ILocalStorageService _localStorage;

        public SettingsService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        private async Task<string> GetTokenAsync()
        {
            return (await _localStorage.ContainKeyAsync("token")) ? await _localStorage.GetItemAsync<string>("token") : null;
        }

    }
}
