using NotatnikMechanika.Core.Interfaces;
using System.Threading.Tasks;

namespace NotatnikMechanika.WPF.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        public Task ShowMessageDialog(string message)
        {
            return Task.CompletedTask;
        }
    }
}
