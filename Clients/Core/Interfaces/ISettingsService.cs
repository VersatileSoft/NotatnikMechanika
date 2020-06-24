using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Interfaces
{
    public interface ISettingsService
    {
        Task<string> Token { get; set; }
    }
}