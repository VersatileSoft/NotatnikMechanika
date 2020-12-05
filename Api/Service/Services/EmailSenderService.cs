using Microsoft.Extensions.Options;
using NotatnikMechanika.Api.Service.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace NotatnikMechanika.Api.Service.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        public EmailSenderService(IOptions<AppSettings> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        private AppSettings Options { get; } //set only via Secret Manager

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            SendGridClient client = new SendGridClient(Options.SendGridKey);
            SendGridMessage msg = new SendGridMessage()
            {
                From = new EmailAddress(Options.EmailSender, Options.SenderName),
                Subject = subject,
                HtmlContent = message
            };

            msg.AddTo(new EmailAddress(email));

            msg.SetClickTracking(false, false);
            await client.SendEmailAsync(msg);
        }
    }
}


