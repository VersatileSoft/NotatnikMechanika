using NotatnikMechanika.Core.Interfaces;
using System.Threading.Tasks;

namespace NotatnikMechanika.WPF.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        public Task ShowMessageDialog(string message, MessageDialogType type, string title = null)
        {
            throw new System.NotImplementedException();
        }
    }
}