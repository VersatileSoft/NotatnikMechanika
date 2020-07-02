using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Interfaces
{
    public interface ISettingsService
    {
        Task SetToken(string token);
        Task<string> GetToken();
    }
}