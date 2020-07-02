using NotatnikMechanika.Core.Interfaces;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NotatnikMechanika.Forms.Services
{
    public class SettingsService : ISettingsService
    {
        public Task<string> GetToken()
        {
            return Task.FromResult(Preferences.Get("Token", null));
        }

        public Task SetToken(string token)
        {
            Preferences.Set("Token", token);
            return Task.CompletedTask;
        }
    }
}