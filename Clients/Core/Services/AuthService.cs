using Autofac;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using IdentityModel.OidcClient.Results;
using MvvmPackage.Core;
using MvvmPackage.Core.Attributes;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.Services
{
   // [SingleInstance]
    public class AuthService : IAuthService
    {
        public event EventHandler AuthChanged;

        /*  // private readonly HttpClient _httpClient;
private readonly ISettingsService _settingsService;
private readonly IHttpRequestService _httpRequestService;

public event EventHandler AuthChanged;

public AuthService(ISettingsService settingsService, *//*HttpClient httpClient,*//* IHttpRequestService httpRequestService)
{
   // _httpClient = httpClient;
    _settingsService = settingsService;
    _httpRequestService = httpRequestService;
    _httpRequestService.Authorize += AuthorizeResponse;
}

public async Task<Response<TokenModel>> LoginAsync(LoginModel loginModel)
{
    Response<TokenModel> loginResponse = await _httpRequestService.SendPost<LoginModel, TokenModel>(loginModel, AccountPaths.Login());

    if (loginResponse.ResponseType != ResponseType.Successful)
    {
        return loginResponse;
    }

    await _settingsService.SetToken(loginResponse.Content.Token);
  //  _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResponse.Content.Token);
    AuthChanged?.Invoke(this, EventArgs.Empty);
    return loginResponse;
}

public async Task LogoutAsync()
{
    await _settingsService.SetToken("");
   // _httpClient.DefaultRequestHeaders.Authorization = null;
    AuthChanged?.Invoke(this, EventArgs.Empty);
}

private async void AuthorizeResponse(object sender, Response response)
{
    if (response.ResponseType == ResponseType.Unauthorized)
    {
        await LogoutAsync();
    }
}*/

        public async Task AuthorizeAsync()
        {
            var options = new OidcClientOptions
            {
                Authority = "https://demo.identityserver.io/",
                ClientId = "device",
                RedirectUri = "urn:ietf:wg:oauth:2.0:oob",
                Scope = "openid profile",
                Browser = IoC.Container.Resolve<IBrowser>(),
            };

           var client = new OidcClient(options);
            LoginResult result = null;
            try
            {
                result = await client.LoginAsync();

            }
            catch(Exception e)
            {
                Console.Error.WriteLine(e.InnerException);
            }

            var i = 3;
            IoC.Container.Resolve<HttpClient>().DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
           
        }

        public Task<Response<TokenModel>> LoginAsync(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
