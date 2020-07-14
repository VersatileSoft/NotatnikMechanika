using MatBlazor;
using NotatnikMechanika.Core.Interfaces;
using System.Threading.Tasks;

namespace NotatnikMechanika.Client.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        private readonly IMatToaster _toaster;
        public MessageDialogService(IMatToaster toaster)
        {
            _toaster = toaster;
        }

        public Task ShowMessageDialog(string message, MessageDialogType type, string title = null)
        {
            _toaster.Add(message, MatToastType.Success, title);
            return Task.CompletedTask;
        }
    }
}
