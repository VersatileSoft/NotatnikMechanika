using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
