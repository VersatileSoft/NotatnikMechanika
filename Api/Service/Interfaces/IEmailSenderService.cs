using System.Threading.Tasks;

namespace NotatnikMechanika.Api.Service.Interfaces
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
