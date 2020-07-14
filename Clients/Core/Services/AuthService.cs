using MvvmPackage.Core.Attributes;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.Services
{
    [SingleInstance]
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ISettingsService _settingsService;
        private readonly IHttpRequestService _httpRequestService;

        public event EventHandler AuthChanged;

        public AuthService(ISettingsService settingsService, HttpClient httpClient, IHttpRequestService httpRequestService)
        {
            _httpClient = httpClient;
            _settingsService = settingsService;
            _httpRequestService = httpRequestService;
        }

        public async Task<Response> RegisterAsync(RegisterModel registerModel)
        {
            return await _httpRequestService.SendPost(registerModel, new AccountPaths().GetFullPath(AccountPaths.RegisterPath));
        }

        public async Task<Response<TokenModel>> LoginAsync(LoginModel loginModel)
        {
            Response<TokenModel> loginResponse = await _httpRequestService.SendPost<LoginModel, TokenModel>(loginModel, new AccountPaths().GetFullPath(AccountPaths.LoginPath));

            if (!loginResponse.Successful)
            {
                return loginResponse;
            }

            await _settingsService.SetToken(loginResponse.Content.Token);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResponse.Content.Token);
            AuthChanged?.Invoke(this, EventArgs.Empty);
            return loginResponse;
        }

        public async Task LogoutAsync()
        {
            await _settingsService.SetToken("");
            _httpClient.DefaultRequestHeaders.Authorization = null;
            AuthChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
