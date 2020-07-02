using NotatnikMechanika.Core.Interfaces;
using System.Configuration;
using System.Threading.Tasks;

namespace NotatnikMechanika.WPF.Services
{
    public class SettingsService : ISettingsService
    {
        public Task<string> GetToken()
        {
            try
            {
                return Task.FromResult(Settings.Default.Token);
            }
            catch (SettingsPropertyNotFoundException)
            {
                return Task.FromResult<string>(null);
            }
        }

        public Task SetToken(string token)
        {
            Settings.Default.Token = token;
            Settings.Default.Save();
            return Task.CompletedTask;
        }
    }
}